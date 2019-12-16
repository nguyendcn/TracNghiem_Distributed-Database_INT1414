using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TracNghiem_CSDLPT.Share
{
    public static class ErrorCode
    {
        public static String Ox0001 = "Trường dữ liệu khôn được bỏ trống.";
        public static String Ox1001 = "Mã môn học đã tồn tại.";
        public static String Ox1002 = "Mã môn học không hợp lệ.";
        public static String Ox1003 = "Mã";

        public static String GetPropertyValue(String propName)
        {
            Type type = typeof(ErrorCode);

            foreach (var field in type.GetFields())
            {
                if (field.Name.Equals(propName))
                    return field.GetValue(null).ToString();
            }
            return String.Empty;
        }
    }
}
