﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Utils
{
    class CSV
    {
        public string DataTableToCSV(DataTable dataTable)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Load(dataTable.CreateDataReader());
                StringBuilder sb = new StringBuilder();
                IEnumerable<string> columnNames = dt.Columns.Cast<DataColumn>().Select(column => column.ColumnName);

                sb.AppendLine(string.Join(";", columnNames));

                foreach (DataRow row in dt.Rows)
                {
                    IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                    sb.AppendLine(string.Join(";", fields));
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
