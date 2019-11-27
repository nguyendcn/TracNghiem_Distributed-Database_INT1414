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
            Frm_NhapDe frm_NhapDe= new Frm_NhapDe();
            frm_NhapDe.MdiParent = this;
            frm_NhapDe.Show();
        }

        private void btn_RegisterExam_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frm_DangKyThi frm_DangKyThi = new Frm_DangKyThi();
            frm_DangKyThi.MdiParent = this;
            frm_DangKyThi.Show();
        }
    }
}