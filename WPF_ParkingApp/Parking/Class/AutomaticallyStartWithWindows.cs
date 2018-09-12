using Microsoft.Win32;
using System;
using System.IO;
using System.Windows.Forms;
using Parking.Interface;

namespace Parking.Class
{
    class AutomaticallyStartWithWindows : IWindows
    {
        private string path = Directory.GetCurrentDirectory();
        private string appName = Path.GetFileName(Application.ExecutablePath);
        public void Start()
        {
            try
            {
                using (var key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                {
                    key.SetValue(appName, path + @"\" + appName);
                }
                MessageBox.Show(string.Format("Aplikacja : {0} została dodana.", appName));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Stop()
        {
            try
            {
                using (var key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                {
                    key.DeleteValue(appName, false);
                    MessageBox.Show(string.Format("Aplikacja : {0} została usunięta.", appName));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
