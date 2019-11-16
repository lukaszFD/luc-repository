using System;
using System.IO;
using System.Linq;

namespace Utils
{
    public class Deletefiles
    {
        public void Days(string dirName, int days)
        {
            string[] files = Directory.GetFiles(dirName);

            foreach (string file in files)
            {
                FileInfo fi = new FileInfo(file);
                if (fi.LastAccessTime < DateTime.Now.AddDays(-days))
                {
                    fi.Delete();
                }
            }
        }
        public void Months(string dirName, int months)
        {
            string[] files = Directory.GetFiles(dirName);

            foreach (string file in files)
            {
                FileInfo fi = new FileInfo(file);
                if (fi.LastAccessTime < DateTime.Now.AddMonths(-months))
                    fi.Delete();
            }
        }

        public void MonthsLinq(string dirName, int months)
        {
            Directory.GetFiles(dirName)
                     .Select(f => new FileInfo(f))
                     .Where(f => f.LastAccessTime < DateTime.Now.AddMonths(-months))
                     .ToList()
                     .ForEach(f => f.Delete());
        }
    }
}
