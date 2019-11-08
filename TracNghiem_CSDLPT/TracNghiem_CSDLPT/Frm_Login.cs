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

namespace TracNghiem_CSDLPT
{
    public partial class Frm_Login : Form
    {
        public Frm_Login()
        {
            InitializeComponent();

            InitDataForCmbBrand();

            txt_UserName.Text = "TUYET";
            txt_Password.Text = "nguyenne";
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

        private String CheckValidateLogin(int indexBrand, String studentCode)
        {
            if (indexBrand == -1)
                return "Vui lòng chọn cơ sở.";
            if (studentCode.Trim().Equals(String.Empty))
                return "Mã sinh viên không được để trống.";
            return String.Empty;
        }

        private String CheckValidateLogin(int indexBrand, String userName, String password)
        {
            if (indexBrand == -1)
                return "Vui lòng chọn cơ sở.";
            if (userName.Trim().Equals(String.Empty))
                return "Tên tài khoản không được để trống.";
            if (password.Trim().Equals(String.Empty))
                return "Mật khẩu không được để trống.";
            return String.Empty;
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
            String checkVal = CheckValidateLogin(cmb_Brand_SV.SelectedIndex, txt_StudentCode.Text);

            if (!checkVal.Equals(String.Empty))
            {
                lbl_Error_SV.Text = checkVal;
                return;
            }

            //Start login
            Program.studentCode = txt_StudentCode.Text;
            Program.mlogin = "student"; Program.password = "nguyenne";
            if (Program.KetNoi() == 0) return;

            Program.mChinhanh = cmb_Brand_SV.SelectedIndex;

            Program.mloginDN = Program.mlogin;
            Program.passwordDN = Program.password;
            string strLenh = "EXEC SP_THONGTINDANGNHAPSV '" + Program.studentCode + "'";

            Program.myReader = SqlRequestFunction.ExecSqlDataReader(strLenh);
            if (Program.myReader == null) return;
            Program.myReader.Read();


            Program.username = Program.myReader.GetString(0);     // Lay name
            if (Convert.IsDBNull(Program.username))
            {
                MessageBox.Show("Ma Sinh Vien khong ton tai.", "", MessageBoxButtons.OK);
                return;
            }
            Program.mHoten = Program.myReader.GetString(1);
            Program.mGroup = Program.myReader.GetString(2);
            Program.mChinhanh = cmb_Brand_GV.SelectedIndex + 1;
            Program.myReader.Close();
            Program.conn.Close();
            MessageBox.Show("Nhan vien - Nhom : " + Program.mHoten + " - " + Program.mGroup, "", MessageBoxButtons.OK);

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
            String checkVal = CheckValidateLogin(cmb_Brand_GV.SelectedIndex, txt_UserName.Text, txt_Password.Text);

            if (!checkVal.Equals(String.Empty))
            {
                lbl_Error_GV.Text = checkVal;
                return;
            }

            //Start login
            Program.mlogin = txt_UserName.Text; Program.password = txt_Password.Text;
            if (Program.KetNoi() == 0) return;

            Program.mChinhanh = cmb_Brand_SV.SelectedIndex;

            Program.mloginDN = Program.mlogin;
            Program.passwordDN = Program.password;
            string strLenh = "EXEC SP_THONGTINDANGNHAPGV '" + Program.mloginDN + "'";

            Program.myReader = SqlRequestFunction.ExecSqlDataReader(strLenh);
            if (Program.myReader == null) return;
            Program.myReader.Read();


            Program.username = Program.myReader.GetString(0);     // Lay user name
            if (Convert.IsDBNull(Program.username))
            {
                MessageBox.Show("User khong ton tai.", "", MessageBoxButtons.OK);
                return;
            }
            Program.mHoten = Program.myReader.GetString(1);
            Program.mGroup = Program.myReader.GetString(2);
            Program.mChinhanh = cmb_Brand_GV.SelectedIndex;
            Program.myReader.Close();
            Program.conn.Close();
            MessageBox.Show("Nhan vien - Nhom : " + Program.mHoten + " - " + Program.mGroup, "", MessageBoxButtons.OK);


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
