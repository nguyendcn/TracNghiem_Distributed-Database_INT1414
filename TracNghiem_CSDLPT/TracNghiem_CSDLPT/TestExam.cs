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
    public partial class TestExam : DevExpress.XtraEditors.XtraForm, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private TestInfo _testInfo;
        private List<ExamTest> _listQuestion;

        private int _currentQuestionIndex;

        public int CurrentQuestionIndex
        {
            get { return _currentQuestionIndex; }
            set
            {
                _currentQuestionIndex = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("CurrentQuestionIndex"));
                }
            }
        }


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
            this._listQuestion = testInfo.listQuestion;

            Init();

            _timer = new Timer();
            _timer.Interval = 1000;
            _timer.Tick += _timer_Tick;
            _timer.Start();

            PropertyChanged += TestExam_PropertyChanged;
        }

        private void TestExam_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "CurrentQuestionIndex":
                    ChangeIndexQuestion();
                    break;
            }
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            this._currentSecond++;
            if(_currentSecond == 60)
            {
                _currentSecond = 0;
                _currentMinute++;
                if(_currentMinute >= _testInfo.TotalTime)
                {
                    MessageBox.Show("Đã hết thời gian làm bài."
                        , "Hết thời gian!"
                        , MessageBoxButtons.OK
                        , MessageBoxIcon.Information);

                    SubmitExam(_listQuestion);
                    return;
                }
            }
            this.lbl_CountDown.Text = _currentMinute + " : " + _currentSecond;
        }

        private void Init()
        {
            ExamTest exam = _listQuestion[_currentQuestionIndex];
            lbl_Question.Text = "Câu số " + (_currentQuestionIndex + 1) + "/ " + _testInfo.listQuestion.Count;
            txt_QuestionContent.Text = exam.QuestionContent;
            txt_A.Text = exam.A;
            txt_B.Text = exam.B;
            txt_C.Text = exam.C;
            txt_D.Text = exam.D;

            btn_Previous.Enabled = false;
            btn_Submit.Visible = false;

            lbl_Info.Text = _testInfo.StudentName + "-" + _testInfo.StudentCode + "- Bài thi môn " + _testInfo.CourseName;
        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
            CurrentQuestionIndex++;

            ShowQuestionByIndex(_currentQuestionIndex);
        }

        private void btn_Previous_Click(object sender, EventArgs e)
        {
            CurrentQuestionIndex--;

            ShowQuestionByIndex(_currentQuestionIndex);
        }

        private void ShowQuestionByIndex(int questionIndex)
        {
            ExamTest exam = _listQuestion[questionIndex];
            lbl_Question.Text = "Câu số " + (questionIndex + 1) + "/ " + _testInfo.listQuestion.Count;
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
                    this.rdb_A.Checked = false;
                    this.rdb_B.Checked = false;
                    this.rdb_C.Checked = false;
                    this.rdb_D.Checked = false;
                    break;
            }
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            if (!IsDoneExam())
            {
                MessageBox.Show("Bạn chưa hoàn thành hết bài thi. Vui lòng quay lại làm tiếp."
                    , "Chưa làm xong!"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Information);
                return;
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn nộp bài không. Vẫn còn thời gian để làm bài?"
                                        , "Nộp bài."
                                        , MessageBoxButtons.YesNo
                                        , MessageBoxIcon.Information);
                
                if(result == DialogResult.Yes)
                {
                    SubmitExam(_listQuestion);
                }
                else { return; }
            }

        }

        private void Rdb_Answer_Click(object sender, EventArgs e)
        {
            RadioButton rdb = sender as RadioButton;

            _listQuestion[_currentQuestionIndex].YourAnswer = rdb.Tag.ToString();
        }

        private void ChangeIndexQuestion()
        {
            if(_currentQuestionIndex > 0 && _currentQuestionIndex < (_listQuestion.Count - 1))
            {
                this.btn_Next.Enabled = true;
                this.btn_Previous.Enabled = true;
                this.btn_Submit.Visible = false;
            }
            else if(_currentQuestionIndex == 0)
            {
                this.btn_Previous.Enabled = false;
            }
            else if(_currentQuestionIndex == (_listQuestion.Count - 1))
            {
                this.btn_Next.Enabled = false;
                this.btn_Submit.Visible = true;
            }
        }

        private void RemoveSelection(Object obj)
        {
            TextBox textbox = obj as TextBox;
            if (textbox != null)
            {
                textbox.SelectionLength = 0;
            }
        }

        private void txt_QuestionContent_MouseUp(object sender, MouseEventArgs e)
        {
            RemoveSelection(sender);
        }

        private void TestExam_Shown(object sender, EventArgs e)
        {
            RemoveSelection(sender);
        }

        private void txt_QuestionContent_MouseDown(object sender, MouseEventArgs e)
        {
            RemoveSelection(sender);
        }

        private bool IsDoneExam()
        {
            return _listQuestion.Count(x => x.YourAnswer == String.Empty) == 0;
        }

        private void SubmitExam(List<ExamTest> listExam)
        {

        }
    }
}