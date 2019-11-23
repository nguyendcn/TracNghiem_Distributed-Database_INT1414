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

namespace TracNghiem_CSDLPT
{
    public partial class Frm_NhapKhoa : DevExpress.XtraEditors.XtraForm
    {
        public Frm_NhapKhoa()
        {
            InitializeComponent();

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
            bool isEmpty = ValidateEmpty();

            if (!isEmpty)
                return;

            // TODO: Check code course
            DataView dt = (DataView)bs_Khoa.List;
            dt.Sort = "MAKH";
            if (dt.FindRows(txt_CodeDepartment.Text).Length != 0)
            {
                MessageBox.Show("Mã khoa đã tồn tại.Vui lòng nhập lại!");
            }
            else
            {
                object[] data = new object[] { txt_CodeDepartment.Text, txt_NameDepartment.Text, txt_CodeBrand.Text };
                DataRowView drv = (DataRowView)bs_Khoa.AddNew();
                drv.Row.ItemArray = data;
            }

        }

        private void btn_Edit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool isEmpty = ValidateEmpty();

            if (!isEmpty)
                return;

            DataRowView currentRow = (DataRowView)bs_Khoa.Current;

            if (currentRow != null)
            {
                DataView dt = (DataView)bs_Khoa.List;
                dt.Sort = "MAKH";
                if (dt.FindRows(txt_CodeDepartment.Text.Trim()).Length != 0 &&
                    !currentRow.Row.ItemArray[0].ToString().Trim().Equals(txt_CodeDepartment.Text.Trim()))
                {
                    MessageBox.Show("Mã khoa đã tồn tại.Vui lòng nhập lại!");
                    this.ActiveControl = this.txt_CodeDepartment;
                    return;
                }
                else
                {
                    object[] data = new object[] { txt_CodeDepartment.Text, txt_NameDepartment.Text, txt_CodeBrand.Text };
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
                bs_Khoa.EndEdit();
                bs_Khoa.ResetCurrentItem();
                this.tbla_Khoa.Update(this.ds_TN_CSDLPT.KHOA);

                this.tbla_GiaoVien.Update(this.ds_TN_CSDLPT.GIAOVIEN);


                MessageBox.Show("Ghi dư liệu thành công.");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MAKH"))
                    MessageBox.Show("Mã khoa không được trùng", "", MessageBoxButtons.OK);
                if (ex.Message.Contains("MALOP"))
                    MessageBox.Show("Mã lop không được trùng", "", MessageBoxButtons.OK);
                else
                    MessageBox.Show("Lỗi ghi Khoa. " + ex.Message, "", MessageBoxButtons.OK);
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
            DataRowView currentRow = (DataRowView)bs_Khoa.Current;
            if (bs_GiaoVien.Count != 0)
            {
                MessageBox.Show("Không thể xóa khoa. Vì khoa này đã có giáo viên.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (bs_Lop.Count != 0)
            {
                MessageBox.Show("Không thể xóa khoa này. Vì khoa này đã có lớp.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show(
                    "Bạn có chắc muốn xóa khoa: {" + currentRow.Row.ItemArray[0] + ", " + currentRow.Row.ItemArray[1] + "}.",
                    "Xoá",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        bs_Khoa.RemoveCurrent();
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

        public bool ValidateEmpty()
        {
            if (txt_CodeDepartment.Text.Trim().Equals(String.Empty))
            {
                MessageBox.Show("");
                this.ActiveControl = this.txt_CodeDepartment;
                return false;
            }

            if (txt_NameDepartment.Text.Trim().Equals(String.Empty))
            {
                MessageBox.Show("");
                this.ActiveControl = this.txt_NameDepartment;
                return false;
            }

            return true;
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
    }
}