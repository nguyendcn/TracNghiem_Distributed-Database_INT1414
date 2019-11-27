using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TracNghiem_CSDLPT.Common
{
    public static class SqlRequestFunction
    {

        /// <summary>
        /// Get all brands.
        /// </summary>
        /// <returns>Data table contant result</returns>
        public static DataTable GetListBrand()
        {
            Program.conn.ConnectionString = SqlString.ConnectionRootServerString;
            Program.conn.Open();
            DataTable dt = new DataTable();
            dt = Program.ExecSqlDataTable("SELECT * FROM V_DS_PHANMANH");
            Program.bds_ListBrand.DataSource = dt;

            return dt;
        }

        public static bool StudentIsExist(String studentCode)
        {
            SqlDataReader reader = ExecSqlDataReader("Exec sp_CheckStudentExists '" + studentCode + "'");

            while (reader.Read())
            {
                String result = reader.GetString(0);

                if (result.Equals("1"))
                {
                    reader.Close(); // <- too easy to forget
                    reader.Dispose(); // <- too easy to forget
                    return true;
                }
            }
            reader.Close(); // <- too easy to forget
            reader.Dispose(); // <- too easy to forget
            return false;
        }

        public static List<int> GetListQuestionCode()
        {
            List<int> lCode = new List<int>();

            SqlDataReader reader = ExecSqlDataReader("Exec sp_GetListQuestionCode");

            while (reader.Read())
            {
                lCode.Add(reader.GetInt32(0));
            }
            reader.Close(); // <- too easy to forget
            reader.Dispose(); // <- too easy to forget
            return lCode;
        }


        /// <summary>
        /// Execuse query  by SqlCommand
        /// </summary>
        /// <param name="strQuery"></param>
        /// <returns>Results by DataReader</returns>
        public static SqlDataReader ExecSqlDataReader(String strQuery)
        {
            SqlDataReader myreader;
            SqlCommand sqlcmd = new SqlCommand(strQuery, Program.conn);
            sqlcmd.CommandType = CommandType.Text;
            if (Program.conn.State == ConnectionState.Closed) Program.conn.Open();
            try
            {
                myreader = sqlcmd.ExecuteReader(); return myreader;

            }
            catch (SqlException ex)
            {
                Program.conn.Close();;
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

    }
}
