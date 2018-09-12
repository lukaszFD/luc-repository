using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;


namespace CA_FilledExcelFile.Core
{
    /// <summary>
    /// If parameter is required then choose "yes"
    /// </summary>
    enum scriptParam
    {
        yes
       , no
    }
    /// <summary>
    /// This class generate data from DB.
    /// </summary>
    class uspScript
    {
        public List<List<string>> script(string sql, string param, scriptParam scriptParam)
        {
            //you can use "Properties.Settings.Default.ConnectionString"
            SqlConnection sqlCon = new SqlConnection(@"Data Source=test;Initial Catalog=test;Integrated Security=True");
            List<List<string>> rezult = new List<List<string>>();
            try
            {
                SqlCommand sqlScript = new SqlCommand(sql, sqlCon);
                sqlScript.CommandType = CommandType.StoredProcedure;
                sqlScript.CommandTimeout = 1000;

                switch (scriptParam)
                {
                    case scriptParam.yes:
                        sqlScript.Parameters.Add("@param", SqlDbType.VarChar, 40).Value = param;
                        break;
                    case scriptParam.no:
                        break;
                    default:
                        break;
                }

                sqlCon.Open();

                SqlDataReader sqlReader = sqlScript.ExecuteReader();

                while (sqlReader.Read())
                {
                    List<string> row = new List<string>();
                    for (int i = 0; i < sqlReader.FieldCount; i++)
                    {
                        row.Add(sqlReader.GetValue(i).ToString());
                    }
                    rezult.Add(row);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlCon.Close();
            }

            return rezult;
        }
    }
}
