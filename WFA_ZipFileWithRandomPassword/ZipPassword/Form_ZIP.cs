using System;
using System.Windows.Forms;
using SevenZip;
using System.IO;
using ZipPassword.Class.GeneratePasswords;

namespace ZipPassword
{
    public partial class Form_ZIP : Form
    {
        public Form_ZIP()
        {
            InitializeComponent();
            defaultButton();
        }
        private void btnOpenfile_Click(object sender, EventArgs e)
        {
            if (rbtFile.Checked == true)
            {
                openFileDialog1.ShowDialog();
                tbxPathToFile.Text = openFileDialog1.FileName;
            }
            if(rbtDictionary.Checked == true)
            {
                folderBrowserDialog1.ShowDialog();
                tbxPathToFile.Text = folderBrowserDialog1.SelectedPath;
            }
        }
        public void defaultButton()
        {
            rbtPrecision1.Checked = true;
            rbtRandom.Checked = true;
            rbtFile.Checked = true;
        }

        private void btnZip_Click(object sender, EventArgs e)
        {
            try
            {
                SevenZipBase.SetLibraryPath(Directory.GetCurrentDirectory() + @"\7z.dll");

                SevenZipCompressor compressor = new SevenZipCompressor();
                RndPassword rndPass = new RndPassword();

                int precision = rbtPrecision1.Checked ? 5 : rbtPrecision2.Checked ? 10 : rbtPrecision3.Checked ? 15 : rbtPrecision4.Checked ? 20 : 5;

                if (!string.IsNullOrWhiteSpace(tbxPathToFile.Text))
                {
                    string password = "";
                    string sourceFiles = tbxPathToFile.Text;
                    string zipDestinationFile = Path.GetDirectoryName(tbxPathToFile.Text) + @"\" + Path.GetFileNameWithoutExtension(tbxPathToFile.Text) + @".zip";
                    string txtDestinationFile = Path.GetDirectoryName(tbxPathToFile.Text) + @"\Password.txt";

                    if (rbtNumbers.Checked)
                        password = rndPass.Numbers(precision);
                    if (rbtLetters.Checked)
                        password = rndPass.UpperAndLower(precision);
                    if (rbtSpecial.Checked)
                        password = rndPass.SpecialCharacters(precision);
                    if (rbtRandom.Checked)
                        password = rndPass.PasswordWithManyDifferentCharacters(precision);

                    if (rbtFile.Checked == true)
                    {
                        compressor.CompressFilesEncrypted(zipDestinationFile, password, sourceFiles);
                        File.WriteAllText(txtDestinationFile, password);
                    }
                    if (rbtDictionary.Checked == true)
                    {
                        compressor.CompressDirectory(sourceFiles, zipDestinationFile, password);
                        File.WriteAllText(txtDestinationFile, password);
                    }

                    if (checkBoxClosed.Checked == true)
                    {
                        this.Close();
                    }

                    MessageBox.Show("Pik ZIP został stworzony" + Environment.NewLine + string.Format("Hasło zostało zapisane w {0}", txtDestinationFile), "ZIP z hasłem",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                    tbxPathToFile.Clear();
                    defaultButton();
                }
                else
                {
                    MessageBox.Show("Brak ścieżki do pliku","Uwaga !!", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                tbxPathToFile.Clear();
                defaultButton();
            }
        }

    }
}
