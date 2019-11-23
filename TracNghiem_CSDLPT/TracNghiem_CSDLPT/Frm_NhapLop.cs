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

namespace TracNghiem_CSDLPT
{
    public partial class Frm_NhapLop : DevExpress.XtraEditors.XtraForm
    {
        DateTimePicker datePicker = new DateTimePicker();
        Rectangle _rectangle;

        public Frm_NhapLop()
        {
            InitializeComponent();

            this.dgv_Students.Controls.Add(datePicker);
            datePicker.Visible = false;
            datePicker.Format = DateTimePickerFormat.Custom;

            datePicker.TextChanged += DatePicker_TextChanged;


            bs_Lop.CurrentChanged += Bs_Lop_CurrentChanged;

            dgv_Students.CurrentCellChanged += Dgv_Students_CurrentCellChanged;
        }

        private void Dgv_Students_CurrentCellChanged(object sender, EventArgs e)
        {
            Debug.WriteLine("Cell change to: " + dgv_Students.CurrentCell);
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
            bool isEmpty = ValidateEmpty();

            if (!isEmpty)
                return;

            // TODO: Check code course
            DataView dt = (DataView)bs_Lop.List;
            dt.Sort = "MALOP";
            if (dt.FindRows(txt_CodeClass.Text).Length != 0)
            {
                MessageBox.Show("Mã lớp đã tồn tại.Vui lòng nhập lại!");
            }
            else
            {
                String codeDepartment = ((DataRowView)cmb_Khoa.SelectedItem).Row.ItemArray[0].ToString();
                object[] data = new object[] { txt_CodeClass.Text, txt_NameClass.Text, codeDepartment };
                DataRowView drv = (DataRowView)bs_Lop.AddNew();
                drv.Row.ItemArray = data;
            }
        }

        private void btn_Edit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool isEmpty = ValidateEmpty();

            if (!isEmpty)
                return;

            DataRowView currentRow = (DataRowView)bs_Lop.Current;

            if (currentRow != null)
            {
                DataView dt = (DataView)bs_Lop.List;
                dt.Sort = "MALOP";
                if (dt.FindRows(txt_CodeClass.Text.Trim()).Length != 0 &&
                    !currentRow.Row.ItemArray[0].ToString().Trim().Equals(txt_CodeClass.Text.Trim()))
                {
                    MessageBox.Show("Mã lớp đã tồn tại.Vui lòng nhập lại!");
                    this.ActiveControl = this.txt_CodeClass;
                    return;
                }
                else
                {
                    String codeDepartment = ((DataRowView)cmb_Khoa.SelectedItem).Row.ItemArray[0].ToString();
                    object[] data = new object[] { txt_CodeClass.Text, txt_NameClass.Text, codeDepartment };
                    currentRow.Row.ItemArray = data;

                    MessageBox.Show("Sửa dữ liệu thành công.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dữ liệu muốn sửa!");
            }
        }

        private void btn_Write_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bs_Lop.EndEdit();
                bs_Lop.ResetCurrentItem();
                this.tbla_Lop.Update(this.ds_TN_CSDLPT.LOP);

                this.tbla_SinhVien.Update(this.ds_TN_CSDLPT.SINHVIEN);

