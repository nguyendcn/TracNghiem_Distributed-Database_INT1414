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
using TracNghiem_CSDLPT.Share;

namespace TracNghiem_CSDLPT
{
    public partial class Frm_CBThi : Form
    {
        public Frm_CBThi()
        {
            InitializeComponent();
        }


        private void Frm_CBThi_Load(object sender, EventArgs e)
        {
            this.ds_TN_CSDLPT.EnforceConstraints = false;

            this.tbla_MONHOC.Connection.ConnectionString = Program.connstr;
            this.tbla_MONHOC.Fill(this.ds_TN_CSDLPT.MONHOC);

            this.tbla_GVDK.Connection.ConnectionString = Program.connstr;
            this.tbla_GVDK.Fill(this.ds_TN_CSDLPT.GIAOVIEN_DANGKY);

            SetUp();
        }

        private void SetUp()
        {
            //Check role xem co phai la sinh vien khong
            StudentInfo studentInfo = SqlRequestFunction.GetStudentInfo("004");

            this.lbl_StudentCode.Text = "004";
            this.lbl_StudentName.Text = studentInfo.FullName;
            this.lbl_ClassCode.Text = studentInfo.ClassCode;
            this.lbl_ClassName.Text = studentInfo.ClassName;

            this.dtp_DateExam.MinDate = DateTime.Now;
            DateTime currentDateTime = DateTime.Now;
            this.dtp_DateExam.MaxDate = currentDateTime.AddDays(60);

            this.grb_StartExam.Visible = false;
        }

        private void btn_Find_Click(object sender, EventArgs e)
        {
            DataView dt = (DataView)bs_GVDK.List;

            String key1 = cmb_Course.SelectedValue.ToString();
            String key2 = dtp_DateExam.Value.ToShortDateString();
            String key3 = nud_TimesStep.Value.ToString();

            DataRowView []rowView = dt.FindRows(new object[] { key1, key2, key3 });

            
            if (rowView.Length != 0)
            {
                dgv_Results.DataSource = SetUpCurrentData(rowView);

                grb_StartExam.Visible = true;
            }
            else
            {
                MessageBox.Show("Not found");
            }
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            if (dgv_Results.SelectedRows == null && dgv_Results.Rows.Count > 0)
            {
                dgv_Results.Rows[0].Selected = true;
            }

            DataGridViewRow gridView = dgv_Results.SelectedRows[0];

            TestInfo testInfo = new TestInfo()
            {
                CourseCode = cmb_Course.SelectedValue.ToString(),
                CourseName = cmb_Course.Text,
                StudentCode = lbl_StudentCode.Text,
                StudentName = lbl_StudentName.Text,
                TimesStep = int.Parse(gridView.Cells[5].Value.ToString()),
                TotalTime = int.Parse(gridView.Cells[7].Value.ToString()),
                listQuestion = GetListQuestion()
            };

            TestExam testExam = new TestExam(testInfo);

            testExam.ShowDialog();
        }

        private void cmb_Course_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private DataTable SetUpCurrentData(DataRowView []dataRow)
        {
            DataTable table = new DataTable();

            DataColumn[] dcs = new DataColumn[] { new DataColumn("Mã GV"), new DataColumn("Mã môn học")
                                                ,new DataColumn("Mã lớp"), new DataColumn("Trình độ")
                                                ,new DataColumn("Ngày thi"), new DataColumn("Lần thi")
                                                ,new DataColumn("Số câu"), new DataColumn("Thời gian")};

            table.Columns.AddRange(dcs);

            foreach (DataRowView item in dataRow)
            {
                DataRow dr = table.NewRow();
                dr.ItemArray = item.Row.ItemArray;
                table.Rows.Add(dr);
            }

            return table;
        }

        private List<ExamTest> GetListQuestion()
        {
            DataGridViewRow gridView = dgv_Results.SelectedRows[0];

            return SqlRequestFunction.GetQuestionForTestExam( gridView.Cells[1].Value.ToString()
                                                            , gridView.Cells[3].Value.ToString()
                                                            , int.Parse(gridView.Cells[7].Value.ToString()));
        }
    }
}
