using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracNghiem_CSDLPT.Common
{
    public static class SqlString
    {
        public const String ConnectionRootServerString = "Data Source=NGUYEN-PC;Initial Catalog=TN_CSDLPT;Integrated Security=True";

        public static String GetQueryChangePassword(String loginName, String oldPassword, String newPassword)
        {
            return "ALTER LOGIN " + loginName  + " WITH PASSWORD = '" + newPassword + "' OLD_PASSWORD = '" + oldPassword + "'";
        }
    }
}
