using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace ReportViewer
{
    public class SqlServ
    {
        /// <summary>
        /// Stored Procedure.
        /// </summary>
        /// <param name="obj">CancellationToken</param>
        /// <param name="usp_name">Usp name</param>
        /// <returns>DataTable</returns>
        public async Task<DataTable> GetData_USP_Async(object obj, string usp_name)
        {
            CancellationToken ct = (CancellationToken)obj;
            ct.ThrowIfCancellationRequested();
            return await Task.Factory.StartNew(() => GetData_USP(usp_name), ct);
        }
        /// <summary>
        /// Sql script.
        /// </summary>
        /// <param name="obj">CancellationToken</param>
        /// <param name="script">Script</param>
        /// <param name="param">Script param</param>
        /// <returns>DataTable</returns>
        public async Task<DataTable> GetData_Script_Async(object obj, string script, string param)
        {
            CancellationToken ct = (CancellationToken)obj;
            ct.ThrowIfCancellationRequested();
            return await Task.Factory.StartNew(() => GetData_Script(script, param), ct);
        }
        /// <summary>
        /// Sql script.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="script"></param>
        /// <returns>DataTable</returns>
        public async Task<DataTable> GetData_Script_Async(object obj, string script)
        {
            CancellationToken ct = (CancellationToken)obj;
            ct.ThrowIfCancellationRequested();
            return await Task.Factory.StartNew(() => GetData_Script(script), ct);
        }
        private DataTable GetData_USP(string usp_name)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.ReportingConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(usp_name, con);
            cmd.CommandTimeout = 500;
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            return dt;
        }
        private DataTable GetData_Script(string script, string param)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.ReportingConnectionString); 
            con.Open();
            SqlCommand cmd = new SqlCommand(script, con);
            cmd.CommandTimeout = 500;
            cmd.Parameters.Add("@AccountId", SqlDbType.NVarChar, 40).Value = param;
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            return dt;
        }
        private DataTable GetData_Script(string script)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.ReportingConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(script, con);
            cmd.CommandTimeout = 500;
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            return dt;
        }
    }
}
