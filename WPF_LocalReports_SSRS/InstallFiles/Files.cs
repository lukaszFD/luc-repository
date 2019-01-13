using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReportViewer;
using System.IO;

namespace InstallFiles
{
    class Files
    {
        static void Main(string[] args)
        {
            try
            {
                string sourcePath = Directory.GetCurrentDirectory();
                string targetPath = @"C:\LocalReports_SSRS";
                new Directories().Manage(targetPath, sourcePath);
                Console.WriteLine("Zrobione");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
