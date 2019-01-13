using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Media;
using ReportViewer;
using System.Threading;
using System.Data;
using Microsoft.Reporting.WinForms;

namespace ReportViewer_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            progressBar.IsIndeterminate = false;
            new Directories().ChangeFileExtension(sourcePath);
            PopulateCombobox();

        }
        string accountId { get; set; }
        string dataSet { get; set; }
        string script { get; set; }

        string sourcePath = @"C:\Users\" + Environment.UserName + @"\Documents\ReportViewer\";

        private void btnClient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cbxReports.Text.Length > 0)
                {
                    if (Regex.IsMatch(tbxClient.Text, @"^.{36}$"))
                    {
                        CreateReport(cbxReports.Text);
                    }
                    else
                    {
                        MessageBox.Show("Musisz wpisać id klienta !");
                    }
                }
                else
                {
                    MessageBox.Show("Musisz wybrać raport !");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PopulateCombobox()
        {
            List<string> list = new List<string>(new Directories().GetFile(sourcePath));
            var files = (from l in list select l).Distinct().ToList();
            foreach (var item in files)
            {
                cbxReports.Items.Add(item);
            }
        }

        private void tbxClient_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(tbxClient.Text, @"^.{36}$"))
            {
                btnClient.IsEnabled = false;
                tbxClient.Background = Brushes.Red;
            }
            else
            {
                btnClient.IsEnabled = true;
                tbxClient.Background = Brushes.White;
                accountId = tbxClient.Text;
            }
        }

        private async void CreateReport(string fileName)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            try
            {
                progressBar.IsIndeterminate = true;
                string pathToDir = sourcePath;
                string reportRDLC = pathToDir + fileName + @".rdlc";
                string reportXml = pathToDir + fileName + @".xml";

                DataTable dt = new DataTable();
                dt = await new ParseXml().Data_Async(cts.Token, reportXml);

                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.ProcessingMode = ProcessingMode.Local;
                LocalReport localReport = reportViewer1.LocalReport;
                localReport.ReportPath = reportRDLC;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataSet = dt.Rows[i][0].ToString();
                    script = dt.Rows[i][1].ToString();
                    localReport.DataSources.Add(new ReportDataSource(dataSet, await new SqlServ().GetData_Script_Async(cts.Token, script, tbxClient.Text)));
                }
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                cts.Cancel();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                progressBar.IsIndeterminate = false;
            }
        }
    }
}
