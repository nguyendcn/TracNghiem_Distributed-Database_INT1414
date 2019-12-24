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

namespace TracNghiem_CSDLPT.SupportForm
{
    public partial class Frm_RegisterExamSuccess : DevExpress.XtraEditors.XtraForm
    {
        public Frm_RegisterExamSuccess()
        {
            InitializeComponent();
        }

        public Frm_RegisterExamSuccess(String teacherName, String courseName, String className, String level,
            String timesStep, String dateExam, String time, String question)
        {
            InitializeComponent();

            this.lbl_TeacherName.Text = teacherName;
            this.lbl_CourseName.Text = courseName;
            this.lbl_Class.Text = className;
            this.lbl_Level.Text = level;
            this.lbl_TimesStep.Text = timesStep;
            this.lbl_DateExam.Text = dateExam;
            this.lbl_Time.Text = time;
            this.lbl_Question.Text = question;
        }

        public Frm_RegisterExamSuccess(object[] datas)
        {
            InitializeComponent();

            this.lbl_TeacherName.Text = datas[0].ToString();
            this.lbl_CourseName.Text = datas[1].ToString();
            this.lbl_Class.Text = datas[2].ToString();
            this.lbl_Level.Text = datas[3].ToString();
            this.lbl_TimesStep.Text = datas[5].ToString();
            this.lbl_DateExam.Text = datas[4].ToString();
            this.lbl_Time.Text = datas[7].ToString();
            this.lbl_Question.Text = datas[6].ToString();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}