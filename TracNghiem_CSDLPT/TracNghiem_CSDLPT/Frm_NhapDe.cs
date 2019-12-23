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
using System.Diagnostics;
using TracNghiem_CSDLPT.Common;
using TracNghiem_CSDLPT.Share;
using TracNghiem_CSDLPT.SupportForm;

namespace TracNghiem_CSDLPT
{
    public partial class Frm_NhapDe : DevExpress.XtraEditors.XtraForm
    {
        private CallBackAction _callAction;

        public Frm_NhapDe()
        {
            InitializeComponent();

            _callAction = new CallBackAction();

            SetUp();

            bs_BoDe.CurrentChanged += Bs_BoDe_CurrentChanged;
        }

        private void Bs_BoDe_CurrentChanged(object sender, EventArgs e)
        {
            if (bs_BoDe.Position != -1)
            {
                txt_QuestionCode.Text = ((DataRowView)bs_BoDe[bs_BoDe.Position])["CAUHOI"].ToString().Trim();

                cmb_CourseCode.SelectedIndex = bs_MonHoc.Find("MAMH", ((DataRowView)bs_BoDe[bs_BoDe.Position])["MAMH"].ToString().Trim());

                cmb_Level.SelectedIndex = GetIndexOfDataTable((DataTable)cmb_Level.DataSource,
                    ((DataRowView)bs_BoDe[bs_BoDe.Position])["TRINHDO"].ToString().Trim());

                txt_QuestionContent.Text = ((DataRowView)bs_BoDe[bs_BoDe.Position])["NOIDUNG"].ToString().Trim();
                txt_AnsA.Text = ((DataRowView)bs_BoDe[bs_BoDe.Position])["A"].ToString().Trim();
                txt_AnsB.Text = ((DataRowView)bs_BoDe[bs_BoDe.Position])["B"].ToString().Trim();
                txt_AnsC.Text = ((DataRowView)bs_BoDe[bs_BoDe.Position])["C"].ToString().Trim();
                txt_AnsD.Text = ((DataRowView)bs_BoDe[bs_BoDe.Position])["D"].ToString().Trim();

                cmb_TrueAnswer.SelectedIndex = cmb_TrueAnswer.FindString(((DataRowView)bs_BoDe[bs_BoDe.Position])["DAP_AN"].ToString().Trim());

            }
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

            ClearAllMessageError();
        }

