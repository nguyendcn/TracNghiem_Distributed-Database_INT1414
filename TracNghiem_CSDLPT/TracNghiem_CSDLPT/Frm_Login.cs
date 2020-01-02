using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TracNghiem_CSDLPT.Common;
using TracNghiem_CSDLPT.Share;

namespace TracNghiem_CSDLPT
{
    public partial class Frm_Login : Form
    {
        public Frm_Login()
        {
            InitializeComponent();

            InitDataForCmbBrand();

            lbl_Error_GV.Text = lbl_Error_SV.Text = "";
        }

        #region Function

        private void InitDataForCmbBrand()
        {
            SqlRequestFunction.GetListBrand();

            cmb_Brand_SV.DataSource = Program.bds_ListBrand;
            cmb_Brand_SV.DisplayMember = "TENCOSO";
            cmb_Brand_SV.ValueMember = "TENSERVER";

            cmb_Brand_GV.DataSource = Program.bds_ListBrand;
            cmb_Brand_GV.DisplayMember = "TENCOSO";
            cmb_Brand_GV.ValueMember = "TENSERVER";

            cmb_Brand_SV.SelectedIndex = -1;
            cmb_Brand_GV.SelectedIndex = -1;

            cmb_Brand_GV.Text = "Chọn cơ sở";
            cmb_Brand_SV.Text = "Chọn cơ sở";
        }

        private bool CheckValidateLogin(int indexBrand, String studentCode)
        {
            bool validate = true;
            if (indexBrand == -1)
            {
                ErrorHandler.ShowError(lbl_Error_SV, new string[] { "OxB001" });
                validate = false;
            }
            if (studentCode.Trim().Equals(String.Empty))
            {
                ErrorHandler.ShowError(lbl_Error_SV, new string[] { "OxB002" });
                validate = false;
            }

            return validate;
        }

        private bool CheckValidateLogin(int indexBrand, String userName, String password)
        {
            bool validate = true;
            if (indexBrand == -1)
            {
                ErrorHandler.ShowError(lbl_Error_GV, new string[] { "OxB001" });
                validate = false;
            }
            if (userName.Trim().Equals(String.Empty))
            {
                ErrorHandler.ShowError(lbl_Error_GV, new string[] { "OxB003" });
                validate = false;
            }
            if (password.Trim().Equals(String.Empty))
            {
                ErrorHandler.ShowError(lbl_Error_SV, new string[] { "OxB004" });
                validate = false;
            }

            return validate;
        }

        #endregion

        private void btn_SV_Click(object sender, EventArgs e)
        {
            pnl_GV.Visible = false;
            pnl_SV.Visible = true;
            pnl_SV.BringToFront();
            btn_SV.BringToFront();
            btn_GV.SendToBack();

            btn_SV.BackColor = Color.SandyBrown;
            btn_GV.BackColor = Color.PeachPuff;
        }

        private void btn_GV_Click(object sender, EventArgs e)
        {
            pnl_SV.Visible = false;
            pnl_GV.Visible = true;
            pnl_GV.BringToFront();
            btn_SV.SendToBack();
            btn_GV.BringToFront();

            btn_GV.BackColor = Color.SandyBrown;
            btn_SV.BackColor = Color.PeachPuff;
        }

        private void btn_Login_SV_Click(object sender, EventArgs e)
        {
            bool checkVal = CheckValidateLogin(cmb_Brand_SV.SelectedIndex, txt_StudentCode.Text);

            if (!checkVal)
            {
                return;
            }

            //Start login
            Program.studentCode = txt_StudentCode.Text;
            Program.mlogin = "student"; Program.password = "nguyenne";
            if (Program.KetNoi() == 0) return;

            Program.mChinhanh = ((DataRowView)cmb_Brand_SV.SelectedItem).Row.ItemArray[0].ToString();

            Program.mloginDN = Program.mlogin;
            Program.passwordDN = Program.password;
            string strLenh = "EXEC SP_THONGTINDANGNHAPSV '" + Program.studentCode + "'";

            Program.myReader = SqlRequestFunction.ExecSqlDataReader(strLenh);
            if (Program.myReader == null) return;
            Program.myReader.Read();


            Program.username = Program.myReader.GetString(0);     // Lay name
            if (Convert.IsDBNull(Program.username))
            {
                MessageBox.Show("Sinh viên không tồn tại.", "", MessageBoxButtons.OK);
                return;
            }
            Program.mHoten = Program.myReader.GetString(1);
            Program.mGroup = Program.myReader.GetString(2);
            Program.myReader.Close();
            Program.conn.Close();
            MessageBox.Show("Sinh Viên " + Program.mHoten
                , "Đăng nhập thành công!"
                , MessageBoxButtons.OK
                , MessageBoxIcon.Information);

            Frm_TN_CSDLPT frm_Tn_csdlpt = new Frm_TN_CSDLPT();
            frm_Tn_csdlpt.Show();
        }

        private void cmb_Brand_SV_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Program.servername = cmb_Brand_SV.SelectedValue.ToString();

            }
            catch (Exception) { };
        }

        private void btn_Login_GV_Click(object sender, EventArgs e)
        {
            bool checkVal = CheckValidateLogin(cmb_Brand_GV.SelectedIndex, txt_UserName.Text, txt_Password.Text);

            if (!checkVal)
            {
                return;
            }

            //Start login
            Program.mlogin = txt_UserName.Text; Program.password = txt_Password.Text;
            if (Program.KetNoi() == 0) return;

            Program.mChinhanh = ((DataRowView)cmb_Brand_GV.SelectedItem).Row.ItemArray[0].ToString();

            Program.mloginDN = Program.mlogin;
            Program.passwordDN = Program.password;
            string strLenh = "EXEC SP_THONGTINDANGNHAPGV '" + Program.mloginDN + "'";

            Program.myReader = SqlRequestFunction.ExecSqlDataReader(strLenh);
            if (Program.myReader == null) return;
            Program.myReader.Read();


            Program.username = Program.myReader.GetString(0);     // Lay user name
            if (Convert.IsDBNull(Program.username))
            {
                MessageBox.Show("Giáo viên không tồn tại.", "", MessageBoxButtons.OK);
                return;
            }
            Program.mHoten = Program.myReader.GetString(1);
            Program.mGroup = Program.myReader.GetString(2);
            Program.myReader.Close();
            Program.conn.Close();
            MessageBox.Show("Nhân viên - Nhóm : " + Program.mHoten + " - " + Program.mGroup
                , "Đăng nhập thành công!"
                , MessageBoxButtons.OK, MessageBoxIcon.Information);


            //Application.Run(new Frm_TN_CSDLPT());
            //this.Dispose();
            Frm_TN_CSDLPT frm_Tn_csdlpt = new Frm_TN_CSDLPT();
            frm_Tn_csdlpt.Show();
            //this.Visible = false;
        }

        private void cmb_Brand_GV_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Program.servername = cmb_Brand_GV.SelectedValue.ToString();

            }
            catch (Exception) { };
        }
    }
}
