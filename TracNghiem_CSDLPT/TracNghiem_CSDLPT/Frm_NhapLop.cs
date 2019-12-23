using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
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
    public partial class Frm_NhapLop : DevExpress.XtraEditors.XtraForm
    {
        DateTimePicker datePicker = new DateTimePicker();
        Rectangle _rectangle;

        private CallBackAction _callAction;
        private CallBackAction _callBackSubform;

        public Frm_NhapLop()
        {
            InitializeComponent();

            this.dgv_Students.Controls.Add(datePicker);
            datePicker.Visible = false;
            datePicker.Format = DateTimePickerFormat.Custom;

            datePicker.TextChanged += DatePicker_TextChanged;

            this._callAction = new CallBackAction();
            this._callBackSubform = new CallBackAction();

            bs_Lop.CurrentChanged += Bs_Lop_CurrentChanged;

            dgv_Students.CellClick += Dgv_Students_CellClick;
        }


        private void DatePicker_TextChanged(object sender, EventArgs e)
        {
            dgv_Students.CurrentCell.Value = datePicker.Text.ToString();
        }

        private void Bs_Lop_CurrentChanged(object sender, EventArgs e)
        {
            if (bs_Lop.Position != -1)
            {
                txt_CodeClass.Text = ((DataRowView)bs_Lop[bs_Lop.Position])["MALOP"].ToString().Trim();
                txt_NameClass.Text = ((DataRowView)bs_Lop[bs_Lop.Position])["TENLOP"].ToString().Trim();
                cmb_Khoa.SelectedIndex = 0;
            }
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
                        this.dgv_Students.DataSource = bs_SinhVien;

                        SaveClassToDb();

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
                        SaveClassToDb();
                        DataTable dt = SetUpCurrentData(((DataRowView)bs_Lop.Current).Row.ItemArray);

                        Frm_ActionInfo frm_edit = new Frm_ActionInfo(
                                            new Object[] { this.splc_Container, this.brm_Option },
                                            new CallBackAction(Share.Action.EditSuccess,
                                                               SetUpCurrentData(new object[] { txt_CodeClass.Text, txt_NameClass.Text, cmb_Khoa.SelectedValue }))
                                            );

                        frm_edit.Parent = this;
                        frm_edit.BringToFront();
                        frm_edit.Show();

                        pnl_grv.Enabled = true;
                        bs_Lop.DataSource = ds_TN_CSDLPT;
                        grv_Lop.Refresh();


                        dgv_Students.Refresh();

                    }
                }
                else return;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MALOP"))
                    MessageBox.Show("Mã lớp không được trùng", "", MessageBoxButtons.OK);
                else
                {
                    MessageBox.Show("Lỗi ghi Lớp" + ex.Message, "", MessageBoxButtons.OK);
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

        private void Frm_NhapLop_Load(object sender, EventArgs e)
        {

            this.ds_TN_CSDLPT.EnforceConstraints = false;

            this.tbla_GVDK.Connection.ConnectionString = Program.connstr;
            this.tbla_GVDK.Fill(this.ds_TN_CSDLPT.GIAOVIEN_DANGKY);

            this.tbla_BangDiem.Connection.ConnectionString = Program.connstr;
            this.tbla_BangDiem.Fill(this.ds_TN_CSDLPT.BANGDIEM);

            this.tbla_SinhVien.Connection.ConnectionString = Program.connstr;
            this.tbla_SinhVien.Fill(this.ds_TN_CSDLPT.SINHVIEN);

            this.tbla_Khoa.Connection.ConnectionString = Program.connstr;
            this.tbla_Khoa.Fill(this.ds_TN_CSDLPT.KHOA);

            this.tbla_Lop.Connection.ConnectionString = Program.connstr;
            this.tbla_Lop.Fill(this.ds_TN_CSDLPT.LOP);

        }


        public bool ValidateEmpty()
        {
            if (txt_CodeClass.Text.Trim().Equals(String.Empty))
            {
                ErrorHandler.ShowError(lbl_Error_CodeClass, new string[] { "Ox0001" });
                this.ActiveControl = this.txt_CodeClass;
                return false;
            }

            if (txt_CodeClass.Text.Trim().Equals(String.Empty))
            {
                ErrorHandler.ShowError(lbl_Error_NameClass, new string[] { "Ox0001" });
                this.ActiveControl = this.txt_NameClass;
                return false;
            }

            return true;
        }

        private void tsmi_Delete_Click(object sender, EventArgs e)
        {

            try
            {
                DataRowView currentRow = (DataRowView)bs_SinhVien.Current;

                if (bs_BangDiem.Count != 0)
                {
                    MessageBox.Show("Không thể xóa sinh viên này. Vì sinh viên này đã được lập bảng điểm.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    object[] data = currentRow.Row.ItemArray;
                    DialogResult dialogResult = MessageBox.Show(
                    "Có chắc muốn xóa sinh viên: " + data[1] + " " + data[2],
                    "Xoá",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialogResult == DialogResult.Yes)
                    {
                        try
                        {
                            bs_SinhVien.RemoveCurrent();
                            SaveStudentToDb();

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

        private void Dgv_Students_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_Students.CurrentCell.ReadOnly)
                return;

            if (e.ColumnIndex <= 0)
                return;

            if (dgv_Students.Columns[e.ColumnIndex].Name == "NGAYSINH")
            {
                try
                {
                    try
                    {
                        datePicker.Value = (DateTime)dgv_Students.CurrentCell.Value;
                    }
                    catch
                    {
                        datePicker.Value = DateTime.Now;
                    }

                    _rectangle = dgv_Students.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    datePicker.Size = new Size(_rectangle.Width, _rectangle.Height);
                    datePicker.Location = new Point(_rectangle.X, _rectangle.Y);
                    datePicker.Visible = true;
                }
                catch (Exception ex)
                {
                    return;
                }
            }
            else
            {
                if (datePicker.Visible)
                    datePicker.Visible = false;
            }
        }

        private void tsmi_Reset_Click(object sender, EventArgs e)
        {
            if (_callBackSubform.BackAction == Share.Action.None)
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

        private void tsmi_Edit_Click(object sender, EventArgs e)
        {
            _callBackSubform.BackAction = Share.Action.RecoveryEdit;

            dgv_Students.CurrentRow.Cells[1].ReadOnly = false;
            dgv_Students.CurrentRow.Cells[2].ReadOnly = false;
            dgv_Students.CurrentRow.Cells[3].ReadOnly = false;
            dgv_Students.CurrentRow.Cells[4].ReadOnly = false;

            object[] data = ((DataRowView)bs_SinhVien.Current).Row.ItemArray;
            this._callBackSubform.Table = SetUpCurrentDataSub(data);

            dgv_Students.RowValidating += Dgv_Students_RowValidating;
            dgv_Students.RowValidated += Dgv_Students_RowValidated;
        }

        private void tsmi_Add_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGVHadError(dgv_Students))
                    return;

                _callBackSubform.BackAction = Share.Action.RecoveryAdd;

                DataRowView drv = (DataRowView)bs_SinhVien.AddNew();

                dgv_Students.CurrentRow.Cells[0].ReadOnly = false;
                dgv_Students.CurrentRow.Cells[1].ReadOnly = false;
                dgv_Students.CurrentRow.Cells[2].ReadOnly = false;
                dgv_Students.CurrentRow.Cells[3].ReadOnly = false;
                dgv_Students.CurrentRow.Cells[4].ReadOnly = false;

                dgv_Students.RowValidating += Dgv_Students_RowValidating;
                dgv_Students.RowValidated += Dgv_Students_RowValidated;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message);
            }
        }

        private void dgv_Students_Scroll(object sender, ScrollEventArgs e)
        {
            datePicker.Visible = false;
        }

        private bool StudentCodeIsExists(String studentCode)
        {
            try
            {
                return SqlRequestFunction.StudentIsExist(studentCode);

            }
            catch (Exception ex)
            {
                Debug.Fail(ex.Message);
                return false;
            }
        }

        public void FreeAllControl()
        {
            this.splc_ConstructArea.Enabled = false;
            this.btn_Add.Enabled = true;
            this.btn_Edit.Enabled = true;
            this.btn_Delete.Enabled = true;
            this.pnl_grv.Enabled = true;
            this.dgv_Students.DataSource = bs_SinhVien;

            this.btn_Exit.Tag = this.btn_Write.Tag = "";

            try
            {
                this.bs_Lop.CurrentChanged -= Bs_Lop_CurrentChanged;
                this.bs_Lop.CurrentChanged += Bs_Lop_CurrentChanged;
            }
            catch (ArgumentNullException anex)
            {
                this.bs_Lop.CurrentChanged += Bs_Lop_CurrentChanged;

                Debug.WriteLine(anex.Message);
            }

        }

        public bool Add()
        {
            bool isEmpty = ValidateEmpty();

            if (!isEmpty)
                return false;

            if (DepartmentIsExists(txt_CodeClass.Text.Trim()))
            {
                ErrorHandler.ShowError(lbl_Error_CodeClass, new string[] { "Ox1001" });
                return false;
            }
            else
            {
                String codeDepartment = ((DataRowView)cmb_Khoa.SelectedItem).Row.ItemArray[0].ToString();
                object[] data = new object[] { txt_CodeClass.Text, txt_NameClass.Text, codeDepartment };
                DataRowView drv = (DataRowView)bs_Lop.AddNew();
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

            DataRowView currentRow = (DataRowView)bs_Lop.Current;

            if (currentRow != null)
            {
                DataView dt = (DataView)bs_Lop.List;
                dt.Sort = "MALOP";
                DataRowView[] rowsFound = dt.FindRows(txt_CodeClass.Text.Trim());

                bool isExists = false;
                if (rowsFound.Length != 0)
                {
                    IEnumerable<DataRowView> exists = rowsFound.Where(x => x.Row.ItemArray[0].ToString().Trim().Equals(currentRow.Row.ItemArray[0].ToString().Trim()));
                    isExists = exists.ToList().Count == 0;
                }

                if (isExists)
                {
                    ErrorHandler.ShowError(lbl_Error_CodeClass, new string[] { "Ox1001" });
                    this.ActiveControl = this.txt_CodeClass;
                    return false;
                }
                else
                {
                    this._callAction.FillData(Share.Action.RecoveryEdit, SetUpCurrentData(currentRow.Row.ItemArray));

                    String codeDepartment = ((DataRowView)cmb_Khoa.SelectedItem).Row.ItemArray[0].ToString();
                    object[] data = new object[] { txt_CodeClass.Text, txt_NameClass.Text, codeDepartment };
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
            DataRowView currentRow = (DataRowView)bs_Lop.Current;
            if (AbleDeleteClass())
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

                            bs_Lop.RemoveCurrent();
                            SaveClassToDb();
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

        public bool AbleDeleteClass()
        {
            DataRowView currentRow = (DataRowView)bs_Lop.Current;
            if (bs_GVDK.Count != 0)
            {
                MessageBox.Show("Không thể xóa lớp học này. Vì lớp học này đã được đăng ký thi.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (bs_SinhVien.Count != 0)
            {
                MessageBox.Show("Không thể xóa lớp học này. Vì lớp học đã có sinh viên theo học.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

        public void SaveClassToDb()
        {
            this.bs_Lop.EndEdit();
            this.bs_Lop.ResetCurrentItem();
            this.tbla_Lop.Update(this.ds_TN_CSDLPT.LOP);
        }

        public void SaveStudentToDb()
        {
            this.bs_SinhVien.EndEdit();
            this.bs_SinhVien.ResetCurrentItem();
            this.tbla_SinhVien.Update(this.ds_TN_CSDLPT.SINHVIEN);
        }

        public DataTable SetUpCurrentData(object[] datas)
        {
            DataTable table = new DataTable();

            DataColumn dc = new DataColumn("Mã lớp");
            table.Columns.Add(dc);

            dc = new DataColumn("Tên lớp");
            table.Columns.Add(dc);

            dc = new DataColumn("Mã khoa");
            table.Columns.Add(dc);

            DataRow dr = table.NewRow();
            dr.ItemArray = datas;
            table.Rows.Add(dr);

            return table;
        }

        public DataTable SetUpCurrentDataSub(object[] datas)
        {
            DataTable table = new DataTable();

            DataColumn dc = new DataColumn("Mã sinh viên");
            table.Columns.Add(dc);

            dc = new DataColumn("Họ");
            table.Columns.Add(dc);

            dc = new DataColumn("Tên");
            table.Columns.Add(dc);

            dc = new DataColumn("Ngày Sinh");
            table.Columns.Add(dc);

            dc = new DataColumn("Địa chỉ");
            table.Columns.Add(dc);

            dc = new DataColumn("Mã Lớp");
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
                int index = bs_Lop.Find("MALOP", dr.ItemArray[0]);
                bs_Lop.RemoveAt(index);
                SaveClassToDb();
            }
            else if (cAction.BackAction == Share.Action.RecoveryDelete)
            {
                DataView dt = (DataView)bs_Lop.List;
                dt.Sort = "MALOP";
                if (dt.FindRows(cAction.Table.Rows[0]).Length != 0)
                {
                    MessageBox.Show("Mã lớp đã tồn tại.Vui lòng nhập lại!");
                }
                else
                {
                    DataRow dr = cAction.Table.Rows[0];
                    DataRowView drv = (DataRowView)bs_Lop.AddNew();
                    drv.Row.ItemArray = dr.ItemArray;
                    SaveClassToDb();
                }
            }
            else if (cAction.BackAction == Share.Action.RecoveryEdit)
            {
                DataRow dr = cAction.Table.Rows[0];
                bs_Lop.Position = bs_Lop.Find("MALOP", dr.ItemArray[0]);

                DataRowView currentRow = (DataRowView)bs_Lop.Current;

                currentRow.Row.ItemArray = dr.ItemArray;
                SaveClassToDb();
            }

            this._callAction.Reset();
            this.Refresh();
        }

        public void RecoveryDataByActionSub(CallBackAction cAction)
        {
            if (cAction.BackAction == Share.Action.RecoveryAdd)
            {
                DataView dt = (DataView)bs_SinhVien.List;

                DataRow dr = cAction.Table.Rows[0];
                String key = dr.ItemArray[0].ToString();
                int index = dt.Find(key);

                bs_SinhVien.RemoveAt(index);

                SaveStudentToDb();
            }
            else if (cAction.BackAction == Share.Action.RecoveryDelete)
            {
                DataView dt = (DataView)bs_SinhVien.List;
                dt.Sort = "MASV";
                if (dt.FindRows(cAction.Table.Rows[0]).Length != 0)
                {
                    MessageBox.Show("Mã sinh viên đã tồn tại.Vui lòng nhập lại!");
                }
                else
                {
                    DataRow dr = cAction.Table.Rows[0];
                    DataRowView drv = (DataRowView)bs_SinhVien.AddNew();
                    drv.Row.ItemArray = dr.ItemArray;

                    SaveStudentToDb();
                }
            }
            else if (cAction.BackAction == Share.Action.RecoveryEdit)
            {
                DataView dt = (DataView)bs_SinhVien.List;

                DataRow dr = cAction.Table.Rows[0];
                String key = dr.ItemArray[0].ToString();
                int index = dt.Find(key);

                bs_SinhVien.Position = index;

                DataRowView currentRow = (DataRowView)bs_SinhVien.Current;

                currentRow.Row.ItemArray = dr.ItemArray;
                SaveStudentToDb();
            }

            this._callBackSubform.Reset();
            this.Refresh();
        }

        private void Dgv_Students_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            dgv_Students.Rows[e.RowIndex].ErrorText = null;
            foreach (DataGridViewCell cell in dgv_Students.Rows[e.RowIndex].Cells)
            {
                cell.ErrorText = null;
            }

            try
            {
                dgv_Students.RowValidating -= Dgv_Students_RowValidating;
                dgv_Students.RowValidated -= Dgv_Students_RowValidated;

                SaveStudentToDb();
                if (this._callBackSubform.BackAction == Share.Action.RecoveryAdd)
                {
                    object[] data = new object[] { dgv_Students.Rows[e.RowIndex].Cells[0].Value,
                                               dgv_Students.Rows[e.RowIndex].Cells[1].Value,
                                               dgv_Students.Rows[e.RowIndex].Cells[2].Value,
                                               dgv_Students.Rows[e.RowIndex].Cells[3].Value,
                                               dgv_Students.Rows[e.RowIndex].Cells[4].Value,
                                               dgv_Students.Rows[e.RowIndex].Cells[5].Value};
                    this._callBackSubform.Table = SetUpCurrentDataSub(data);
                }
                else if (this._callBackSubform.BackAction == Share.Action.RecoveryEdit)
                {
                    dgv_Students.CurrentRow.Cells[1].ReadOnly = true;
                    dgv_Students.CurrentRow.Cells[2].ReadOnly = true;
                    dgv_Students.CurrentRow.Cells[3].ReadOnly = true;
                    dgv_Students.CurrentRow.Cells[4].ReadOnly = true;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void Dgv_Students_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                bool isFirst = true;
                int index = 0;
                foreach (DataGridViewCell drv in dgv_Students.Rows[e.RowIndex].Cells)
                {
                    if (String.IsNullOrEmpty(drv.Value.ToString()))
                    {
                        e.Cancel = true;

                        dgv_Students.Rows[e.RowIndex].ErrorText = "Had error";
                        dgv_Students.Rows[e.RowIndex].Cells[index].ErrorText = "Dose not empty.";

                        dgv_Students.CurrentCell = drv;
                    }
                    else
                    {
                        dgv_Students.Rows[e.RowIndex].Cells[index].ErrorText = null;
                    }

                    if (isFirst)
                    {
                        string valCurrent = drv.FormattedValue.ToString();

                        if (SqlRequestFunction.StudentIsExist(valCurrent))
                        {
                            dgv_Students.Rows[e.RowIndex].ErrorText = "Had error";
                            dgv_Students.Rows[e.RowIndex].Cells[index].ErrorText = "Student Code Is Exists.";
                            dgv_Students.CurrentCell = drv;
                        }
                        else
                        {
                            dgv_Students.Rows[e.RowIndex].Cells[index].ErrorText = null;
                        }

                        isFirst = false;
                    }
                    index++;
                }
            }
            catch { }
        }

        public void SetUpButtonForAction()
        {
            this.splc_ConstructArea.Enabled = true;
            this.btn_Add.Enabled = false;
            this.btn_Edit.Enabled = false;
            this.btn_Delete.Enabled = false;
            //this.pnl_grv.Enabled = false;

            this.lbl_Error_CodeClass.Text = this.lbl_Error_NameClass.Text = "";

            if (this.btn_Write.Tag.Equals("ADD"))
            {
                this.dgv_Students.DataSource = null;
                this.txt_NameClass.Text = this.txt_CodeClass.Text = "";
                this.ActiveControl = this.txt_CodeClass;
            }
            else if (this.btn_Write.Tag.Equals("EDIT"))
            {
                //this.txt_CodeDepartment.Enabled = false;
                this.pnl_grv.Enabled = false;
            }

            try
            {
                this.bs_Lop.CurrentChanged -= Bs_Lop_CurrentChanged;
            }
            catch (ArgumentNullException anex)
            {
                Debug.WriteLine(anex.Message);
            }
        }

        private bool DepartmentIsExists(String classCode)
        {
            bool isExistInCurrentData = (FindCurrentDataByClassCode(classCode)).Length > 0;
            bool isExistOnDatabase = SqlRequestFunction.ClassIsExist(classCode);

            return isExistInCurrentData || isExistOnDatabase;
        }

        private DataRowView[] FindCurrentDataByClassCode(String departmentCode)
        {
            DataView dt = (DataView)bs_Lop.List;
            dt.Sort = "MALOP";
            return dt.FindRows(departmentCode);
        }

        private bool DGVHadError(DataGridView dgv)
        {
            foreach (DataGridViewRow rowView in dgv.Rows)
            {
                bool a = rowView.IsNewRow;
                if (rowView.ErrorText != "")
                {
                    return true;
                }
            }
            return false;
        }
    }
}
