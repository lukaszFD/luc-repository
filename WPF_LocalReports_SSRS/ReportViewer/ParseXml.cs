using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace ReportViewer
{
    public class ParseXml
    {
        /// <summary>
        /// Return DataSet and sql script from xml.
        /// </summary>
        /// <param name="obj">CancellationToken</param>
        /// <param name="pathToXml">Path to xml file</param>
        /// <returns>DataTable</returns>
        public async Task<DataTable> Data_Async(object obj, string pathToXml)
        {
            CancellationToken ct = (CancellationToken)obj;
            ct.ThrowIfCancellationRequested();
            return await Task.Factory.StartNew(() => Data(pathToXml), ct);
        }
        private DataTable Data(string pathToXml)
        {
            XmlTextReader xtr = new XmlTextReader(pathToXml);

            Dictionary<int, string> dictDataSet = new Dictionary<int, string>();
            Dictionary<int, string> dictCommandText = new Dictionary<int, string>();
            DataTable dt = new DataTable();
            dt.Columns.Add("DataSet");
            dt.Columns.Add("CommandText");
            DataRow dr = null;

            int i = 1;
            int j = 1;
            while (xtr.Read())
            {
                if (xtr.NodeType == XmlNodeType.Element && xtr.Name == "DataSet")
                {
                    dictDataSet.Add(i++, xtr.GetAttribute("Name"));
                }

                if (xtr.NodeType == XmlNodeType.Element && xtr.Name == "CommandText")
                {
                    dictCommandText.Add(j++, xtr.ReadElementString());
                }
            }
            var result = from
                         a in dictDataSet
                         join
                         b in dictCommandText on a.Key equals b.Key
                         select new
                         {
                             value1 = a.Value
                             ,
                             value2 = b.Value
                         };

            foreach (var item in result)
            {
                dr = dt.NewRow();
                dr[0] = item.value1;
                dr[1] = item.value2;
                dt.Rows.Add(dr);
            }
            return dt;
        }
    }
}
