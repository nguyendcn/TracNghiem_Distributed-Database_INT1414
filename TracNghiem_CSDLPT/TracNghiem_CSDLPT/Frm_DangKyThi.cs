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
using TracNghiem_CSDLPT.SupportForm;
using System.Diagnostics;

namespace TracNghiem_CSDLPT
{
    public partial class Frm_DangKyThi : DevExpress.XtraEditors.XtraForm
    {
        private CallBackAction _backAction;

        public Frm_DangKyThi()
        {
            InitializeComponent();

            _backAction = new CallBackAction();

            JustNumber(txt_Minute);
            JustNumber(txt_Quantity);
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

            txt_Err_DateExam.Text = txt_Err_QuantityQues.Text = txt_Err_TimeExam.Text = txt_Err_TimesStep.Text = "";
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

            SetUp();
        }

        private int FindPointionCurrentTeacher(String teacherCode)
        {
            ShowAll(bs_GiaoVien);
            DataView dt = (DataView)bs_GiaoVien.List;
            dt.Sort = "MAGV";

            int index = dt.Find(teacherCode);
            return index;
        }

        private void btn_Register_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool validate = ValidateFrm();

            if (!validate)
                return;

            try
            {
                object[] data = GetAllDataOfRegister();
                DataRowView drv = (DataRowView)bs_GVDK.AddNew();
                drv.Row.ItemArray = data;

                SaveRegisterToDb();

                this._backAction.BackAction = Share.Action.RecoveryAdd;
                this._backAction.Table = SetUpCurrentData(data);

                this.bs_GiaoVien.Position = FindPointionCurrentTeacher(Program.username);

                Frm_RegisterExamSuccess frm_Success = new Frm_RegisterExamSuccess(SetUpDataSuccess(data));

                frm_Success.StartPosition = FormStartPosition.CenterParent;
                frm_Success.TopLevel = false;
                frm_Success.Parent = this;
                frm_Success.Show();
                frm_Success.BringToFront();
            }
            catch (Exception ex)
            {

            }
        }

