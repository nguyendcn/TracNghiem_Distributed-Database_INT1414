using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using TracNghiem_CSDLPT.Account;
using System.Data.SqlClient;
using TracNghiem_CSDLPT.Common;

namespace TracNghiem_CSDLPT
{
    public partial class Frm_TN_CSDLPT : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Frm_TN_CSDLPT()
        {
            InitializeComponent();
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_NhapMH frm_NhapMh = new frm_NhapMH();
            frm_NhapMh.MdiParent = this;
            frm_NhapMh.Show();
        }

        private void btn_Khoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frm_NhapKhoa frm_Khoa = new Frm_NhapKhoa();
            frm_Khoa.MdiParent = this;
            frm_Khoa.Show();
        }

        private void btn_Lop_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frm_NhapLop frm_Lop = new Frm_NhapLop();
            frm_Lop.MdiParent = this;
            frm_Lop.Show();
        }

        private void btn_NhapDe_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frm_NhapDe frm_NhapDe = new Frm_NhapDe();
            frm_NhapDe.MdiParent = this;
            frm_NhapDe.Show();
        }

        private void btn_RegisterExam_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frm_DangKyThi frm_DangKyThi = new Frm_DangKyThi();
            frm_DangKyThi.MdiParent = this;
            frm_DangKyThi.Show();
        }

        private void btn_Thi_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frm_CBThi frm_CbThi = new Frm_CBThi();
            frm_CbThi.MdiParent = this;
            frm_CbThi.Show();
        }

        private void btn_Transcript_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frm_ViewTranscript frm_ViewTranscript = new Frm_ViewTranscript();
            frm_ViewTranscript.MdiParent = this;
            frm_ViewTranscript.Show();
        }

        private void btn_RegisterReport_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btn_Logout_ItemClick(object sender, ItemClickEventArgs e)
        {
            if(XtraMessageBox.Show("Bạn có chắc muốn đăng xuất không?"
                , "Confirmation", MessageBoxButtons.YesNo) 
                == DialogResult.Yes)
            {
                try
                {
                    SqlRequestFunction.Logout(Program.mlogin);

                    if(Program.conn.State == ConnectionState.Open)
                    {
                        Program.conn.Close();
                    }

                    this.Dispose();
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không thể đăng xuất. Vui lòng thử lại."
                        , "Lỗi đăng xuất."
                        , MessageBoxButtons.OK
                        , MessageBoxIcon.Error);
                    return;
                }

            }
        }

        private void btn_DeleteAccount_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có chắc muốn xóa tài khoản không?"
               , "Confirmation", MessageBoxButtons.YesNo)
               == DialogResult.Yes)
            {

                try
                {
                    SqlRequestFunction.Logout(Program.mlogin);

                    if (SqlRequestFunction.DeleteAccount(Program.mlogin, Program.username))
                    {
                        if (Program.conn.State == ConnectionState.Open)
                        {
                            Program.conn.Close();
                        }

                        MessageBox.Show("Xóa tài khoản thành công.",
                            "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    this.Dispose();
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không thể đăng xuất. Vui lòng thử lại."
                        , "Lỗi đăng xuất."
                        , MessageBoxButtons.OK
                        , MessageBoxIcon.Error);
                    return;
                }
               

            }
        }

        private void btn_ChangePassword_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frm_ChangePassword frm_ChangePassword = new Frm_ChangePassword();
            frm_ChangePassword.MdiParent = this;

            frm_ChangePassword.Show();
        }

        private void btn_Register_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frm_CreateAccount frm_CreateAccount = new Frm_CreateAccount();
            frm_CreateAccount.MdiParent = this;
            frm_CreateAccount.Show();
        }
    }
}