using IWshRuntimeLibrary;
using ReportViewer;
using System;
using System.IO;


namespace CreateShortcut
{
    class Shortcut
    {
        static void Main(string[] args)
        {
            try
            {
                string sourcePath = Directory.GetCurrentDirectory();
                string sourceFileName = "";
                foreach (var item in Directory.GetFiles(sourcePath, "*.exe"))
                {
                    sourceFileName = Path.GetFileNameWithoutExtension(item.ToString());
                }
                string targetPath = @"C:\Users\" + Environment.UserName + @"\Documents\ReportViewer";
                new Directories().Manage(targetPath, sourcePath);
                CreateShortCut(sourceFileName, targetPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void CreateShortCut(string sourceFileName, string targetPath)
        {
            try
            {
                WshShell wsh = new WshShell();
                IWshShortcut shortcut = wsh.CreateShortcut(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + sourceFileName.Replace("_WPF", "") + ".lnk") as IWshShortcut;
                shortcut.Arguments = "";
                shortcut.TargetPath = targetPath + @"\" + sourceFileName + ".exe";
                shortcut.WindowStyle = 1;
                shortcut.WorkingDirectory = targetPath;
                shortcut.IconLocation = targetPath + @"\image.ico";
                shortcut.Save();
            }
            catch (Exception ex )
            {
                throw ex;
            }
        }
    }
}
