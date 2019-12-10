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
            SetUpButtonForAdd();

            this.btn_Write.Tag = "ADD";
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
                Frm_ActionInfo frm_ActionInfo = new Frm_ActionInfo(this._callAction);

                frm_ActionInfo.Choosen += (result) =>
                {
                    if (result == DialogResult.Yes)
                    {
                        RecoveryDataByAction(this._callAction);
                    }
                };

                frm_ActionInfo.ShowDialog();
            }
        }

        private void btn_Write_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (this.btn_Write.Tag.Equals("ADD"))
                {
                    Add();
                    return;
                    MessageBox.Show("Thêm dữ liệu thành công.", "Thêm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (this.btn_Write.Tag.Equals("DELETE"))
                {
                    Delete();
                    MessageBox.Show("Xóa dữ liệu thành công.", "Xóa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (this.btn_Write.Tag.Equals("EDIT"))
                {
                    Edit();
                    MessageBox.Show("Sửa dữ liệu thành công.", "Sửa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                bs_MonHoc.EndEdit();
                bs_MonHoc.ResetCurrentItem();
                this.tbla_MonHoc.Update(this.ds_TN_CSDLPT.MONHOC);

                this.btn_Write.Tag = "";

                FreeAllControl();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MAMH"))
                    MessageBox.Show("Mã môn học không được trùng", "", MessageBoxButtons.OK);
                else
                    MessageBox.Show("Lỗi ghi Môn học. " + ex.Message, "", MessageBoxButtons.OK);
            }
        }

        private void btn_Edit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.btn_Write.Tag = "EDIT";

            SetUpButtonForAdd();
        }

        private void btn_Delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.btn_Write.Tag = "DELETE";

            SetUpButtonForAdd();
        }

        private void btn_Exit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn lưu dữ liệu trước khi thoát không?", "Exit",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                btn_Write.PerformClick();
            }

            this.Dispose();
        }

        public bool ValidateEmpty()
        {
            if (txt_CodeCourse.Text.Trim().Equals(String.Empty))
            {
                MessageBox.Show("");
                this.ActiveControl = this.txt_CodeCourse;
                return false;
            }

            if (txt_NameCourse.Text.Trim().Equals(String.Empty))
            {
                MessageBox.Show("");
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
            if (cAction.BackAction == Share.Action.Add)
            {
                DataRow dr = cAction.Table.Rows[0];
                int index = bs_MonHoc.Find("MAMH", dr.ItemArray[0]);
                bs_MonHoc.RemoveAt(index);
            }
            else if (cAction.BackAction == Share.Action.Delete)
            {
                DataView dt = (DataView)bs_MonHoc.List;
                dt.Sort = "MAMH";
                if (dt.FindRows(txt_CodeCourse.Text).Length != 0)
                {
                    MessageBox.Show("Mã môn học đã tồn tại.Vui lòng nhập lại!");
                }
                else
                {
                    DataRow dr = cAction.Table.Rows[0];
                    DataRowView drv = (DataRowView)bs_MonHoc.AddNew();
                    drv.Row.ItemArray = dr.ItemArray;
                }
            }
            else if (cAction.BackAction == Share.Action.Edit)
            {
                DataRow dr = cAction.Table.Rows[0];
                bs_MonHoc.Position = bs_MonHoc.Find("MAMH", dr.ItemArray[0]);

                DataRowView currentRow = (DataRowView)bs_MonHoc.Current;

                currentRow.Row.ItemArray = dr.ItemArray;
            }
        }

        public void SetUpButtonForAdd()
        {
            this.pnl_ConstructArea.Enabled = true;
            this.btn_Add.Enabled = false;
            this.btn_Edit.Enabled = false;
            this.btn_Delete.Enabled = false;

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

        public void FreeAllControl()
        {
            this.pnl_ConstructArea.Enabled = false;
            this.btn_Add.Enabled = true;
            this.btn_Edit.Enabled = true;
            this.btn_Delete.Enabled = true;

            try
            {
                this.bs_MonHoc.CurrentChanged -= Bs_MonHoc_CurrentChanged;
            }
            catch (ArgumentNullException anex)
            {
                this.bs_MonHoc.CurrentChanged += Bs_MonHoc_CurrentChanged;

                Debug.WriteLine(anex.Message);
            }

        }

        public void Add()
        {
            ErrorHandler.ShowError(lbl_Err_CodeCourse, new string[] { "Ox1002" });
            return;
           // bool isEmpty = ValidateEmpty();

            //if (!isEmpty)
            //    return;

            // TODO: Check code course
            DataView dt = (DataView)bs_MonHoc.List;
            dt.Sort = "MAMH";
            if (dt.FindRows(txt_CodeCourse.Text).Length != 0)
            {
                ErrorHandler.ShowError(txt_CodeCourse, new string[] { "Ox0001" });
            }
            else
            {
                object[] data = new object[] { txt_CodeCourse.Text, txt_NameCourse.Text };
                DataRowView drv = (DataRowView)bs_MonHoc.AddNew();
                drv.Row.ItemArray = data;

                this._callAction.FillData(Share.Action.Add, SetUpCurrentData(data));
            }
        }

        public void Edit()
        {
            bool isEmpty = ValidateEmpty();

            if (!isEmpty)
                return;

            this.btn_Write.Tag = "ADD";

            DataRowView currentRow = (DataRowView)bs_MonHoc.Current;

            if (currentRow != null)
            {
                DataView dt = (DataView)bs_MonHoc.List;
                dt.Sort = "MAMH";
                if (dt.FindRows(txt_CodeCourse.Text.Trim()).Length != 0 &&
                    !currentRow.Row.ItemArray[0].ToString().Trim().Equals(txt_CodeCourse.Text.Trim()))
                {
                    MessageBox.Show("Mã khoa đã tồn tại.Vui lòng nhập lại!");
                    this.ActiveControl = this.txt_CodeCourse;
                    return;
                }
                else
                {
                    this._callAction.FillData(Share.Action.Edit, SetUpCurrentData(currentRow.Row.ItemArray));

                    object[] data = new object[] { txt_CodeCourse.Text, txt_NameCourse.Text };
                    currentRow.Row.ItemArray = data;

                    MessageBox.Show("Sửa dữ liệu thành công.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dữ liệu muốn sửa!");
            }
        }

        public void Delete()
        {
            DataRowView currentRow = (DataRowView)bs_MonHoc.Current;
            if (bs_GVDK.Count != 0)
            {
                MessageBox.Show("Không thể xóa môn học. Vì môn học đã được đăng ký thi.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (bs_BangDiem.Count != 0)
            {
                MessageBox.Show("Không thể xóa môn học. Vì môn học đã được thi.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (bs_BoDe.Count != 0)
            {
                MessageBox.Show("Không thể xóa môn học. Vì môn học đã được lập bộ đề.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show(
                    "Bạn có chắc muốn xóa môn học: {" + currentRow.Row.ItemArray[0] + ", " + currentRow.Row.ItemArray[1] + "}.",
                    "Xoá",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        this._callAction.FillData(Share.Action.Delete, SetUpCurrentData(currentRow.Row.ItemArray));

                        bs_MonHoc.RemoveCurrent();
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
    }
}