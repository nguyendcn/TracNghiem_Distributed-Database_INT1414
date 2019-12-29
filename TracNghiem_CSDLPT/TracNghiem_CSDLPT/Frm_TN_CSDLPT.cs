using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using TracNghiem_CSDLPT.Account;
using TracNghiem_CSDLPT.Common;

namespace TracNghiem_CSDLPT
{
    public partial class Frm_TN_CSDLPT : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Frm_TN_CSDLPT()
        {
            InitializeComponent();

            DeniceFeatureByRole();
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
            XtraReport1 report = new XtraReport1("CS1", "2019-12-12", "2019-12-29");

            ReportPrintTool tool = new ReportPrintTool(report);

            tool.ShowPreviewDialog();
        }

        private void btn_Logout_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có chắc muốn đăng xuất không?"
                , "Confirmation", MessageBoxButtons.YesNo)
                == DialogResult.Yes)
            {
                try
                {
                    SqlRequestFunction.Logout(Program.mlogin);

                    if (Program.conn.State == ConnectionState.Open)
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
                    ChangeCurrentLogToKillSession();

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


        private void DeniceFeatureByRole()
        {
            if (Program.mGroup.Equals("SINHVIEN"))
            {
                btn_Khoa.Enabled = btn_Lop.Enabled = false;
                btn_NhapDe.Enabled = btn_RegisterExam.Enabled = btn_MonHoc.Enabled = false;
                btn_Transcript.Enabled = btn_RegisterReport.Enabled = false;

            }
            else if (Program.mGroup.Equals("GIANGVIEN"))
            {
                btn_Khoa.Enabled = btn_Lop.Enabled = false;
                btn_MonHoc.Enabled = false;
                btn_RegisterReport.Enabled = false;
            }
            else if (Program.mGroup.Equals("COSO"))
            {
                btn_Thi.Enabled = false;
            }
            else if (Program.mGroup.Equals("TRUONG"))
            {
                btn_Thi.Enabled = false;
                btn_NhapDe.Enabled = btn_RegisterExam.Enabled = btn_MonHoc.Enabled = false;
            }
        }

        private void ChangeCurrentLogToKillSession()
        {
            String newUser = "HTKN; Password=nguyenne";

            int length = Program.connstr.IndexOf("User ID=") + "User ID=".Length;

            String newConnString = Program.connstr.Substring(0, length);

            newConnString += newUser;

            if (Program.conn.State == ConnectionState.Open)
            {
                Program.conn.Close();
            }

            Program.connstr = newConnString;
            Program.conn.ConnectionString = Program.connstr;
        }
    }
}