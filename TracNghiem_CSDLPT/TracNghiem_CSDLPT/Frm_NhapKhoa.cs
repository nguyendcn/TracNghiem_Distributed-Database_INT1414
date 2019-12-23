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
using TracNghiem_CSDLPT.Share;
using TracNghiem_CSDLPT.SupportForm;
using TracNghiem_CSDLPT.Common;

namespace TracNghiem_CSDLPT
{
    public partial class Frm_NhapKhoa : DevExpress.XtraEditors.XtraForm
    {
        private CallBackAction _callAction;
        private CallBackAction _callBackSubform;

        public Frm_NhapKhoa()
        {
            InitializeComponent();

            this._callAction = new CallBackAction();
            this._callBackSubform = new CallBackAction();

            bs_Khoa.CurrentChanged += Bs_Khoa_CurrentChanged;
        }

        private void Bs_Khoa_CurrentChanged(object sender, EventArgs e)
        {
            if (bs_Khoa.Position != -1)
            {
                txt_CodeDepartment.Text = ((DataRowView)bs_Khoa[bs_Khoa.Position])["MAKH"].ToString().Trim();
                txt_NameDepartment.Text = ((DataRowView)bs_Khoa[bs_Khoa.Position])["TENKH"].ToString().Trim();
                txt_CodeBrand.Text = ((DataRowView)bs_Khoa[bs_Khoa.Position])["MACS"].ToString().Trim();
            }
        }

        private void kHOABindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bs_Khoa.EndEdit();
            this.tableAdapterManager.UpdateAll(this.ds_TN_CSDLPT);

        }

        private void Frm_NhapKhoa_Load(object sender, EventArgs e)
        {

            this.ds_TN_CSDLPT.EnforceConstraints = false;

            this.tbla_GVDK.Connection.ConnectionString = Program.connstr;
            this.tbla_GVDK.Fill(this.ds_TN_CSDLPT.GIAOVIEN_DANGKY);

            this.tbla_BoDe.Connection.ConnectionString = Program.connstr;
            this.tbla_BoDe.Fill(this.ds_TN_CSDLPT.BODE);

            this.tbla_GiaoVien.Connection.ConnectionString = Program.connstr;
            this.tbla_GiaoVien.Fill(this.ds_TN_CSDLPT.GIAOVIEN);

            this.tbla_Lop.Connection.ConnectionString = Program.connstr;
            this.tbla_Lop.Fill(this.ds_TN_CSDLPT.LOP);

            this.tbla_Khoa.Connection.ConnectionString = Program.connstr;
            this.tbla_Khoa.Fill(this.ds_TN_CSDLPT.KHOA);

            this.ds_TN_CSDLPT.EnforceConstraints = false;
        }

        private void btn_Add_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.btn_Exit.Tag = "ADD";
            this.btn_Write.Tag = "ADD";

