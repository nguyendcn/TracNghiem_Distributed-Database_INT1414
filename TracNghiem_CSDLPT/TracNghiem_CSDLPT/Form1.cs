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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Program.conn.ConnectionString = SqlString.ConnectionRootServerString; 
            Program.conn.Open();
            DataTable dt = new DataTable();
            dt = Program.ExecSqlDataTable("SELECT * FROM V_DS_PHANMANH");
            Program.bds_dspm.DataSource = dt;
            cmb_CoSo.DataSource = dt;
            cmb_CoSo.DisplayMember = "TENCOSO";
            cmb_CoSo.ValueMember = "TENSERVER";
            cmb_CoSo.SelectedIndex = -1;
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            if (txt_Username.Text.Trim() == "" || txt_Password.Text.Trim() == "")
            {
                MessageBox.Show("Login name và mật mã không được trống", "", MessageBoxButtons.OK);
                return;
            }
            Program.mlogin = txt_Username.Text; Program.password = txt_Password.Text;
            if (Program.KetNoi() == 0) return;

            Program.mChinhanh = cmb_CoSo.SelectedIndex;

            Program.mloginDN = Program.mlogin;
            Program.passwordDN = Program.password;
            string strLenh = "EXEC SP_THONGTINDANGNHAP '" + Program.mlogin + "'";

            Program.myReader = Program.ExecSqlDataReader(strLenh);
            if (Program.myReader == null) return;
            Program.myReader.Read();


            Program.username = Program.myReader.GetString(0);     // Lay user name
            if (Convert.IsDBNull(Program.username))
            {
                MessageBox.Show("Login bạn nhập không có quyền truy cập dữ liệu\n Bạn xem lại username, password", "", MessageBoxButtons.OK);
                return;
            }
            Program.mHoten = Program.myReader.GetString(1);
            Program.mGroup = Program.myReader.GetString(2);
            Program.myReader.Close();
            Program.conn.Close();
            MessageBox.Show("Nhan vien - Nhom : " + Program.mHoten + " - " + Program.mGroup, "", MessageBoxButtons.OK);
        }

        private void cmb_CoSo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Program.servername = cmb_CoSo.SelectedValue.ToString();

            }
            catch (Exception) { };
        }
    }
}
