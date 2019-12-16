using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracNghiem_CSDLPT.Share
{
    public static class StringLibrary
    {
        public static String R_Delete = "Bạn có muốn phục hồi dữ liệu đã xóa không?";
        public static String R_Add = "Bạn có muốn phục hồi dữ liệu đã thêm không?";
        public static String R_Edit = "Bạn có muốn phục hồi dữ liệu đã sửa không?";

        public static String DEL = "Delete";
        public static String D_Delete = "Bạn có muốn xóa dữ liệu này không?";
        public static String D_Success = "Xóa dữ liệu thành công.";

        public static String A_Add = "Bạn có muốn thêm dữ liệu này không?";
        public static String A_Success = "Đã thêm dữ liệu thành công.";

        public static String EDIT = "Bạn có chắc muốn sửa dữ liệu này không?";
        public static String E_EditEmpty = "Vui lòng chọn bản ghi muốn sửa.";
        public static String E_EditNotify = "Sửa dữ liệu.";
        public static String E_EditSuccess = "Sửa dữ liệu thành công.";


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
