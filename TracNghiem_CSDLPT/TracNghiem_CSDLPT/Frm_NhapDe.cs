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
    public partial class Frm_NhapDe : DevExpress.XtraEditors.XtraForm
    {
        public Frm_NhapDe()
        {
            InitializeComponent();
        }

        

        private void Frm_NhapDe_Load(object sender, EventArgs e)
        {
            this.ds_TN_CSDLPT.EnforceConstraints = false;

            this.tbla_BoDe.Connection.ConnectionString = Program.connstr;
            this.tbla_BoDe.Fill(this.ds_TN_CSDLPT.BODE);

            this.tbla_GiaoVien.Connection.ConnectionString = Program.connstr;
            this.tbla_GiaoVien.Fill(this.ds_TN_CSDLPT.GIAOVIEN);

            this.bs_GiaoVien.Position = FindPointionCurrentTeacher(Program.username);
        }

        private int FindPointionCurrentTeacher(String teacherCode)
        {
            return bs_GiaoVien.Find("MAGV", teacherCode);
        }

    }
}