                MessageBox.Show("Ghi dư liệu thành công.");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MALOP"))
                    MessageBox.Show("Mã lop không được trùng", "", MessageBoxButtons.OK);
                else
                    MessageBox.Show("Lỗi ghi Lopn học. " + ex.Message, "", MessageBoxButtons.OK);
            }
        }

        private void btn_Reset_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Phục hồi dữ liệu", "Bạn có chắc muống phục hồi dữ liệu không?",
                                                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    this.tbla_Lop.Fill(this.ds_TN_CSDLPT.LOP);
                    this.tbla_SinhVien.Fill(this.ds_TN_CSDLPT.SINHVIEN);
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
            DataRowView currentRow = (DataRowView)bs_Lop.Current;
            if (bs_GVDK.Count != 0)
            {
                MessageBox.Show("Không thể xóa lớp học này. Vì lớp học này đã được đăng ký thi.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (bs_SinhVien.Count != 0)
            {
                MessageBox.Show("Không thể xóa lớp học này. Vì lớp học đã có sinh viên theo học.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show(
                    "Bạn có chắc muốn xóa lớp học: {" + currentRow.Row.ItemArray[0] + ", " + currentRow.Row.ItemArray[1] + "}.",
                    "Xoá",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        bs_Lop.RemoveCurrent();
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
                MessageBox.Show("");
                this.ActiveControl = this.txt_CodeClass;
                return false;
            }

            if (txt_NameClass.Text.Trim().Equals(String.Empty))
            {
                MessageBox.Show("");
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

                Debug.WriteLine("Current row:" + bs_SinhVien.Position);

                if (bs_BangDiem.Count != 0)
                {
                    MessageBox.Show("Không thể xóa sinh viên này. Vì sinh viên này đã được lập bảng điểm.", "Error",
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
                            bs_SinhVien.RemoveCurrent();
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

        private void dgv_Students_CellClick(object sender, DataGridViewCellEventArgs e)
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
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muống phục hồi dữ liệu sinh viên không?",
                                                        "Phục hồi dữ liệu",
                                                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    this.tbla_SinhVien.Fill(ds_TN_CSDLPT.SINHVIEN);
                    MessageBox.Show("Phục hồi dữ liệu thành công.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tsmi_Edit_Click(object sender, EventArgs e)
        {
            //dgv_Students.CurrentRow.Cells[0].ReadOnly = false;
            dgv_Students.CurrentRow.Cells[1].ReadOnly = false;
            dgv_Students.CurrentRow.Cells[2].ReadOnly = false;
            dgv_Students.CurrentRow.Cells[3].ReadOnly = false;
            dgv_Students.CurrentRow.Cells[4].ReadOnly = false;

        }

        private void tsmi_Add_Click(object sender, EventArgs e)
        {
            try
            {
                //dgv_Students.AllowUserToAddRows = true;

                //object[] data = new object[] { "1111", "Dang", "Nguyen", "2019-07-03", "address" };
                //DataRowView drv = (DataRowView)bs_SinhVien.AddNew();
                //drv.Row.ItemArray = data;

                //bs_SinhVien.EndEdit();
                //dgv_Students.Refresh();

                DataRowView drv = (DataRowView)bs_SinhVien.AddNew();

                dgv_Students.CurrentRow.Cells[0].ReadOnly = false;
                dgv_Students.CurrentRow.Cells[1].ReadOnly = false;
                dgv_Students.CurrentRow.Cells[2].ReadOnly = false;
                dgv_Students.CurrentRow.Cells[3].ReadOnly = false;
                dgv_Students.CurrentRow.Cells[4].ReadOnly = false;

                dgv_Students.CellValidating += dgv_Students_CellValidating;

                Debug.WriteLine("First Is new Row: " + dgv_Students.CurrentRow.IsNewRow);

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

        private void dgv_Students_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Debug.WriteLine("Cell end edit.");
        }

        private void dgv_Students_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string headerText =
           dgv_Students.Columns[e.ColumnIndex].HeaderText;
            if (headerText.Equals("MASV"))
            {
                string valCurrent = e.FormattedValue.ToString();
                if (StudentCodeIsExists(valCurrent))
                {
                    e.Cancel = true;
                    dgv_Students.Rows[e.RowIndex].ErrorText = "Student Code Exist.";

                    MessageBox.Show("Mã sinh viên đã tồn tại vui lòng nhập lại.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgv_Students_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            dgv_Students.Rows[e.RowIndex].ErrorText = null;

        }

        private void dgv_Students_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                foreach (DataGridViewCell drv in dgv_Students.Rows[e.RowIndex].Cells)
                {
                    if (String.IsNullOrEmpty(drv.Value.ToString()))
                    {
                        e.Cancel = true;

                        dgv_Students.Rows[e.RowIndex].ErrorText = "Dose not empty.";

                        MessageBox.Show("Không được để trống.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        dgv_Students.CurrentCell = drv;

                        return;
                    }
                }
            }
            catch { }
        }

        private void dgv_Students_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            dgv_Students.Rows[e.RowIndex].ErrorText = null;

            try
            {
                dgv_Students.CellValidating -= dgv_Students_CellValidating;

            }
            catch (Exception ex)
            {

            }
        }
    }
}
