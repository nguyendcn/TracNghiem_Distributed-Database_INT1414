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
using DevExpress.XtraGrid.Views.Base;
using System.Diagnostics;
using TracNghiem_CSDLPT.Share;
using TracNghiem_CSDLPT.SupportForm;
using DevExpress.XtraBars.Controls;
using DevExpress.XtraBars;
using System.Data.SqlClient;
using TracNghiem_CSDLPT.Common;


namespace TracNghiem_CSDLPT
{
    public partial class frm_NhapMH : DevExpress.XtraEditors.XtraForm
    {
        private CallBackAction _callAction;
        public frm_NhapMH()
        {
            InitializeComponent();

            _callAction = new CallBackAction();

            bs_MonHoc.CurrentChanged += Bs_MonHoc_CurrentChanged;
        }

        private void Bs_MonHoc_CurrentChanged(object sender, EventArgs e)
        {
            if (bs_MonHoc.Position != -1)
            {
                txt_CodeCourse.Text = ((DataRowView)bs_MonHoc[bs_MonHoc.Position])["MAMH"].ToString().Trim();
                txt_NameCourse.Text = ((DataRowView)bs_MonHoc[bs_MonHoc.Position])["TENMH"].ToString().Trim();
            }
        }

        private void frm_NhapMH_Load(object sender, EventArgs e)
        {


            this.ds_TN_CSDLPT.EnforceConstraints = false;

            this.tbla_BangDiem.Connection.ConnectionString = Program.connstr;
            this.tbla_BangDiem.Fill(this.ds_TN_CSDLPT.BANGDIEM);

            this.tbla_BoDe.Connection.ConnectionString = Program.connstr;
            this.tbla_BoDe.Fill(this.ds_TN_CSDLPT.BODE);

            this.tbla_GVDK.Connection.ConnectionString = Program.connstr;
            this.tbla_GVDK.Fill(this.ds_TN_CSDLPT.GIAOVIEN_DANGKY);

            this.tbla_MonHoc.Connection.ConnectionString = Program.connstr;
            this.tbla_MonHoc.Fill(this.ds_TN_CSDLPT.MONHOC);
            this.ds_TN_CSDLPT.EnforceConstraints = false;
        }

        private void btn_Add_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.btn_Exit.Tag = "ADD";
            this.btn_Write.Tag = "ADD";

            SetUpButtonForAction();
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
                        WriteToDB();

                        Frm_ActionInfo info = new Frm_ActionInfo(
                                            new Object[] { this.splc_Container, this.brm_Option },
                                            new CallBackAction(Share.Action.AddSuccess, this._callAction.Table)
                                            );

