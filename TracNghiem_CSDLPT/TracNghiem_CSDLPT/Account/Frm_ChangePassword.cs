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
using TracNghiem_CSDLPT.Share;
using TracNghiem_CSDLPT.Common;

namespace TracNghiem_CSDLPT.Account
{
    public partial class Frm_ChangePassword : DevExpress.XtraEditors.XtraForm
    {
        public Frm_ChangePassword()
        {
            InitializeComponent();

            lbl_Err_NewPassword.Text = lbl_Err_OldPassword.Text = lbl_Err_RepeatNewPassword.Text = lbl_Err_Summary.Text = "";
        }

        private void btn_ChagePassword_Click(object sender, EventArgs e)
        {
            if (!ValidateField())
            {
                return;
            }

            bool changeIsSuccess = ChangePassword(Program.mlogin, txt_NewPassword.Text, txt_OldPassword.Text);

             if (changeIsSuccess)
            {

                ChangeConnectionString(txt_NewPassword.Text);

                XtraMessageBox.Show("Thay đổi mật khẩu thành công."
                    , "Password had changed!"
                    , MessageBoxButtons.OK);

                return;
            }
            else
            {
                XtraMessageBox.Show("Không thể đổi mật khẩu vì mật khẩu cũ không chính xác."
                    , "Password did not changed!"
                    , MessageBoxButtons.OK);

                return;
            }
        }


        private bool ValidateField()
        {
            bool validate = true;

            validate = ValidateEmpty();

            if (validate)
            {
                validate = ValidateValue();

                if (validate)
                {
                    validate = ValidateOldPassword(txt_OldPassword.Text);
                }

            }

            return validate;
        }

        private bool ValidateEmpty()
        {
            bool validate = true;

            if (txt_OldPassword.Text.Equals(String.Empty))
            {
                ErrorHandler.ShowError(lbl_Err_OldPassword, new string[] {"Ox001" });
                validate = false;
            }

            if (txt_NewPassword.Text.Equals(String.Empty))
            {
                ErrorHandler.ShowError(lbl_Err_NewPassword, new string[] { "Ox001" });
                validate = false;
            }


            if (txt_RepeatNewPassword.Text.Equals(String.Empty))
            {
                ErrorHandler.ShowError(lbl_Err_RepeatNewPassword, new string[] { "Ox001" });
                validate = false;
            }

            return validate;
        }

        private bool ValidateValue()
        {
            bool validate = true;

            if(txt_NewPassword.Text == txt_OldPassword.Text)
            {
                ErrorHandler.ShowError(lbl_Err_NewPassword, new string[] { "Ox001" });
                validate = false;
            }

            if((txt_NewPassword.Text != txt_RepeatNewPassword.Text))
            {
                ErrorHandler.ShowError(lbl_Err_RepeatNewPassword, new string[] { "Ox001" });
                validate = false;
            }

            return validate;
        }

        private bool ValidateOldPassword(String oldPassword)
        {
            bool validate = true;

            if (!OldPasswordIsTrue(oldPassword))
            {
                ErrorHandler.ShowError(lbl_Err_OldPassword, new string[] { "Ox001" });
                this.ActiveControl = txt_OldPassword;
                validate = false;
            }

            return validate;
        }

        private bool OldPasswordIsTrue(String oldPassword)
        {
            return true;
        }

        private bool ChangePassword(String loginName, String newPassword, String oldPassword)
        {
            return SqlRequestFunction.ChangePassword(loginName, newPassword, oldPassword);
        }

        private void ChangeConnectionString(String newPassword)
        {
            int length = Program.connstr.LastIndexOf("password=") + "password=".Length;
            String str = Program.connstr.Substring(0, length);

            Program.connstr = str + newPassword;

            if (Program.conn.State == ConnectionState.Open)
            {
                Program.conn.Close();
                Program.conn.ConnectionString = Program.connstr;
                Program.conn.Open();
            }
            else
            {
                Program.conn.ConnectionString = Program.connstr;
            }
        }
    }
}