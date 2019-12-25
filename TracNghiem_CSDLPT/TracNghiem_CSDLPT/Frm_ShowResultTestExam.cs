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

namespace TracNghiem_CSDLPT
{
    public partial class Frm_ShowResultTestExam : DevExpress.XtraEditors.XtraForm
    {

        private TestInfo _testInfo;

        public Frm_ShowResultTestExam()
        {
            InitializeComponent();
        }

        public Frm_ShowResultTestExam(TestInfo testInfo)
        {
            InitializeComponent();

            _testInfo = testInfo;

            Init();
        }

        private void Init()
        {
            lbl_Class.Text = _testInfo.ClassName;
            lbl_Course.Text = _testInfo.CourseName;
            lbl_Date.Text = _testInfo.DateExam.ToShortDateString();
            lbl_FullName.Text = _testInfo.StudentName;
            lbl_TimesStep.Text = _testInfo.TimesStep + "";

            dgv_Result.DataSource = SetUpToDatTable(_testInfo.listQuestion);
        }

        private DataTable SetUpToDatTable(List<ExamTest> listExam)
        {
            DataTable table = new DataTable();

            DataColumn[] dc = new DataColumn[] 
            {
                new DataColumn("STT"), new DataColumn("Câu số")
                ,new DataColumn("Nội dung"), new DataColumn("Các chọn lựa")
                ,new DataColumn("Đáp án đúng"), new DataColumn("Đáp án chọn")
            };

            table.Columns.AddRange(dc);

            int index = 0;
            foreach (ExamTest item in listExam)
            {
                DataRow dataRow = table.NewRow();

                dataRow.ItemArray = SetupData(index++, item);

                table.Rows.Add(dataRow);
            }

            return table;
        }

        private object[] SetupData(int index, ExamTest test)
        {
            StringBuilder stringBuilder = new StringBuilder("A. " + test.A);
            stringBuilder.AppendLine("B. " + test.B);
            stringBuilder.AppendLine("C. " + test.C);
            stringBuilder.AppendLine("D. " + test.D);
            return new object[]
            {
                 index
                ,test.QuestionCode
                ,test.QuestionContent
                ,stringBuilder
                ,test.TrueAnswer
                ,test.YourAnswer
            };
        }
    }
}