                        info.Parent = this;
                        info.BringToFront();
                        info.Show();
                    }
                }
                else if (this.btn_Write.Tag.Equals("EDIT"))
                {
                    bool editSuccess =  Edit();

                    if (editSuccess)
                    {
                        WriteToDB();
                        DataTable dt =  SetUpCurrentData(((DataRowView)bs_MonHoc.Current).Row.ItemArray);

                        Frm_ActionInfo frm_edit = new Frm_ActionInfo(
                                            new Object[] { this.splc_Container, this.brm_Option },
                                            new CallBackAction(Share.Action.EditSuccess,
                                                               SetUpCurrentData(new object[] {txt_CodeCourse.Text, txt_NameCourse.Text }))
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
                if (ex.Message.Contains("MAMH"))
                    MessageBox.Show("Mã môn học không được trùng", "", MessageBoxButtons.OK);
                else
                {
                    MessageBox.Show("Lỗi ghi Môn học. " + ex.Message, "", MessageBoxButtons.OK);
                }
            }
        }

        private void btn_Edit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.btn_Write.Tag = "EDIT";
            this.btn_Exit.Tag = "EDIT";

            SetUpButtonForAction();
        }

        private void btn_Delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Delete();
        }

        private void btn_Exit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

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

        public bool ValidateEmpty()
        {
            if (txt_CodeCourse.Text.Trim().Equals(String.Empty))
            {
                ErrorHandler.ShowError(lbl_Err_CodeCourse, new string[] { "Ox0001" });
                this.ActiveControl = this.txt_CodeCourse;
                return false;
            }

            if (txt_NameCourse.Text.Trim().Equals(String.Empty))
            {
                ErrorHandler.ShowError(lbl_Err_NameCourse, new string[] { "Ox0001" });
                this.ActiveControl = this.txt_NameCourse;
                return false;
            }

            return true;
        }

        public DataTable SetUpCurrentData(object[] datas)
        {
            DataTable table = new DataTable();

            DataColumn dc = new DataColumn("Mã môn học");
            table.Columns.Add(dc);

            dc = new DataColumn("Tên môn học");
            table.Columns.Add(dc);

            DataRow dr = table.NewRow();
            dr.ItemArray = datas;
            table.Rows.Add(dr);

            return table;
        }

        public void RecoveryDataByAction(CallBackAction cAction)
        {
            if (cAction.BackAction == Share.Action.RecoveryAdd)
            {
                DataRow dr = cAction.Table.Rows[0];
                int index = bs_MonHoc.Find("MAMH", dr.ItemArray[0]);
                bs_MonHoc.RemoveAt(index);
                WriteToDB();
            }
            else if (cAction.BackAction == Share.Action.RecoveryDelete)
            {
                DataView dt = (DataView)bs_MonHoc.List;
                dt.Sort = "MAMH";
                if (dt.FindRows(cAction.Table.Rows[0]).Length != 0)
                {
                    MessageBox.Show("Mã môn học đã tồn tại.Vui lòng nhập lại!");
                }
                else
                {
                    DataRow dr = cAction.Table.Rows[0];
                    DataRowView drv = (DataRowView)bs_MonHoc.AddNew();
                    drv.Row.ItemArray = dr.ItemArray;
                    WriteToDB();
                }
            }
            else if (cAction.BackAction == Share.Action.RecoveryEdit)
            {
                DataRow dr = cAction.Table.Rows[0];
                bs_MonHoc.Position = bs_MonHoc.Find("MAMH", dr.ItemArray[0]);

                DataRowView currentRow = (DataRowView)bs_MonHoc.Current;

                currentRow.Row.ItemArray = dr.ItemArray;
                WriteToDB();
            }

            this._callAction.Reset();
            this.Refresh();
        }

        public void SetUpButtonForAction()
        {
            this.pnl_ConstructArea.Enabled = true;
            this.btn_Add.Enabled = false;
            this.btn_Edit.Enabled = false;
            this.btn_Delete.Enabled = false;

            this.lbl_Err_CodeCourse.Text = this.lbl_Err_NameCourse.Text = "";

            if (this.btn_Write.Tag.Equals("ADD"))
            {
                this.txt_CodeCourse.Text = this.txt_NameCourse.Text = "";
                this.ActiveControl = this.txt_CodeCourse;
                try
                {
                    this.bs_MonHoc.CurrentChanged -= Bs_MonHoc_CurrentChanged;
                }
                catch (ArgumentNullException anex)
                {
                    Debug.WriteLine(anex.Message);
                }
            }
        }

        public void FreeAllControl()
        {
            this.pnl_ConstructArea.Enabled = false;
            this.btn_Add.Enabled = true;
            this.btn_Edit.Enabled = true;
            this.btn_Delete.Enabled = true;

            this.btn_Exit.Tag = this.btn_Write.Tag = "";
            
            try
            {
                this.bs_MonHoc.CurrentChanged -= Bs_MonHoc_CurrentChanged;
                this.bs_MonHoc.CurrentChanged += Bs_MonHoc_CurrentChanged;
            }
            catch (ArgumentNullException anex)
            {
                this.bs_MonHoc.CurrentChanged += Bs_MonHoc_CurrentChanged;

                Debug.WriteLine(anex.Message);
            }

        }

        private bool CourseIsExists()
        {
            DataView dt = (DataView)bs_MonHoc.List;
            dt.Sort = "MAMH";
            if (dt.FindRows(txt_CodeCourse.Text).Length != 0)
            {
                return true;
            }
            return false;
        }

        public bool Add()
        {
            bool isEmpty = ValidateEmpty();

            if (!isEmpty)
                return false;

            if (CourseIsExists())
            {
                ErrorHandler.ShowError(lbl_Err_CodeCourse, new string[] { "Ox1001" });
                return false;
            }
            else
            {
                object[] data = new object[] { txt_CodeCourse.Text, txt_NameCourse.Text };
                DataRowView drv = (DataRowView)bs_MonHoc.AddNew();
                drv.Row.ItemArray = data;

                this._callAction.FillData(Share.Action.RecoveryAdd, SetUpCurrentData(data));
                return true;
            }
        }

        public bool Edit()
        {
            bool isEmpty = ValidateEmpty();

            if (!isEmpty)
                return false;

            DataRowView currentRow = (DataRowView)bs_MonHoc.Current;

            if (currentRow != null)
            {
                DataView dt = (DataView)bs_MonHoc.List;
                dt.Sort = "MAMH";
                DataRowView[] rowsFound = dt.FindRows(txt_CodeCourse.Text.Trim());

                bool isExists = false;
                if (rowsFound.Length != 0)
                {
                    IEnumerable<DataRowView> exists = rowsFound.Where(x => x.Row.ItemArray[0].ToString().Trim().Equals(currentRow.Row.ItemArray[0].ToString().Trim()));
                    isExists = exists.ToList().Count == 0;
                }
                
                if (isExists)
                {
                    ErrorHandler.ShowError(lbl_Err_CodeCourse, new string[] { "Ox1001" });
                    this.ActiveControl = this.txt_CodeCourse;
                    return false;
                }
                else
                {
                    ShowContentTable(SetUpCurrentData(currentRow.Row.ItemArray));
                    this._callAction.FillData(Share.Action.RecoveryEdit, SetUpCurrentData(currentRow.Row.ItemArray));

                    object[] data = new object[] { txt_CodeCourse.Text, txt_NameCourse.Text };
                    currentRow.Row.ItemArray = data;

                    return true;
                }
            }
            else
            {
                XtraMessageBox.Show(StringLibrary.E_EditEmpty, StringLibrary.E_EditNotify, MessageBoxButtons.OK);
                return false;
            }
        }

        public void Delete()
        {
            DataRowView currentRow = (DataRowView)bs_MonHoc.Current;
            if(AbleDelete())
            {
                Frm_ActionInfo frm_delete = new Frm_ActionInfo(
                    new Object[] { this.splc_Container, this.brm_Option },
                    new CallBackAction(Share.Action.RecoveryDelete, SetUpCurrentData(currentRow.Row.ItemArray)));

                frm_delete.Choosen += (result) =>
                {
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            this._callAction.FillData(Share.Action.RecoveryDelete, SetUpCurrentData(currentRow.Row.ItemArray));

                            bs_MonHoc.RemoveCurrent();
                            WriteToDB();
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

        public bool AbleDelete()
        {
            if (bs_GVDK.Count != 0)
            {
                MessageBox.Show("Không thể xóa môn học. Vì môn học đã được đăng ký thi.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (bs_BangDiem.Count != 0)
            {
                MessageBox.Show("Không thể xóa môn học. Vì môn học đã được thi.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (bs_BoDe.Count != 0)
            {
                MessageBox.Show("Không thể xóa môn học. Vì môn học đã được lập bộ đề.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }


        public void WriteToDB()
        {
            bs_MonHoc.EndEdit();
            bs_MonHoc.ResetCurrentItem();
            this.tbla_MonHoc.Update(this.ds_TN_CSDLPT.MONHOC);
        }


        private void Txt_InputText_DoubleClick(object sender, EventArgs e)
        {
            (sender as TextBox).SelectAll();
        }

        private void ShowContentTable(DataTable dt)
        {
            Debug.WriteLine("Start table: ");
            foreach (DataRow row in dt.Rows)
            {
                string ID = row["Mã môn học"].ToString();
                string Name = row["Tên môn học"].ToString();

                Debug.WriteLine("{" + ID + ", " + Name + "}");
            }
            Debug.WriteLine("End table");
        }
    }
}