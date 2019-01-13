using Microsoft.Reporting.WinForms;
using System.Data;
using System.Windows;
using System;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;
using ReportViewer;

namespace RDLC__Example_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CreateReport();
        }
        string dataSet { get; set; }
        string script { get; set; }

        private async void CreateReport()
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            try
            {
                string pathToDir = @"C:\LocalReports_SSRS\";
                string reportRDLC = pathToDir + @"Example.rdlc";
                string reportXml = pathToDir + @"Example.xml";
                List<string> list = new List<string>();


                //list.Add("lukasz@example.com");

                DataTable dt = new DataTable();
                dt = await new ParseXml().Data_Async(cts.Token, reportXml);

                reportViewer1.ProcessingMode = ProcessingMode.Local;
                LocalReport localReport = reportViewer1.LocalReport;
                localReport.ReportPath = reportRDLC;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataSet = dt.Rows[i][0].ToString();
                    script = dt.Rows[i][1].ToString();
                    localReport.DataSources.Add(new ReportDataSource(dataSet, await new SqlServ().GetData_USP_Async(cts.Token, script)));
                }
                reportViewer1.RefreshReport();

                await new LocalReportSettings().ExportReportToPDF_Async(cts.Token, localReport, pathToDir + "Example", "xls");
                await new SendEmail().Email_Async(cts.Token, pathToDir + "Example.xls", "Example", "Raport w załączniku" + Environment.NewLine + "Lukasz", list);
            }
            catch (Exception ex)
            {
                cts.Cancel();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Process[] processes = Process.GetProcessesByName("RDLC_Example_WPF");
                foreach (var process in processes)
                {
                    process.Kill();
                }
            }
        }
    }
}