            SetUpButtonForAction();
        }

        private void btn_Edit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            this.btn_Write.Tag = "EDIT";
            this.btn_Exit.Tag = "EDIT";

            SetUpButtonForAction();
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
                        this.dgv_Teachers.DataSource = bs_GiaoVien;
                        WriteToDB();

                        Frm_ActionInfo info = new Frm_ActionInfo(
                                            new Object[] { this.splc_Container, this.brm_Option },
                                            new CallBackAction(Share.Action.AddSuccess, this._callAction.Table)
                                            );

                        info.Parent = this;
                        info.BringToFront();
                        info.Show();

                        //this.dgv_Teachers.DataSource = this.bs_GiaoVien;
                        //this.grv_Khoa.Enabled = false;
                    }
                }
                else if (this.btn_Write.Tag.Equals("EDIT"))
                {
                    bool editSuccess = Edit();

                    if (editSuccess)
                    {
                        WriteToDB();
                        DataTable dt = SetUpCurrentData(((DataRowView)bs_Khoa.Current).Row.ItemArray);

                        Frm_ActionInfo frm_edit = new Frm_ActionInfo(
                                            new Object[] { this.splc_Container, this.brm_Option },
                                            new CallBackAction(Share.Action.EditSuccess,
                                                               SetUpCurrentData(new object[] { txt_CodeDepartment.Text, txt_NameDepartment.Text, txt_CodeBrand.Text }))
                                            );

                        frm_edit.Parent = this;
                        frm_edit.BringToFront();
                        frm_edit.Show();

                        pnl_grv.Enabled = true;
                        bs_Khoa.DataSource = ds_TN_CSDLPT;
                        grv_Khoa.Refresh();
                        
                        
                        dgv_Teachers.Refresh();
                        
                    }
                }
                else return;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MAKH"))
                    MessageBox.Show("Mã Khoa không được trùng", "", MessageBoxButtons.OK);
                else
                {
                    MessageBox.Show("Lỗi ghi Khoa" + ex.Message, "", MessageBoxButtons.OK);
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

        private void tsmi_Add_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGVHadError(dgv_Teachers))
                    return;

                _callBackSubform.BackAction = Share.Action.RecoveryAdd;

                DataRowView drv = (DataRowView)bs_GiaoVien.AddNew();

                dgv_Teachers.CurrentRow.Cells[0].ReadOnly = false;
                dgv_Teachers.CurrentRow.Cells[1].ReadOnly = false;
                dgv_Teachers.CurrentRow.Cells[2].ReadOnly = false;
                dgv_Teachers.CurrentRow.Cells[3].ReadOnly = false;

                dgv_Teachers.RowValidating += Dgv_Teachers_RowValidating;
                dgv_Teachers.RowValidated += Dgv_Teachers_RowValidated;

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message);
            }
        }

        private void tsmi_Edit_Click(object sender, EventArgs e)
        {
            _callBackSubform.BackAction = Share.Action.RecoveryEdit;

            dgv_Teachers.CurrentRow.Cells[1].ReadOnly = false;
            dgv_Teachers.CurrentRow.Cells[2].ReadOnly = false;
            dgv_Teachers.CurrentRow.Cells[3].ReadOnly = false;

            object[] data = ((DataRowView)bs_GiaoVien.Current).Row.ItemArray;
            this._callBackSubform.Table = SetUpCurrentDataSub(data);

            dgv_Teachers.RowValidating += Dgv_Teachers_RowValidating;
            dgv_Teachers.RowValidated += Dgv_Teachers_RowValidated;
        }

        private void tsmi_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                DataRowView currentRow = (DataRowView)bs_GiaoVien.Current;

                if (bs_BoDe.Count != 0)
                {
                    MessageBox.Show("Không thể xóa giáo viên này. Vì giáo viên này đã lập đề thi.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if(bs_GVDK.Count != 0)
                {
                    MessageBox.Show("Không thể xóa giáo viên này. Vì giáo viên đăng ký thi.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    object[] data = currentRow.Row.ItemArray;
                    DialogResult dialogResult = MessageBox.Show(
                    "Có chắc muốn xóa giáo viên: " + data[1] + " " + data[2],
                    "Xoá",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialogResult == DialogResult.Yes)
                    {
                        try
                        {
                            bs_GiaoVien.RemoveCurrent();
                            SaveTeacherToDb();

                            this._callBackSubform.Table = SetUpCurrentDataSub(data);
                            _callBackSubform.BackAction = Share.Action.RecoveryDelete;

                            MessageBox.Show("Xóa thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Can not delete row because: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message);
            }
        }

        private void tsmi_Reset_Click(object sender, EventArgs e)
        {
            if(_callBackSubform.BackAction == Share.Action.None)
            {
                MessageBox.Show("Không có dữ liệu để phục hồi. Vui lòng kiểm tra lại!", "Phục hồi",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                Frm_ActionInfo frm_Recovery = new Frm_ActionInfo(
                    new Object[] { this.splc_Container, this.brm_Option },
                    this._callBackSubform);

                frm_Recovery.Choosen += (result) =>
                {
                    if (result == DialogResult.Yes)
                    {
                        RecoveryDataByActionSub(this._callBackSubform);
                    }
                };

                frm_Recovery.Parent = this;
                frm_Recovery.BringToFront();
                frm_Recovery.Show();
            }
        }

        private void dgv_GiaoVien_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string headerText =
           dgv_Teachers.Columns[e.ColumnIndex].HeaderText;
            if (headerText.Equals("MAGV"))
            {
                string valCurrent = e.FormattedValue.ToString();
                if (SqlRequestFunction.TeacherIsExists(valCurrent))
                {
                   
                    //dgv_Teachers.Rows[e.RowIndex].ErrorText = "Had error";
                    //dgv_Teachers.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "Teacher Code Is Exists.";
                    //dgv_Teachers.CurrentCell = dgv_Teachers.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    //e.Cancel = true;
                }
            }
        }

        private void dgv_GiaoVien_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            Debug.WriteLine("Cell validated");
            dgv_Teachers.Rows[e.RowIndex].ErrorText = null;
        }

        public bool ValidateEmpty()
        {
            if (txt_CodeDepartment.Text.Trim().Equals(String.Empty))
            {
                ErrorHandler.ShowError(lbl_Error_CodeDepart, new string[] { "Ox0001" });
                this.ActiveControl = this.txt_CodeDepartment;
                return false;
            }

            if (txt_NameDepartment.Text.Trim().Equals(String.Empty))
            {
                ErrorHandler.ShowError(lbl_Error_NameDepart, new string[] { "Ox0001" });
                this.ActiveControl = this.txt_NameDepartment;
                return false;
            }

            return true;
        }

        public DataTable SetUpCurrentData(object[] datas)
        {
            DataTable table = new DataTable();

            DataColumn dc = new DataColumn("Mã khoa");
            table.Columns.Add(dc);

            dc = new DataColumn("Tên khoa");
            table.Columns.Add(dc);

            dc = new DataColumn("Mã cơ sở");
            table.Columns.Add(dc);

            DataRow dr = table.NewRow();
            dr.ItemArray = datas;
            table.Rows.Add(dr);

            return table;
        }

        public DataTable SetUpCurrentDataSub(object[] datas)
        {
            DataTable table = new DataTable();

            DataColumn dc = new DataColumn("Mã giáo viên");
            table.Columns.Add(dc);

            dc = new DataColumn("Họ");
            table.Columns.Add(dc);

            dc = new DataColumn("Tên");
            table.Columns.Add(dc);

            dc = new DataColumn("Địa chỉ");
            table.Columns.Add(dc);

            dc = new DataColumn("Mã Khoa");
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
                int index = bs_Khoa.Find("MAKH", dr.ItemArray[0]);

                if(bs_GiaoVien.Count != 0)
                {
                    MessageBox.Show("Không thể phục hồi khoa. Vì khoa này đã có giáo viên.",
                        "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                }
                bs_Khoa.RemoveAt(index);
                WriteToDB();
            }
            else if (cAction.BackAction == Share.Action.RecoveryDelete)
            {
                DataView dt = (DataView)bs_Khoa.List;
                dt.Sort = "MAKH";
                if (dt.FindRows(cAction.Table.Rows[0]).Length != 0)
                {
                    MessageBox.Show("Mã môn học đã tồn tại.Vui lòng nhập lại!");
                }
                else
                {
                    DataRow dr = cAction.Table.Rows[0];
                    DataRowView drv = (DataRowView)bs_Khoa.AddNew();
                    drv.Row.ItemArray = dr.ItemArray;
                    WriteToDB();
                }
            }
            else if (cAction.BackAction == Share.Action.RecoveryEdit)
            {
                DataRow dr = cAction.Table.Rows[0];
                bs_Khoa.Position = bs_Khoa.Find("MAKH", dr.ItemArray[0]);

                DataRowView currentRow = (DataRowView)bs_Khoa.Current;

                currentRow.Row.ItemArray = dr.ItemArray;
                WriteToDB();
            }

            this._callAction.Reset();
            this.Refresh();
        }

        public void RecoveryDataByActionSub(CallBackAction cAction)
        {
            if (cAction.BackAction == Share.Action.RecoveryAdd)
            {
                DataView dt = (DataView)bs_GiaoVien.List;
                
                DataRow dr = cAction.Table.Rows[0];
                String key = dr.ItemArray[0].ToString();
                int index = dt.Find(key);

                bs_GiaoVien.RemoveAt(index);

                SaveTeacherToDb();
            }
            else if (cAction.BackAction == Share.Action.RecoveryDelete)
            {
                DataView dt = (DataView)bs_GiaoVien.List;
                dt.Sort = "MAGV";
                if (dt.FindRows(cAction.Table.Rows[0]).Length != 0)
                {
                    MessageBox.Show("Mã giáo viên đã tồn tại.Vui lòng nhập lại!");
                }
                else
                {
                    DataRow dr = cAction.Table.Rows[0];
                    DataRowView drv = (DataRowView)bs_GiaoVien.AddNew();
                    drv.Row.ItemArray = dr.ItemArray;

                    SaveTeacherToDb();
                }
            }
            else if (cAction.BackAction == Share.Action.RecoveryEdit)
            {
                DataView dt = (DataView)bs_GiaoVien.List;

                DataRow dr = cAction.Table.Rows[0];
                String key = dr.ItemArray[0].ToString();
                int index = dt.Find(key);

                bs_GiaoVien.Position = index;

                DataRowView currentRow = (DataRowView)bs_GiaoVien.Current;

                currentRow.Row.ItemArray = dr.ItemArray;
                SaveTeacherToDb();
            }

            this._callBackSubform.Reset();
            this.Refresh();
        }

        public void SetUpButtonForAction()
        {
            this.splc_ConstructArea.Enabled = true;
            this.btn_Add.Enabled = false;
            this.btn_Edit.Enabled = false;
            this.btn_Delete.Enabled = false;
            //this.pnl_grv.Enabled = false;

            this.lbl_Error_CodeDepart.Text = this.lbl_Error_NameDepart.Text = "";

            if (this.btn_Write.Tag.Equals("ADD"))
            {
                this.dgv_Teachers.DataSource = null;
                this.txt_NameDepartment.Text = this.txt_CodeDepartment.Text = "";
                this.ActiveControl = this.txt_CodeDepartment;
            }
            else if (this.btn_Write.Tag.Equals("EDIT"))
            {
                //this.txt_CodeDepartment.Enabled = false;
                this.pnl_grv.Enabled = false;
            }

            try
            {
                this.bs_Khoa.CurrentChanged -= Bs_Khoa_CurrentChanged;
            }
            catch (ArgumentNullException anex)
            {
                Debug.WriteLine(anex.Message);
            }
        }

        public void FreeAllControl()
        {
            this.splc_ConstructArea.Enabled = false;
            this.btn_Add.Enabled = true;
            this.btn_Edit.Enabled = true;
            this.btn_Delete.Enabled = true;
            this.pnl_grv.Enabled = true;
            this.dgv_Teachers.DataSource = bs_GiaoVien;

            this.btn_Exit.Tag = this.btn_Write.Tag = "";

            try
            {
                this.bs_Khoa.CurrentChanged -= Bs_Khoa_CurrentChanged;
                this.bs_Khoa.CurrentChanged += Bs_Khoa_CurrentChanged;
            }
            catch (ArgumentNullException anex)
            {
                this.bs_Khoa.CurrentChanged += Bs_Khoa_CurrentChanged;

                Debug.WriteLine(anex.Message);
            }

        }

        public bool Add()
        {
            bool isEmpty = ValidateEmpty();

            if (!isEmpty)
                return false;

            if (DepartmentIsExists(txt_CodeDepartment.Text.Trim()))
            {
                ErrorHandler.ShowError(lbl_Error_CodeDepart, new string[] { "Ox1001" });
                return false;
            }
            else
            {
                object[] data = new object[] { txt_CodeDepartment.Text, txt_NameDepartment.Text, txt_CodeBrand.Text };
                DataRowView drv = (DataRowView)bs_Khoa.AddNew();
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

            DataRowView currentRow = (DataRowView)bs_Khoa.Current;

            if (currentRow != null)
            {
                DataView dt = (DataView)bs_Khoa.List;
                dt.Sort = "MAKH";
                DataRowView[] rowsFound = dt.FindRows(txt_CodeDepartment.Text.Trim());

                bool isExists = false;
                if (rowsFound.Length != 0)
                {
                    IEnumerable<DataRowView> exists = rowsFound.Where(x => x.Row.ItemArray[0].ToString().Trim().Equals(currentRow.Row.ItemArray[0].ToString().Trim()));
                    isExists = exists.ToList().Count == 0;
                }

                if (isExists)
                {
                    ErrorHandler.ShowError(lbl_Error_CodeDepart, new string[] { "Ox1001" });
                    this.ActiveControl = this.txt_CodeDepartment;
                    return false;
                }
                else
                {
                    this._callAction.FillData(Share.Action.RecoveryEdit, SetUpCurrentData(currentRow.Row.ItemArray));

                    object[] data = new object[] { txt_CodeDepartment.Text, txt_NameDepartment.Text };
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
            DataRowView currentRow = (DataRowView)bs_Khoa.Current;
            if (AbleDeleteDepart())
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

                            bs_Khoa.RemoveCurrent();
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

        public bool AbleDeleteDepart()
        {
            DataRowView currentRow = (DataRowView)bs_Khoa.Current;
            if (bs_GiaoVien.Count != 0)
            {
                MessageBox.Show("Không thể xóa khoa. Vì khoa này đã có giáo viên.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (bs_Lop.Count != 0)
            {
                MessageBox.Show("Không thể xóa khoa này. Vì khoa này đã có lớp.", "Error",
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
            bs_Khoa.EndEdit();
            bs_Khoa.ResetCurrentItem();
            this.tbla_Khoa.Update(this.ds_TN_CSDLPT.KHOA);
        }

        private void Txt_InputText_DoubleClick(object sender, EventArgs e)
        {
            (sender as TextBox).SelectAll();
        }

        private DataRowView[] FindCurrentDataByDepartmentCode(String departmentCode)
        {
            DataView dt = (DataView)bs_Khoa.List;
            dt.Sort = "MAKH";
           return dt.FindRows(departmentCode);
        }

        public void ShowAll(BindingSource src)
        {
            DataView dt = (DataView)src.List;
            DataTable table = dt.Table;

            Debug.WriteLine("Start show table content.");
            foreach (DataRow row in table.Rows)
            {
                string ID = row["MAKH"].ToString();
                string Name = row["TENKH"].ToString();
                string FamilyName = row["MACS"].ToString();

                Debug.WriteLine("{MAKH=" + ID + ", TENKH=" + Name + ", MACS=" + FamilyName + "}");
            }
        }

        public void ShowAllSub(BindingSource src)
        {
            DataView dt = (DataView)src.List;
            DataTable table = dt.Table;

            Debug.WriteLine("Start show table content.");
            foreach (DataRow row in table.Rows)
            {
                string ID = row["MAGV"].ToString();
                string Name = row["TEN"].ToString();
                string FamilyName = row["HO"].ToString();

                Debug.WriteLine("{MAGV=" + ID + ", TEN=" + Name + ", HO=" + FamilyName + "}");
            }
        }

        private bool DGVHadError(DataGridView dgv)
        {
            foreach(DataGridViewRow rowView in dgv.Rows)
            {
                bool a = rowView.IsNewRow;
                if(rowView.ErrorText != "" )
                {
                    return true;
                }
            }
            return false;
        }

        private void SaveTeacherToDb()
        {
            bs_GiaoVien.EndEdit();
            bs_GiaoVien.ResetCurrentItem();
            this.tbla_GiaoVien.Update(ds_TN_CSDLPT.GIAOVIEN);
        }

        private bool DepartmentIsExists(String departmentCode)
        {
            bool isExistInCurrentData = (FindCurrentDataByDepartmentCode(departmentCode)).Length > 0;
            bool isExistOnDatabase = SqlRequestFunction.DepartmentIsExist(departmentCode);

            return isExistInCurrentData || isExistOnDatabase;
        }

        private void dgv_Teachers_EnabledChanged(object sender, EventArgs e)
        {
        }

        private void Dgv_Teachers_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            dgv_Teachers.Rows[e.RowIndex].ErrorText = null;
            foreach(DataGridViewCell cell in dgv_Teachers.Rows[e.RowIndex].Cells)
            {
                cell.ErrorText = null;
            }

            try
            {
                dgv_Teachers.RowValidating -= Dgv_Teachers_RowValidating;
                dgv_Teachers.RowValidated -= Dgv_Teachers_RowValidated;

                SaveTeacherToDb();
                if (this._callBackSubform.BackAction == Share.Action.RecoveryAdd)
                {
                    object[] data = new object[] { dgv_Teachers.Rows[e.RowIndex].Cells[0].Value,
                                               dgv_Teachers.Rows[e.RowIndex].Cells[1].Value,
                                               dgv_Teachers.Rows[e.RowIndex].Cells[2].Value,
                                               dgv_Teachers.Rows[e.RowIndex].Cells[3].Value,
                                               dgv_Teachers.Rows[e.RowIndex].Cells[4].Value};
                    this._callBackSubform.Table = SetUpCurrentDataSub(data);
                }
                else if (this._callBackSubform.BackAction == Share.Action.RecoveryEdit)
                {
                    dgv_Teachers.CurrentRow.Cells[1].ReadOnly = true;
                    dgv_Teachers.CurrentRow.Cells[2].ReadOnly = true;
                    dgv_Teachers.CurrentRow.Cells[3].ReadOnly = true;
                }

                Debug.WriteLine("Rowvalidated");
            }
            catch (Exception ex)
            {

            }
        }

        private void Dgv_Teachers_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                bool isFirst = true;
                int index = 0;
                foreach (DataGridViewCell drv in dgv_Teachers.Rows[e.RowIndex].Cells)
                {
                    if (String.IsNullOrEmpty(drv.Value.ToString()))
                    {
                        e.Cancel = true;

                        dgv_Teachers.Rows[e.RowIndex].ErrorText = "Had error";
                        dgv_Teachers.Rows[e.RowIndex].Cells[index].ErrorText = "Dose not empty.";

                        dgv_Teachers.CurrentCell = drv;
                    }
                    else
                    {
                        dgv_Teachers.Rows[e.RowIndex].Cells[index].ErrorText = null;
                    }

                    if (isFirst)
                    {
                        string valCurrent = drv.FormattedValue.ToString();

                        if (SqlRequestFunction.TeacherIsExists(valCurrent))
                        {
                            dgv_Teachers.Rows[e.RowIndex].ErrorText = "Had error";
                            dgv_Teachers.Rows[e.RowIndex].Cells[index].ErrorText = "Teacher Code Is Exists.";
                            dgv_Teachers.CurrentCell = drv;
                        }
                        else
                        {
                            dgv_Teachers.Rows[e.RowIndex].Cells[index].ErrorText = null;
                        }

                        isFirst = false;
                    }
                    index++;
                }
            }
            catch { }
        }

    }
}
