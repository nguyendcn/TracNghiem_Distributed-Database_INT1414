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
using TracNghiem_CSDLPT.Share;
using TracNghiem_CSDLPT.Common;

namespace TracNghiem_CSDLPT
{
    public partial class Frm_ViewTranscript : DevExpress.XtraEditors.XtraForm
    {
        public Frm_ViewTranscript()
        {
            InitializeComponent();

            grb_Tool.Enabled = false;
        }

        private void Frm_ViewTranscript_Load(object sender, EventArgs e)
        {
            this.ds_TN_CSDLPT.EnforceConstraints = false;

            this.tbla_MONHOC.Connection.ConnectionString = Program.connstr;
            this.tbla_MONHOC.Fill(this.ds_TN_CSDLPT.MONHOC);

            this.tbla_LOP.Connection.ConnectionString = Program.connstr;
            this.tbla_LOP.Fill(this.ds_TN_CSDLPT.LOP);

        }

        private void btn_View_Click(object sender, EventArgs e)
        {
            List<Transcript> transcipts = SqlRequestFunction.GetTranscript(cmb_Class.SelectedValue.ToString()
                , cmb_Course.SelectedValue.ToString(), (int)nud_TimesStep.Value);

            if(transcipts.Count == 0)
            {
                lbl_ClassName.Text = "";
                lbl_CourseName.Text = "";
                lbl_TimesStep.Text = "";

                dgv_Transcript.DataSource = null;

                MessageBox.Show("Không tìm thấy bảng điểm với thông tin tương ứng. Vui lòng kiểm tra lại.",
                    "Không tìm thấy!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lbl_ClassName.Text = cmb_Class.Text;
            lbl_CourseName.Text = cmb_Course.Text;
            lbl_TimesStep.Text = nud_TimesStep.Value.ToString();

            this.dgv_Transcript.DataSource = SetUpDataTable(transcipts);
        }

        private DataTable SetUpDataTable(List<Transcript> transcripts)
        {
            DataTable table = new DataTable();

            DataColumn[] dcs = new DataColumn[]
            {
                new DataColumn("STT"), new DataColumn("Mã Sinh Viên")
                ,new DataColumn("Họ tên"), new DataColumn("Điểm")
                ,new DataColumn("Điểm Chữ")
            };

            table.Columns.AddRange(dcs);

            int index = 1;
            foreach (Transcript item in transcripts)
            {
                DataRow row = table.NewRow();

                row.ItemArray = GetData(index++, item);

                table.Rows.Add(row);
            }

            return table;
        }

        private object[] GetData(int index, Transcript trans)
        {
            return new object[]
            {
                index, trans.StudentCode, trans.FullName, trans.Marks, trans.MarksStr
            };
        }

        private void dgv_Transcript_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
    }
}