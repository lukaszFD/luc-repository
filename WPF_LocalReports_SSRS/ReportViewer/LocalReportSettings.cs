using Microsoft.Reporting.WinForms;
using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace ReportViewer
{
    public class LocalReportSettings
    {
        /// <summary>
        /// Export report to file
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="pathToAttachment"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="recipients"></param>
        /// <returns></returns>
        public async Task ExportReportToPDF_Async(object obj, LocalReport localReport, string pathToReport, string extension)
        {
            CancellationToken ct = (CancellationToken)obj;
            ct.ThrowIfCancellationRequested();
            await Task.Factory.StartNew(() => ExportReportToPDF(localReport, pathToReport, extension), ct);
        }
        public void ExportReportToPDF(LocalReport localReport, string pathToReport, string extension)
        {
            string pathToFile = pathToReport + "." + extension;
            try
            {
                Warning[] warnings;
                string[] streamids;
                string mimeType;
                string encoding;
                string filenameExtension;
                byte[] bytes = localReport.Render("Excel", null, out mimeType, out encoding, out filenameExtension, out streamids, out warnings);
                using (var fs = new FileStream(pathToFile, FileMode.Create))
                {
                    fs.Write(bytes, 0, bytes.Length);
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