        private int GetIndexOfDataTable(DataTable dt, String key)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i].ItemArray[0].Equals(key))
                    return i;
            }
            return -1;
        }

        private int FindPointionCurrentTeacher(String teacherCode)
        {
            return bs_GiaoVien.Find("MAGV", teacherCode);
        }

        private bool DataEmptyOrNull()
        {
            if (String.IsNullOrEmpty(txt_QuestionContent.Text.Trim()))
            {
                this.ActiveControl = txt_QuestionContent;
                return true;
            }
            else if (String.IsNullOrEmpty(txt_AnsA.Text.Trim()))
            {
                this.ActiveControl = txt_AnsA;
                return true;
            }
            else if (String.IsNullOrEmpty(txt_AnsB.Text.Trim()))
            {
                this.ActiveControl = txt_AnsB;
                return true;
            }
            else if (String.IsNullOrEmpty(txt_AnsC.Text.Trim()))
            {
                this.ActiveControl = txt_AnsC;
                return true;
            }
            else if (String.IsNullOrEmpty(txt_AnsD.Text.Trim()))
            {
                this.ActiveControl = txt_AnsD;
                return true;
            }
            return false;
        }

        private int GetIndexCodeForQuestion()
        {
            List<int> lCode = SqlRequestFunction.GetListQuestionCode();
            int count = lCode.Count;

            for (int index = 0; index < count; index++)
            {
                int expectValue = index + 1;
                if (expectValue != lCode[index]) return expectValue;
            }
            return lCode[count - 1] + 1;
        }

        private void Frm_NhapDe_Load(object sender, EventArgs e)
        {


            this.ds_TN_CSDLPT.EnforceConstraints = false;

            this.tbl_MonHoc.Connection.ConnectionString = Program.connstr;
            this.tbl_MonHoc.Fill(this.ds_TN_CSDLPT.MONHOC);

            this.tbla_BoDe.Connection.ConnectionString = Program.connstr;
            this.tbla_BoDe.Fill(this.ds_TN_CSDLPT.BODE);

            this.tbla_GiaoVien.Connection.ConnectionString = Program.connstr;
            this.tbla_GiaoVien.Fill(this.ds_TN_CSDLPT.GIAOVIEN);

            this.bs_GiaoVien.Position = FindPointionCurrentTeacher(Program.username);
        }

        private void btn_Add_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.btn_Exit.Tag = "ADD";
            this.btn_Write.Tag = "ADD";

            SetUpButtonForAction();

            AutoFillForAddAction();
        }

        private void btn_Edit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.btn_Write.Tag = "EDIT";
            this.btn_Exit.Tag = "EDIT";

            SetUpButtonForAction();
        }

        private void btn_Exit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (btn_Exit.Tag == null)
                return;

            if (btn_Exit.Tag.Equals("ADD"))
            {
                if (XtraMessageBox.Show(
                    "Bạn có chắc muốn thoát quá trình nhập không?",
                    "Thoát",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    FreeAllControl();
                }
            }
            else if (btn_Exit.Tag.Equals("EDIT"))
            {
                if (XtraMessageBox.Show(
                    "Bạn có chắc muốn thoát quá trình sửa không?",
                    "Thoát",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    FreeAllControl();
                }
            }
        }

        private void btn_Reset_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this._callAction.BackAction == Share.Action.None)
            {
                MessageBox.Show("Không có dữ liệu để phục hồi. Vui lòng kiểm tra lại!", "Phục hồi",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {

                Frm_ActionInfo frm_Recovery = new Frm_ActionInfo(
                    new Object[] { this.splc_Container, this.brm_Option },
                    this._callAction);

                frm_Recovery.Choosen += (result) =>
                {
                    if (result == DialogResult.Yes)
                    {
                        RecoveryDataByAction(this._callAction);
                    }
                };

                frm_Recovery.Parent = this;
                frm_Recovery.BringToFront();
                frm_Recovery.Show();
            }
        }

        private void btn_Write_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (btn_Write.Tag == null)
                    return;
                if (this.btn_Write.Tag.Equals("ADD"))
                {
                    bool addSucess = Add();

                    if (addSucess)
                    {
                        Frm_ActionInfo info = new Frm_ActionInfo(
                                            new Object[] { this.splc_Container, this.brm_Option },
                                            new CallBackAction(Share.Action.AddSuccess, this._callAction.Table)
                                            );

                        info.Parent = this;
                        info.BringToFront();
                        info.Show();

                        txt_QuestionCode.Text = GetIndexCodeForQuestion().ToString();
                    }
                }
                else if (this.btn_Write.Tag.Equals("EDIT"))
                {
                    bool editSuccess = Edit();

                    if (editSuccess)
                    {
                        DataTable dt = SetUpCurrentData(((DataRowView)bs_BoDe.Current).Row.ItemArray);

                        Frm_ActionInfo frm_edit = new Frm_ActionInfo(
                                            new Object[] { this.splc_Container, this.brm_Option },
                                            new CallBackAction(Share.Action.EditSuccess, dt)
                                            );

                        frm_edit.Parent = this;
                        frm_edit.BringToFront();
                        frm_edit.Show();
                    }
                }
                else return;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("CAUHOI"))
                    MessageBox.Show("Mã CH không được trùng", "", MessageBoxButtons.OK);
                else
                {
                    MessageBox.Show("Lỗi ghi Bộ đề" + ex.Message, "", MessageBoxButtons.OK);
                }
            }
        }

        private void btn_Delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Delete();
        }

        private void Txt__MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TextBox tb = sender as TextBox;

            tb.SelectAll();
        }

        private bool Add()
        {
            bool isEmpty = ValidateEmpty();

            if (!isEmpty)
                return false;

            object[] data = GetAllDataOfQuestion();
            DataRowView drv = (DataRowView)bs_BoDe.AddNew();
            drv.Row.ItemArray = data;

            SaveDBToDb();

            this._callAction.FillData(Share.Action.RecoveryAdd, SetUpCurrentData(data));
            return true;
        }

        private bool Edit()
        {
            bool isEmpty = ValidateEmpty();

            if (!isEmpty)
                return false;

            DataRowView currentRow = (DataRowView)bs_BoDe.Current;

            if (currentRow != null)
            {
                try
                {
                    this._callAction.FillData(Share.Action.RecoveryEdit, SetUpCurrentData(currentRow.Row.ItemArray));

                    object[] data = GetAllDataOfQuestion();
                    currentRow.Row.ItemArray = data;

                    SaveDBToDb();

                    return true;
                }
                catch(Exception)
                {
                    return false;
                }
            }
            else
            {
                XtraMessageBox.Show(StringLibrary.E_EditEmpty, StringLibrary.E_EditNotify, MessageBoxButtons.OK);
                return false;
            }
        }

        private void Delete()
        {
            DataRowView currentRow = (DataRowView)bs_BoDe.Current;
            if (AbleDelete())
            {
                Frm_ActionInfo frm_delete = new Frm_ActionInfo(
                    new Object[] { this.splc_Container, this.brm_Option },
                    new CallBackAction(Share.Action.Delete, SetUpCurrentData(currentRow.Row.ItemArray)));

                frm_delete.Choosen += (result) =>
                {
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            this._callAction.FillData(Share.Action.RecoveryDelete, SetUpCurrentData(currentRow.Row.ItemArray));

                            bs_BoDe.RemoveCurrent();
                            SaveDBToDb();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Can not delete row because: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                };

                frm_delete.Parent = this;
                frm_delete.BringToFront();
                frm_delete.Show();
            }
        }

        private void SaveDBToDb()
        {
            this.bs_BoDe.EndEdit();
            this.bs_BoDe.ResetCurrentItem();
            this.tbla_BoDe.Update(this.ds_TN_CSDLPT.BODE);
        }

        private bool AbleDelete()
        {
            return true;
        }

        public void RecoveryDataByAction(CallBackAction cAction)
        {
            if (cAction.BackAction == Share.Action.RecoveryAdd)
            {
                DataView dt = (DataView)bs_BoDe.List;

                DataRow dr = cAction.Table.Rows[0];
                String key = dr.ItemArray[0].ToString();
                int index = dt.Find(key);

                bs_BoDe.RemoveAt(index);
                SaveDBToDb();
            }
            else if (cAction.BackAction == Share.Action.RecoveryDelete)
            {
                DataView dt = (DataView)bs_BoDe.List;
                dt.Sort = "CAUHOI";
                if (dt.FindRows(cAction.Table.Rows[0].ItemArray[0]).Length != 0)
                {
                    MessageBox.Show("Mã CH đã tồn tại.Vui lòng nhập lại!");
                }
                else
                {
                    DataRow dr = cAction.Table.Rows[0];
                    DataRowView drv = (DataRowView)bs_BoDe.AddNew();
                    drv.Row.ItemArray = dr.ItemArray;
                    SaveDBToDb();
                }
            }
            else if (cAction.BackAction == Share.Action.RecoveryEdit)
            {
                DataView dt = (DataView)bs_BoDe.List;

                DataRow dr = cAction.Table.Rows[0];
                String key = dr.ItemArray[0].ToString();
                int index = dt.Find(key);

                bs_BoDe.Position = index;

                DataRowView currentRow = (DataRowView)bs_BoDe.Current;

                currentRow.Row.ItemArray = dr.ItemArray;
                SaveDBToDb();
            }

            this._callAction.Reset();
            this.Refresh();
        }

        private void ClearAllMessageError()
        {
            lbl_Err_A.Text = lbl_Err_B.Text = lbl_Err_C.Text = lbl_Err_D.Text = "";
            lbl_Err_Content.Text = "";
        }

        private void ClearFieldContent()
        {
            this.txt_AnsA.Text = txt_AnsB.Text = txt_AnsC.Text = txt_AnsD.Text = "";
            this.txt_QuestionContent.Text = "";

        }

        private void SetUpButtonForAction()
        {
            this.splc_WorkArea.Enabled = true;
            this.btn_Add.Enabled = false;
            this.btn_Edit.Enabled = false;
            this.btn_Delete.Enabled = false;

            if (this.btn_Write.Tag.Equals("ADD"))
            {
                ClearFieldContent();
                this.ActiveControl = this.txt_QuestionContent;
                try
                {
                    this.bs_MonHoc.CurrentChanged -= Bs_BoDe_CurrentChanged;
                }
                catch (ArgumentNullException anex)
                {
                    Debug.WriteLine(anex.Message);
                }
            }
        }

        private void FreeAllControl()
        {
            this.splc_WorkArea.Enabled = false;
            this.btn_Add.Enabled = true;
            this.btn_Edit.Enabled = true;
            this.btn_Delete.Enabled = true;

            this.btn_Exit.Tag = this.btn_Write.Tag = "";

            try
            {
                this.bs_MonHoc.CurrentChanged -= Bs_BoDe_CurrentChanged;
                this.bs_MonHoc.CurrentChanged += Bs_BoDe_CurrentChanged;
            }
            catch (ArgumentNullException anex)
            {
                this.bs_MonHoc.CurrentChanged += Bs_BoDe_CurrentChanged;

                Debug.WriteLine(anex.Message);
            }

        }

        private bool ValidateEmpty()
        {
            bool validate = true;
            if (txt_QuestionContent.Text.Trim().Equals(String.Empty))
            {
                ErrorHandler.ShowError(lbl_Err_Content, new string[] { "Ox0001" });
                this.ActiveControl = this.txt_QuestionContent;
                validate = false;
            }

            if (txt_AnsA.Text.Trim().Equals(String.Empty))
            {
                ErrorHandler.ShowError(lbl_Err_A, new string[] { "Ox0001" });
                this.ActiveControl = this.txt_AnsA;
                validate = false;
            }
            if (txt_AnsB.Text.Trim().Equals(String.Empty))
            {
                ErrorHandler.ShowError(lbl_Err_B, new string[] { "Ox0001" });
                this.ActiveControl = this.txt_AnsB;
                validate = false;
            }
            if (txt_AnsC.Text.Trim().Equals(String.Empty))
            {
                ErrorHandler.ShowError(lbl_Err_C, new string[] { "Ox0001" });
                this.ActiveControl = this.txt_AnsC;
                validate = false;
            }
            if (txt_AnsD.Text.Trim().Equals(String.Empty))
            {
                ErrorHandler.ShowError(lbl_Err_D, new string[] { "Ox0001" });
                this.ActiveControl = this.txt_AnsD;
                validate = false;
            }

            return validate;
        }

        private object[] GetAllDataOfQuestion()
        {
            return new object[] {txt_QuestionCode.Text, cmb_CourseCode.SelectedValue, cmb_Level.SelectedValue,
                    txt_QuestionContent.Text, txt_AnsA.Text, txt_AnsB.Text, txt_AnsC.Text,
                    txt_AnsD.Text, cmb_TrueAnswer.Text, Program.username};
        }

        private DataTable SetUpCurrentData(object[] datas)
        {
            DataTable table = new DataTable();

            DataColumn []dcs = new DataColumn[] { new DataColumn("Số câu"), new DataColumn("Mã môn học")
                                                ,new DataColumn("Trình độ"), new DataColumn("Nội dung")
                                                ,new DataColumn("A"), new DataColumn("B")
                                                ,new DataColumn("C"), new DataColumn("D")
                                                ,new DataColumn("Đáp Án Đúng"), new DataColumn("Mã giáo viên")};

            table.Columns.AddRange(dcs);

            DataRow dr = table.NewRow();
            dr.ItemArray = datas;
            table.Rows.Add(dr);

            return table;
        }

        private void AutoFillForAddAction()
        {
            txt_QuestionCode.Text = GetIndexCodeForQuestion().ToString();
        }

    }
}

