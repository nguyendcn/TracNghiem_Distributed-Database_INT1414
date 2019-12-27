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
using TracNghiem_CSDLPT.Share;

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

            return CodeIsExist("sp_CheckStudentExists", studentCode);
        }

        public static bool DepartmentIsExist(String departmentCode)
        {
            return CodeIsExist("sp_CheckDepartmentExists", departmentCode);
        }

        public static bool ClassIsExist(String classCode)
        {
            return CodeIsExist("sp_CheckClassExists", classCode);
        }

        public static bool TeacherIsExists(String teacherCode)
        {
            return CodeIsExist("sp_CheckTecherExists", teacherCode);
        }

        public static bool RegisterIsExists(String classCode, String courseCode, int time)
        {
            String code = classCode + "', '" + courseCode + "', '" + time;
            return CodeIsExist("sp_CheckRegisterIsExists", code);
        }

        public static bool HasBeenExamined(String studentCode, String courseCode, int timesStep)
        {
            String code = studentCode + "', '" + courseCode + "', '" + timesStep;
            String sp = "sp_HasBeenExamined";

            return CodeIsExist(sp, code);
        }

        private static bool CodeIsExist(String sp, String code)
        {
            String query = "Exec " + sp + " '" + code + "'";
            SqlDataReader reader = ExecSqlDataReader(query);

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

        public static bool IsEnoughQuestion(String courseCode, String level, int quantity)
        {
            String val = String.Empty;
            bool isEnough = true;

            String query = "Exec sp_GetQuestion '" + courseCode + "', '" + level + "', '" + quantity + "'";
            SqlDataReader reader = ExecSqlDataReader(query);

            try
            {
                if (reader.Read())
                {
                    int temp = reader.GetInt32(0);
                }

                
            }
            catch (Exception)
            {
                isEnough = false;
            }

            reader.Close(); // <- too easy to forget
            reader.Dispose(); // <- too easy to forget

            return isEnough;
        }

        public static StudentInfo GetStudentInfo(String studentCode)
        {
            String query = "Exec sp_GetInfoStudent'" + studentCode + "'";
            SqlDataReader reader = ExecSqlDataReader(query);

            if (reader.Read())
            {
                StudentInfo studentInfo = new StudentInfo
                {
                    FullName = reader.GetString(0),
                    ClassCode = reader.GetString(1),
                    ClassName = reader.GetString(2)
                };

                reader.Close(); // <- too easy to forget
                reader.Dispose(); // <- too easy to forget

                return studentInfo;
            }
            return null;
        }

        public static List<ExamTest> GetQuestionForTestExam(String courseCode, String level, int quantity)
        {
            String query = "Exec sp_GetQuestion'" + courseCode + "', '" + level + "', " + quantity;
            SqlDataReader reader = ExecSqlDataReader(query);

            List<ExamTest> listExam = new List<ExamTest>();

            while (reader.Read())
            {
                ExamTest exam = new ExamTest
                {
                    QuestionCode = reader.GetInt32(0),
                    QuestionContent = reader.GetString(1),
                    A = reader.GetString(2),
                    B = reader.GetString(3),
                    C = reader.GetString(4),
                    D = reader.GetString(5),
                    TrueAnswer = reader.GetString(6),
                    YourAnswer = String.Empty
                };
                listExam.Add(exam);
            }

            reader.Close(); // <- too easy to forget
            reader.Dispose(); // <- too easy to forget

            return listExam;
        }

        public static List<Transcript> GetTranscript(String classCode, String courseCode, int timesStep)
        {
            String query = "Exec sp_GetTranscript '" + classCode + "', '" + courseCode + "', " + timesStep;
            SqlDataReader reader = ExecSqlDataReader(query);

            List<Transcript> listTranscript = new List<Transcript>();

            while (reader.Read())
            {
                String sc = reader.GetString(0);
                String fn = reader.GetString(1);
                double m = reader.GetDouble(2);

                Transcript transcript = new Transcript
                {
                    StudentCode = sc,
                    FullName = fn,
                    Marks = (float)m
                };

                listTranscript.Add(transcript);
            }

            reader.Close(); // <- too easy to forget
            reader.Dispose(); // <- too easy to forget

            return listTranscript;
        }

        public static bool ChangePassword(String loginName, String oldPassword, String newPassword)
        {
            String query = SqlString.GetQueryChangePassword(loginName, newPassword, oldPassword);

            try
            {
                SqlDataReader reader = ExecSqlDataReader(query);
                if (reader != null)
                    return true;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }

            return false;
        }

        public static bool DeleteAccount(String loginName, String userName)
        {
            String query = "Exec sp_XoaTaiKhoan '" + loginName + "', '" + userName + "'";

            try
            {
                SqlDataReader reader = ExecSqlDataReader(query);
                if (reader != null)
                    return true;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }

            return false;
        }

        public static int CreateAccount(String loginName, String userName, String password, String role)
        {
            String query = "Exec sp_TaoTaiKhoan '" + loginName + "', '" + password + "', '"  + userName + "', '" + role + "'";

            SqlDataReader myreader;
            SqlCommand sqlcmd = new SqlCommand(query, Program.conn);
            sqlcmd.CommandType = CommandType.Text;
            if (Program.conn.State == ConnectionState.Closed) Program.conn.Open();
            try
            {
                myreader = sqlcmd.ExecuteReader();

                return 1;
            }
            catch (SqlException ex)
            {
                Program.conn.Close(); ;
                Debug.WriteLine(ex.Message);
                return ex.Number;
            }
        }

        public static List<object[]> GetListTeacherHadNotAccount()
        {
            string query = "Exec sp_GetListTeacherHadNotAccount";

            SqlDataReader reader = ExecSqlDataReader(query);

            List<object[]> list = new List<object[]>();

            while (reader.Read())
            {
                object []info = new object[]
                {
                   reader.GetString(0),
                   reader.GetString(1),
                };

                list.Add(info);
            }
            reader.Close(); // <- too easy to forget
            reader.Dispose(); // <- too easy to forget

            return list;
        }

        public static void Logout(String loginName)
        {
            string query = "Exec sp_LogOut '" + loginName + "'";

            SqlDataReader reader = ExecSqlDataReader(query);
            if (reader != null)
            {
                reader.Close(); // <- too easy to forget
                reader.Dispose(); // <- too easy to forget
            }
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
