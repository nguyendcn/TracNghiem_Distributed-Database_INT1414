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

            SetUp();
        }


        public void SetUp()
        {
            DataTable tableLevel = new DataTable("Level");
            tableLevel.Columns.Add("Symbol");
            tableLevel.Columns.Add("Name");

            DataRow dataRow = tableLevel.NewRow();
            dataRow.ItemArray = new object[] { "A", "Đại Học" };
            tableLevel.Rows.Add(dataRow);

            dataRow = tableLevel.NewRow();
            dataRow.ItemArray = new object[] { "B", "Cao Đẳng" };
            tableLevel.Rows.Add(dataRow);

            dataRow = tableLevel.NewRow();
            dataRow.ItemArray = new object[] { "C", "Trung Cấp" };
            tableLevel.Rows.Add(dataRow);

            cmb_Level.DataSource = tableLevel;
            cmb_Level.ValueMember = "Symbol";
            cmb_Level.DisplayMember = "Name";

            this.txt_TeacherCode.Text = Program.username;

            this.bs_GiaoVien.Position = FindPointionCurrentTeacher(Program.username);

            this.dtp_DateExam.MinDate = DateTime.Now;
            DateTime currentDateTime = DateTime.Now;
            this.dtp_DateExam.MaxDate = currentDateTime.AddDays(60);
        }

        private void Frm_DangKyThi_Load(object sender, EventArgs e)
        {
            
            this.ds_TN_CSDLPT.EnforceConstraints = false;

            this.tbl_Lop.Connection.ConnectionString = Program.connstr;
            this.tbl_Lop.Fill(this.ds_TN_CSDLPT.LOP);

            this.tbl_MonHoc.Connection.ConnectionString = Program.connstr;
            this.tbl_MonHoc.Fill(this.ds_TN_CSDLPT.MONHOC);

            this.tbla_GiaoVien.Connection.ConnectionString = Program.connstr;
            this.tbla_GiaoVien.Fill(this.ds_TN_CSDLPT.GIAOVIEN);

            this.tbla_GVDK.Connection.ConnectionString = Program.connstr;
            this.tbla_GVDK.Fill(this.ds_TN_CSDLPT.GIAOVIEN_DANGKY);

        }

        private int FindPointionCurrentTeacher(String teacherCode)
        {
            return bs_GiaoVien.Find("MAGV", teacherCode);
        }
    }
}