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

namespace TracNghiem_CSDLPT
{
    public partial class Frm_DangKyThi : DevExpress.XtraEditors.XtraForm
    {
        public Frm_DangKyThi()
        {
            InitializeComponent();
        }

        private void Frm_DangKyThi_Load(object sender, EventArgs e)
        {
            this.ds_TN_CSDLPT.EnforceConstraints = false;

            this.tbla_GiaoVien.Connection.ConnectionString = Program.connstr;
            this.tbla_GiaoVien.Fill(this.ds_TN_CSDLPT.GIAOVIEN);

            this.tbla_GVDK.Connection.ConnectionString = Program.connstr;
            this.tbla_GVDK.Fill(this.ds_TN_CSDLPT.GIAOVIEN_DANGKY);

        }
    }
}