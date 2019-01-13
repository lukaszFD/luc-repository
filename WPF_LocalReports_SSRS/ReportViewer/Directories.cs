using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace ReportViewer
{
    public class Directories
    {
        /// <summary>
        /// Crate or delete target directories
        /// </summary>
        /// <param name="targetPath"></param>
        /// <param name="sourcePath"></param>
        public void Manage(string targetPath, string sourcePath)
        {
            try
            {
                string fileName = "";
                string[] files = Directory.GetFiles(sourcePath);
                if (!Directory.Exists(targetPath))
                {
                    Directory.CreateDirectory(targetPath);
                    foreach (string s in files)
                    {
                        fileName = Path.GetFileName(s);
                        System.IO.File.Copy(s, Path.Combine(targetPath + @"\", fileName), true);
                    }
                }
                if (Directory.Exists(targetPath))
                {
                    Directory.Delete(targetPath, true);
                    Directory.CreateDirectory(targetPath);

                    foreach (string s in files)
                    {
                        fileName = Path.GetFileName(s);
                        System.IO.File.Copy(s, Path.Combine(targetPath + @"\", fileName), true);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<string> GetFile(string sourcePath)
        {
            List<string> list = new List<string>(Directory.GetFiles(sourcePath, "*.rdlc"));
            List<string> listFiles = new List<string>();

            foreach (var item in list)
            {
                listFiles.Add(Path.GetFileNameWithoutExtension(item.ToString()));
            }
            return listFiles;
        }

        public void ChangeFileExtension(string sourcePath)
        {
            if (Directory.Exists(sourcePath))
            {
                List<string> files = Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories)
                                    .Where(file => ".rdl"
                                    .Contains(Path.GetExtension(file)))
                                    .ToList();
                if (files.Count > 0)
                {
                    foreach (string s in files)
                    {
                        File.Copy(s, Path.Combine(sourcePath, Path.ChangeExtension(s, ".rdlc")), true);
                        File.Copy(s, Path.Combine(sourcePath, Path.ChangeExtension(s, ".xml")), true);
                    }
                }
            }
        }

    }
}
