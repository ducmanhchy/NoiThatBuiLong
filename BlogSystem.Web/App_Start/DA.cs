using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using BlogSystem.Data;

namespace BlogSystem.Web.App_Start
{
    public class DA
    {
        private static string ConnectionString
        {
            get
            {
                try
                {
                    return ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static DataTable FillDataTableSQL(string p_strSQLCommand)
        {
            //bool includeReturnValueParameter = true;
            DataTable p_dtData = new DataTable();
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            try
            {
                PrepareCommandSQL(cmd, conn, (SqlTransaction)null, p_strSQLCommand);
                da.Fill(p_dtData);
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                cmd.Dispose();
                da.Dispose();
                p_dtData.Dispose();
            }

            return p_dtData;
        }

        private static void PrepareCommandSQL(SqlCommand p_cmd, SqlConnection p_conn,
            SqlTransaction p_trans, string p_strSQLCommand)
        {
            //if the provided connection is not open, we will open it
            if (p_conn.State != ConnectionState.Open)
            {
                p_conn.Open();
            }

            //associate the connection with the command
            p_cmd.Connection = p_conn;

            //set the command text (SQL statement)
            p_cmd.CommandText = p_strSQLCommand;

            //if we were provided a transaction, assign it.
            if (p_trans != null)
            {
                p_cmd.Transaction = p_trans;
            }

            //set the command type
            p_cmd.CommandType = CommandType.Text;
        }
    }
}