        private void btn_Reset_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this._backAction.BackAction == Share.Action.None)
            {
                MessageBox.Show("Không có dữ liệu để phục hồi. Vui lòng kiểm tra lại!", "Phục hồi",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {

                Frm_ActionInfo frm_Recovery = new Frm_ActionInfo(
                    new Object[] { this.splc_Container, this.brm_Option },
                    this._backAction);

                frm_Recovery.Choosen += (result) =>
                {
                    if (result == DialogResult.Yes)
                    {
                        RecoveryDataByAction(this._backAction);
                    }
                };

                frm_Recovery.Parent = this;
                frm_Recovery.BringToFront();
                frm_Recovery.Show();
            }
        }

        private void SaveRegisterToDb()
        {
            bs_GVDK.EndEdit();
            bs_GVDK.ResetCurrentItem();
            this.tbla_GVDK.Update(this.ds_TN_CSDLPT.GIAOVIEN_DANGKY);
        }

        private object[] GetAllDataOfRegister()
        {
            return new object[] { txt_TeacherCode.Text, cmb_Course.SelectedValue, cmb_Class.SelectedValue,
                                  cmb_Level.SelectedValue, dtp_DateExam.Value.ToShortDateString(), nud_TimesStep.Value,
                                  txt_Quantity.Text, txt_Minute.Text};
        }

        private bool ValidateFrm()
        {
            if (!ValidateEmpty())
            {
                return false;
            }
            else
            {
                if (ValidateValue())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private bool ValidateEmpty()
        {
            bool validate = true;
            if (txt_Quantity.Text.Trim().Equals(String.Empty))
            {
                ErrorHandler.ShowError(txt_Err_QuantityQues, new string[] { "Ox0001" });
                this.ActiveControl = this.txt_Quantity;
                validate = false;
            }
            if (nud_TimesStep.Text.Trim().Equals(String.Empty))
            {
                ErrorHandler.ShowError(txt_Err_TimesStep, new string[] { "Ox0001" });
                this.ActiveControl = this.nud_TimesStep;
                validate = false;
            }
            if (txt_Minute.Text.Trim().Equals(String.Empty))
            {
                ErrorHandler.ShowError(txt_Err_TimeExam, new string[] { "Ox0001" });
                this.ActiveControl = this.txt_Minute;
                validate = false;
            }
            return validate;
        }

        private bool ValidateValue()
        {
            bool validate = true;

            if (Convert.ToInt32(nud_TimesStep.Text) < 1 || Convert.ToInt32(nud_TimesStep.Text) > 2)
            {
                ErrorHandler.ShowError(txt_Err_TimesStep, new string[] { "Ox5002" });
                this.ActiveControl = this.nud_TimesStep;
                validate = false;
            }

            validate = ValidateTimeExam() ? validate : false;

            validate = ValidateQuantityQues() ? validate : false;

            validate = ValidateCodeRegister(cmb_Class.SelectedValue.ToString(), cmb_Course.SelectedValue.ToString(),
                                            Convert.ToInt32(nud_TimesStep.Text)) ? validate : false;

            if (validate)
            {
                validate = ValidateGetQuestion(cmb_Course.SelectedValue.ToString(), cmb_Level.SelectedValue.ToString(),
                                               Convert.ToInt32(txt_Quantity.Text)) ? validate : false;
            }

            return validate;
        }

        private bool ValidateTimeExam()
        {
            bool validate = true;
            try
            {
                int value = Convert.ToInt32(txt_Minute.Text);

                if (value < 15 || value > 60)
                {
                    ErrorHandler.ShowError(txt_Err_TimeExam, new string[] { "Ox5001" });
                    this.ActiveControl = this.txt_Minute;
                    validate = false;
                }
            }
            catch (Exception)
            {
                ErrorHandler.ShowError(txt_Err_TimeExam, new string[] { "Ox0002" });
                this.ActiveControl = this.txt_Minute;
                validate = false;
            }
            return validate;
        }

        private bool ValidateQuantityQues()
        {
            bool validate = true;
            try
            {
                int value = Convert.ToInt32(txt_Quantity.Text);

                if (value < 10 || value > 100)
                {
                    ErrorHandler.ShowError(txt_Err_QuantityQues, new string[] { "Ox5003" });
                    this.ActiveControl = this.txt_Quantity;
                    validate = false;
                }
            }
            catch (Exception)
            {
                ErrorHandler.ShowError(txt_Err_QuantityQues, new string[] { "Ox0002" });
                this.ActiveControl = this.txt_Quantity;
                validate = false;
            }
            return validate;
        }

        private bool ValidateCodeRegister(String classCode, String courseCode, int time)
        {
            if (SqlRequestFunction.RegisterIsExists(classCode, courseCode, time))
            {
                MessageBox.Show("Lượt thi của Môn thi này cho lớp đó đã được tổ chức thi hai lần. Và không thể tổ chức thêm.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private bool ValidateGetQuestion(String courseCode, String level, int quantity)
        {
            bool isEnough = SqlRequestFunction.IsEnoughQuestion(courseCode, level, quantity);

            if (!isEnough)
            {
                MessageBox.Show("Không đủ câu hỏi để tổ chức thi. " + ErrorCode.Ox5003 + " Vui lòng kiểm tra lại",
                                "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return isEnough;
        }

        private DataTable SetUpCurrentData(object[] datas)
        {
            DataTable table = new DataTable();

            DataColumn[] dcs = new DataColumn[] { new DataColumn("Mã GV"), new DataColumn("Mã môn học")
                                                ,new DataColumn("Mã lớp"), new DataColumn("Trình độ")
                                                ,new DataColumn("Ngày thi"), new DataColumn("Lần thi")
                                                ,new DataColumn("Số câu"), new DataColumn("Thời gian")};

            table.Columns.AddRange(dcs);

            DataRow dr = table.NewRow();
            dr.ItemArray = datas;
            table.Rows.Add(dr);

            return table;
        }

        public void RecoveryDataByAction(CallBackAction cAction)
        {
            if (cAction.BackAction == Share.Action.RecoveryAdd)
            {
                DataView dt = (DataView)bs_GVDK.List;

                DataRow dr = cAction.Table.Rows[0];

                String key1 = dr.ItemArray[1].ToString();
                String key2 = dr.ItemArray[2].ToString();
                String key3 = dr.ItemArray[5].ToString();

                int index = dt.Find(new object[] { key1, key2, key3 });

                bs_GVDK.RemoveAt(index);
                SaveRegisterToDb();

                this.bs_GiaoVien.Position = FindPointionCurrentTeacher(Program.username);
            }

            this._backAction.Reset();
            this.Refresh();
        }

        public void ShowAll(BindingSource src)
        {
            DataView dt = (DataView)src.List;
            DataTable table = dt.Table;

            Debug.WriteLine("Start show table content.");
            foreach (DataRow row in table.Rows)
            {
                string ID = row["MAGV"].ToString();
                string Name = row["TEN"].ToString();
                string FamilyName = row["MAKH"].ToString();

                Debug.WriteLine("{MAGV=" + ID + ", TEN=" + Name + ", MAKH=" + FamilyName + "}");
            }
        }

        public object[] SetUpDataSuccess(object[] data)
        {
            String teacherName = GetTeacherName(data[0].ToString());
            String courseName = GetCourseName(data[1].ToString());
            String className = GetClassName(data[2].ToString());
            String level = GetLevelName(data[3].ToString());

            return new object[] { teacherName, courseName, className, level, data[4], data[5], data[6], data[7] };
        }

        public String GetTeacherName(String teacherCode)
        {
            DataView dt = (DataView)bs_GiaoVien.List;
            dt.Sort = "MAGV";

            DataRowView rowView = dt.FindRows(teacherCode)[0];

            return rowView.Row.ItemArray[1] + " " + rowView.Row.ItemArray[2];
        }

        public String GetCourseName(String courseCode)
        {
            DataView dt = (DataView)bs_MonHoc.List;
            dt.Sort = "MAMH";

            DataRowView rowView = dt.FindRows(courseCode)[0];

            return rowView.Row.ItemArray[1].ToString();
        }

        public String GetClassName(String classCode)
        {
            DataView dt = (DataView)bs_Lop.List;
            dt.Sort = "MALOP";

            DataRowView rowView = dt.FindRows(classCode)[0];

            return rowView.Row.ItemArray[1].ToString();
        }

        public String GetLevelName(String level)
        {
            switch (level)
            {
                case "A":
                    return "Đại Học";
                case "B":
                    return "Cao Đẳng";
                case "C":
                    return "Trung Cấp";
                default:
                    return "";
            }
        }

        public void JustNumber(TextBox textBox)
        {
            textBox.KeyPress += (sender, e) =>
            {
                if(e.KeyChar < '0' || e.KeyChar > '9')
                    e.Handled = true;
            };
        }
    }
}