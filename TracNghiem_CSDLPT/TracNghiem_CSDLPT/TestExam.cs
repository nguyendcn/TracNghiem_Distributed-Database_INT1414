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
    public partial class TestExam : DevExpress.XtraEditors.XtraForm
    {
        private TestInfo _testInfo;
        private List<ExamTest> _listQuestion;

        private int _currentQuestionIndex = 0;

        private int _currentMinute = 0;
        private int _currentSecond = 0;

        private Timer _timer;

        public TestExam()
        {
            InitializeComponent();

            _listQuestion = new List<ExamTest>();
        }

        public TestExam(TestInfo testInfo)
        {
            InitializeComponent();

            this._testInfo = testInfo;

            _timer = new Timer();
            _timer.Interval = 1000;
            _timer.Tick += _timer_Tick;
            _timer.Start();
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            this._currentSecond++;
            if(_currentSecond == 60)
            {
                _currentMinute++;
                if(_currentMinute >= _testInfo.TotalTime)
                {
                    //Timeout
                }
                else
                {
                    this.lbl_CountDown.Text = _currentMinute + " : " + _currentSecond;
                }
            }
        }

        private void Init()
        {
            ExamTest exam = _listQuestion[_currentQuestionIndex];
            lbl_Question.Text = "Câu hỏi " + _currentQuestionIndex + 1;
            txt_QuestionContent.Text = exam.QuestionContent;
            txt_A.Text = exam.A;
            txt_B.Text = exam.B;
            txt_C.Text = exam.C;
            txt_D.Text = exam.D;

            btn_Previous.Enabled = false;
            btn_Submit.Visible = false;
        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
            if(_currentQuestionIndex + 1 >= _listQuestion.Count)
            {
                btn_Submit.Visible = true;
                btn_Next.Enabled = false;
            }
            else
            {
                btn_Previous.Enabled = true;
                _currentQuestionIndex++;

                ShowQuestionByIndex(_currentQuestionIndex);
            }
        }

        private void btn_Previous_Click(object sender, EventArgs e)
        {
            if (_currentQuestionIndex <= 0)
            {
                btn_Previous.Enabled = false;
            }
            else if(_currentQuestionIndex + 1 < _listQuestion.Count)
            {
                this.btn_Submit.Visible = false;
            }
            else
            {
                btn_Next.Enabled = true;
                _currentQuestionIndex--;

                ShowQuestionByIndex(_currentQuestionIndex);
            }
        }

        private void ShowQuestionByIndex(int questionIndex)
        {
            ExamTest exam = _listQuestion[questionIndex];
            lbl_Question.Text = "Câu hỏi " + questionIndex + 1;
            txt_QuestionContent.Text = exam.QuestionContent;
            txt_A.Text = exam.A;
            txt_B.Text = exam.B;
            txt_C.Text = exam.C;
            txt_D.Text = exam.D;

            switch (exam.YourAnswer)
            {
                case "A":
                    this.rdb_A.Checked = true;
                    return;
                case "B":
                    this.rdb_B.Checked = true;
                    return;
                case "C":
                    this.rdb_C.Checked = true;
                    return;
                case "D":
                    this.rdb_D.Checked = true;
                    return;
                default:
                    break;
            }
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {

        }
    }
}