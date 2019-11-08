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

                MessageBox.Show("Ghi dư liệu thành công.");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("MAKH"))
                    MessageBox.Show("Mã khoa không được trùng", "", MessageBoxButtons.OK);
                else
                    MessageBox.Show("Lỗi ghi Khoa. " + ex.Message, "", MessageBoxButtons.OK);
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
                    this.tbla_Khoa.Fill(this.ds_TN_CSDLPT.KHOA);
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

    }
}