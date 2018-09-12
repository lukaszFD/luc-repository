using System;
using IWshRuntimeLibrary;
using System.IO;
using System.Threading;

namespace CreateShortcut
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourcePath = Directory.GetCurrentDirectory() + @"\InstallationFiles\";
            string targetPath = @"C:\ZipPassword";
            string[] files = System.IO.Directory.GetFiles(sourcePath);
            string fileName = "";

            try
            {
                if (!System.IO.Directory.Exists(targetPath))
                {
                    System.IO.Directory.CreateDirectory(targetPath);
                    foreach (string s in files)
                    {
                        fileName = System.IO.Path.GetFileName(s);
                        System.IO.File.Copy(s, System.IO.Path.Combine(targetPath + @"\", fileName), true);
                    }
                }
                if (System.IO.Directory.Exists(targetPath))
                {
                    foreach (string s in files)
                    {
                        fileName = System.IO.Path.GetFileName(s);
                        System.IO.File.Copy(s, System.IO.Path.Combine(targetPath + @"\", fileName), true);
                    }
                }

                WshShell wsh = new WshShell();
                IWshRuntimeLibrary.IWshShortcut shortcut = wsh.CreateShortcut(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\ZipPassword.lnk") as IWshRuntimeLibrary.IWshShortcut;
                shortcut.Arguments = "";
                shortcut.TargetPath = targetPath + @"\ZipPassword.exe";
                shortcut.WindowStyle = 1;
                shortcut.WorkingDirectory = targetPath;
                shortcut.IconLocation = targetPath + @"\ico_password.ico";
                shortcut.Save();
                Console.WriteLine(string.Format(@"Pliki instalacyjne znajdują się na dysku C:\ w lokalizacji {0} ." 
                    + Environment.NewLine + 
                    @"Skrót do aplikacji został utworzony na pulpicie."
                    + Environment.NewLine + 
                    @"Pozdrawiam, Łukasz D.", targetPath));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Thread.Sleep(10000);
        }
    }
}
