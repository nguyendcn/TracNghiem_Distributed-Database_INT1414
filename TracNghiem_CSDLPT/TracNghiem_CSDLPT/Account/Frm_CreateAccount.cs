using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TracNghiem_CSDLPT.Common;
using TracNghiem_CSDLPT.Share;

namespace TracNghiem_CSDLPT.Account
{
    public partial class Frm_CreateAccount : DevExpress.XtraEditors.XtraForm
    {
        public Frm_CreateAccount()
        {
            InitializeComponent();

            cmb_Employees.DataSource = SetUpListTeacher();
            cmb_Employees.DisplayMember = "HOTEN";
            cmb_Employees.ValueMember = "MAGV";

            cmb_Role.DataSource = GetListRole(Program.mGroup);
            cmb_Role.DisplayMember = "DESCRIPTION";
            cmb_Role.ValueMember = "SYMBOL";

            lbl_Err_Summary.Text = lbl_Err_Password.Text = lbl_Err_LoginName.Text = lbl_Err_Employee.Text = "";
        }


        private void Frm_CreateAccount_Load(object sender, EventArgs e)
        {
           


        }

        private bool ValidateEmpty()
        {
            bool validate = true;

            if(cmb_Employees.SelectedIndex == -1)
            {
                ErrorHandler.ShowError(lbl_Err_Employee, new string[] { "Ox0001" });
                validate = false;
            }

            if (txt_LoginName.Text.Equals(String.Empty))
            {
                ErrorHandler.ShowError(lbl_Err_LoginName, new string[] { "Ox0001" });
                validate = false;
            }

            if (txt_Password.Text.Equals(String.Empty))
            {
                ErrorHandler.ShowError(lbl_Err_Password, new string[] { "Ox0001" });
                validate = false;
            }

            return validate;
        }

        private DataTable SetUpListTeacher()
        {
            List<object[]> list = SqlRequestFunction.GetListTeacherHadNotAccount();

            DataTable table = new DataTable();

            DataColumn[] columns = new DataColumn[]
            {
                new DataColumn("MAGV"),
                new DataColumn("HOTEN")
            };

            table.Columns.AddRange(columns);

            list.ForEach((item) =>
            {
                DataRow row = table.NewRow();

                row.ItemArray = item;

                table.Rows.Add(item);
            });

            return table;
        }

        private void btn_Register_Click(object sender, EventArgs e)
        {
            if (ValidateEmpty())
            {
                int code = SqlRequestFunction.CreateAccount(txt_LoginName.Text
                    , cmb_Employees.SelectedValue.ToString()
                    , txt_Password.Text
                    , cmb_Role.SelectedValue.ToString());

                switch (code)
                {
                    case 15014: //Role does not exists
                        ErrorHandler.ShowError(lbl_Err_Summary, new string[] { "Ox6001" });
                        break;
                    case 15025: //login name exists
                        ErrorHandler.ShowError(lbl_Err_LoginName, new string[] { "Ox6002" });
                        break;
                    case 15023: //user name exists
                        ErrorHandler.ShowError(lbl_Err_Employee, new string[] { "Ox6003" });
                        break;

                    default:
                        MessageBox.Show(
                            "Đã tạo tài khoản thành công cho giáo viên: " 
                            + cmb_Employees.Text 
                            + "Với tài khảo đăng nhập: " 
                            + txt_LoginName.Text
                            , "Success"
                            ,MessageBoxButtons.OK
                            ,MessageBoxIcon.Information);
                        break;
                }
            }
        }

        private DataTable GetListRole(String role)
        {
            DataTable table = new DataTable();

            DataColumn column = new DataColumn("SYMBOL");
            table.Columns.Add(column);
            column = new DataColumn("DESCRIPTION");
            table.Columns.Add(column);

            DataRow row;

            if (role.Equals("COSO"))
            {
                row = table.NewRow();
                row.ItemArray = new object[] { "GIANGVIEN", "Giảng Viên" };
                table.Rows.Add(row);

                row = table.NewRow();
                row.ItemArray = new object[] { "COSO", "Cơ Sở" };
                table.Rows.Add(row);
            }
            else if(role.Equals("SINHVIEN"))
            {
                row = table.NewRow();
                row.ItemArray = new object[] { "SINHVIEN", "Sinh Viên" };
                table.Rows.Add(row);
            }
            else if (role.Equals("GIANGVIEN"))
            {
                row = table.NewRow();
                row.ItemArray = new object[] { "GIANGVIEN", "Giảng Viên" };
                table.Rows.Add(row);
            }
            else if (role.Equals("TRUONG"))
            {
                row = table.NewRow();
                row.ItemArray = new object[] { "TRUONG", "Trường" };
                table.Rows.Add(row);
            }

            return table;
        }

        private void UpdateInfo()
        {
            txt_LoginName.Text = txt_Password.Text = "";

            cmb_Employees.DataSource = SetUpListTeacher();
            cmb_Employees.DisplayMember = "HOTEN";
            cmb_Employees.ValueMember = "MAGV";
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}