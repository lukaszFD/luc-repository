using Microsoft.Win32;
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
            using (var key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
            {
                key.SetValue(appName, path + @"\" + appName);
            }
            MessageBox.Show(string.Format("Aplikacja : {0} została dodana.", appName));
        }
        public void Stop()
        {
            using (var key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
            {
                key.DeleteValue(appName, false);
                MessageBox.Show(string.Format("Aplikacja : {0} została usunięta.", appName));
            }
        }
    }
}
