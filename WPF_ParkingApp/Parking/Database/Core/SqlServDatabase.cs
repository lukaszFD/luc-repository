using System;
using System.Data;
using System.Data.SqlClient;

namespace Parking.Database.Core
{
    class SqlServDatabase
    {
        private SqlConnection SqlCon
        {
            get
            {
                return new SqlConnection("Data Source=sqlServName;Initial Catalog=DB_App;Integrated Security=True");
            }
        }
        private SqlCommand sqlExec(string sql)
        {
            using (var sqlScript = new SqlCommand(sql, SqlCon))
            {
                sqlScript.CommandType = CommandType.StoredProcedure;
                sqlScript.CommandTimeout = 10000;
                return sqlScript;
            }
        }
        public DataTable SelectDataTable(string sql, string param)
        {
            try
            {
                using (var dt = new DataTable())
                {
                    SqlCommand sqlScript = sqlExec(sql);
                    sqlScript.Parameters.Add("@param_1", SqlDbType.NVarChar, 100).Value = param;
                    SqlCon.Open();
                    dt.Load(sqlScript.ExecuteReader());
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlCon.Close();
            }
        }


        public void Script(string sql, string param_1)
        {
            try
            {
                SqlCommand sqlScript = sqlExec(sql);
                sqlScript.Parameters.Add("@param_1", SqlDbType.NVarChar, 100).Value = param_1;
                SqlCon.Open();
                sqlScript.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlCon.Close();
            }
        }
        public void Script(string sql, string param_1, string param_2)
        {
            try
            {
                SqlCommand sqlScript = sqlExec(sql);
                sqlScript.Parameters.Add("@param_1", SqlDbType.NVarChar, 100).Value = param_1;
                sqlScript.Parameters.Add("@param_2", SqlDbType.NVarChar, 100).Value = param_2;
                SqlCon.Open();
                sqlScript.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlCon.Close();
            }
        }
        public void Script(string sql, string param_1, string param_2, string param_3)
        {
            try
            {
                SqlCommand sqlScript = sqlExec(sql);
                sqlScript.Parameters.Add("@param_1", SqlDbType.NVarChar, 100).Value = param_1;
                sqlScript.Parameters.Add("@param_2", SqlDbType.NVarChar, 100).Value = param_2;
                sqlScript.Parameters.Add("@param_3", SqlDbType.NVarChar, 100).Value = param_3;
                SqlCon.Open();
                sqlScript.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlCon.Close();
            }
        }
    }
}
