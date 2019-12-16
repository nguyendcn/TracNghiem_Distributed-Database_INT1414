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

        public Frm_NhapKhoa()
        {
            InitializeComponent();

            this._callAction = new CallBackAction();

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
                    bool editSuccess = Edit();

                    if (editSuccess)
                    {
                        WriteToDB();
                        DataTable dt = SetUpCurrentData(((DataRowView)bs_Khoa.Current).Row.ItemArray);

                        Frm_ActionInfo frm_edit = new Frm_ActionInfo(
                                            new Object[] { this.splc_Container, this.brm_Option },
                                            new CallBackAction(Share.Action.EditSuccess,
                                                               SetUpCurrentData(new object[] { txt_CodeBrand.Text, txt_NameDepartment.Text, txt_CodeBrand }))
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
            DialogResult dialogResult = MessageBox.Show("Phục hồi dữ liệu", "Bạn có chắc muống phục hồi dữ liệu khoa không?",
                                                         MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    this.tbla_Khoa.Fill(this.ds_TN_CSDLPT.KHOA);

                    this.tbla_GiaoVien.Fill(this.ds_TN_CSDLPT.GIAOVIEN);
                    MessageBox.Show("Phục hồi dữ liệu thành công.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                DataRowView drv = (DataRowView)bs_GiaoVien.AddNew();

                dgv_Teachers.CurrentRow.Cells[0].ReadOnly = false;
                dgv_Teachers.CurrentRow.Cells[1].ReadOnly = false;
                dgv_Teachers.CurrentRow.Cells[2].ReadOnly = false;
                dgv_Teachers.CurrentRow.Cells[3].ReadOnly = false;

                dgv_Teachers.CellValidating += dgv_GiaoVien_CellValidating;

                Debug.WriteLine("First Is new Row: " + dgv_Teachers.CurrentRow.IsNewRow);

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message);
            }
        }

        private void tsmi_Edit_Click(object sender, EventArgs e)
        {
            dgv_Teachers.CurrentRow.Cells[1].ReadOnly = false;
            dgv_Teachers.CurrentRow.Cells[2].ReadOnly = false;
            dgv_Teachers.CurrentRow.Cells[3].ReadOnly = false;
        }

        private void tsmi_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                DataRowView currentRow = (DataRowView)bs_Lop.Current;

                if (bs_BoDe.Count != 0)
                {
                    MessageBox.Show("Không thể xóa giáo viên này. Vì giáo viên này đã lập đề thi.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if(bs_GVDK.Count != 0)
                {
                    MessageBox.Show("Không thể xóa giáo viên này. Vì iáo viên đăng ký thi.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show(
                    currentRow.Row.ItemArray.ToString(),
                    "Xoá",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialogResult == DialogResult.Yes)
                    {
                        try
                        {
                            bs_GiaoVien.RemoveCurrent();
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
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muống phục hồi dữ liệu giáo viên không?",
                                                       "Phục hồi dữ liệu",
                                                       MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    this.tbla_GiaoVien.Fill(ds_TN_CSDLPT.GIAOVIEN);
                    MessageBox.Show("Phục hồi dữ liệu thành công.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgv_GiaoVien_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string headerText =
           dgv_Teachers.Columns[e.ColumnIndex].HeaderText;
            if (headerText.Equals("MAGV"))
            {
                //string valCurrent = e.FormattedValue.ToString();
                //if (StudentCodeIsExists(valCurrent))
                //{
                //    e.Cancel = true;
                //    dgv_Students.Rows[e.RowIndex].ErrorText = "Student Code Exist.";

                //    MessageBox.Show("Mã sinh viên đã tồn tại vui lòng nhập lại.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
            }
        }


        private void dgv_GiaoVien_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            dgv_Teachers.Rows[e.RowIndex].ErrorText = null;
        }

        private void dgv_GiaoVien_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            dgv_Teachers.Rows[e.RowIndex].ErrorText = null;

            try
            {
                dgv_Teachers.CellValidating -= dgv_GiaoVien_CellValidating;

            }
            catch (Exception ex)
            {

            }
        }

        private void dgv_GiaoVien_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                foreach (DataGridViewCell drv in dgv_Teachers.Rows[e.RowIndex].Cells)
                {
                    if (String.IsNullOrEmpty(drv.Value.ToString()))
                    {
                        e.Cancel = true;

                        dgv_Teachers.Rows[e.RowIndex].ErrorText = "Dose not empty.";

                        MessageBox.Show("Không được để trống.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        dgv_Teachers.CurrentCell = drv;

                        return;
                    }
                }
            }
            catch { }
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

        public void RecoveryDataByAction(CallBackAction cAction)
        {
            if (cAction.BackAction == Share.Action.RecoveryAdd)
            {
                DataRow dr = cAction.Table.Rows[0];
                int index = bs_Khoa.Find("MAKH", dr.ItemArray[0]);
                bs_Khoa.RemoveAt(index);
                WriteToDB();
            }
            else if (cAction.BackAction == Share.Action.RecoveryDelete)
            {
                DataView dt = (DataView)bs_Khoa.List;
                dt.Sort = "MAMH";
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

        public void SetUpButtonForAction()
        {
            this.pnl_ConstructArea.Enabled = true;
            this.btn_Add.Enabled = false;
            this.btn_Edit.Enabled = false;
            this.btn_Delete.Enabled = false;

            this.lbl_Error_CodeDepart.Text = this.lbl_Error_NameDepart.Text = "";

            if (this.btn_Write.Tag.Equals("ADD"))
            {
                this.lbl_Error_CodeDepart.Text = this.lbl_Error_NameDepart.Text = "";
                this.ActiveControl = this.lbl_Error_CodeDepart;
                try
                {
                    this.bs_Khoa.CurrentChanged -= Bs_Khoa_CurrentChanged;
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
                    ShowContentTable(SetUpCurrentData(currentRow.Row.ItemArray));
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
                    new CallBackAction(Share.Action.RecoveryDelete, SetUpCurrentData(currentRow.Row.ItemArray)));

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

        private DataRowView[] FindCurrentDataByDepartmentCode(String departmentCode)
        {
            DataView dt = (DataView)bs_Khoa.List;
            dt.Sort = "MAKH";
           return dt.FindRows(departmentCode);
        }


        private bool DepartmentIsExists(String departmentCode)
        {
            bool isExistInCurrentData = (FindCurrentDataByDepartmentCode(departmentCode)).Length > 0;
            bool isExistOnDatabase = SqlRequestFunction.DepartmentIsExist(departmentCode);

            return isExistInCurrentData || isExistOnDatabase;
        }
    }
}