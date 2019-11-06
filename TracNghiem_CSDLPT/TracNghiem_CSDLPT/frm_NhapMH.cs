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
using DevExpress.XtraGrid.Views.Base;

namespace TracNghiem_CSDLPT
{
    public partial class frm_NhapMH : DevExpress.XtraEditors.XtraForm
    {
        public frm_NhapMH()
        {
            InitializeComponent();
        }


        private void frm_NhapMH_Load(object sender, EventArgs e)
        {
            this.tbla_MonHoc.Connection.ConnectionString = Program.connstr;
            this.tbla_MonHoc.Fill(this.ds_TN_CSDLPT.MONHOC);

        }

        private void gcv_MonHoc_Click(object sender, EventArgs e)
        {
            BaseView a = gcv_MonHoc.MainView;
            
        }
    }
}