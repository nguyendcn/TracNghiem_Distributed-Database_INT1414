using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Replication;
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

        public static bool DepartmentIsExist(String departmentCode)
        {
            SqlDataReader reader = ExecSqlDataReader("Exec sp_CheckDepartmentExists '" + departmentCode + "'");

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

        public static void SysPublication()
        {
            // Define the server, publication, and database names.
            string subscriberName = "NGUYEN-PC\\SQLSERVER_1";
            string publisherName = "NGUYEN-PC";
            string publicationName = "TN_CSDLPT_CS1";
            string subscriptionDbName = "TN_CSDLPT";
            string publicationDbName = "TN_CSDLPT";

            // Create a connection to the Publisher.
            ServerConnection conn = new ServerConnection(publisherName);

            MergeSubscription subscription;

            try
            {
                // Connect to the Publisher
                conn.Connect();

                // Define the subscription.
                subscription = new MergeSubscription();
                subscription.ConnectionContext = conn;
                subscription.DatabaseName = publicationDbName;
                subscription.PublicationName = publicationName;
                subscription.SubscriptionDBName = subscriptionDbName;
                subscription.SubscriberName = subscriberName;

                // If the push subscription exists, start the synchronization.
                if (subscription.LoadProperties())
                {
                    // Check that we have enough metadata to start the agent.
                    if (subscription.SubscriberSecurity != null)
                    {
                        // Synchronously start the Merge Agent for the subscription.
                        subscription.SynchronizationAgent.Synchronize();
                    }
                    else
                    {
                        throw new ApplicationException("There is insufficent metadata to " +
                            "synchronize the subscription. Recreate the subscription with " +
                            "the agent job or supply the required agent properties at run time.");
                    }
                }
                else
                {
                    // Do something here if the push subscription does not exist.
                    throw new ApplicationException(String.Format(
                        "The subscription to '{0}' does not exist on {1}",
                        publicationName, subscriberName));
                }
            }
            catch (Exception ex)
            {
                // Implement appropriate error handling here.
                throw new ApplicationException("The subscription could not be synchronized.", ex);
            }
            finally
            {
                conn.Disconnect();
            }
        }

    }
}
