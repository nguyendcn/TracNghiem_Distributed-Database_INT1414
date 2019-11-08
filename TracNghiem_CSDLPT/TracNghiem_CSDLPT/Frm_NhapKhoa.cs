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

namespace TracNghiem_CSDLPT
{
    public partial class Frm_NhapKhoa : DevExpress.XtraEditors.XtraForm
    {
        public Frm_NhapKhoa()
        {
            InitializeComponent();
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
            if (grb_Option.Text.Equals("Thêm"))
            {
                if (txt_CodeDepartment.Text.Trim() == String.Empty || 
                    txt_NameDepartment.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("Mã và tên khoa không được để trống!");
                    return;
                }

                // TODO: Check code course
                DataView dt = (DataView)bs_Khoa.List;
                dt.Sort = "MAKH";
                if (dt.FindRows(txt_CodeDepartment.Text).Length != 0)
                {
                    MessageBox.Show("Mã khoa đã tồn tại.Vui lòng nhập lại!");
                }
                else
                {
                    DataRowView drv = (DataRowView)bs_Khoa.AddNew();
                    drv.Row.ItemArray = new object[] { txt_CodeDepartment.Text, txt_NameDepartment.Text, txt_CodeBrand.Text };
                }

            }
            else
            {
                this.txt_CodeDepartment.ReadOnly = false;
                this.grb_Option.Text = "Thêm";
                this.txt_CodeBrand.Text = "CS" + (Program.mChinhanh + 1);
                this.ActiveControl = this.txt_CodeDepartment;
            }
        }

        private void btn_Edit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataRowView currentRow = (DataRowView)bs_Khoa.Current;
            if (grb_Option.Text.Equals("Sửa"))
            {
                if (currentRow != null)
                {
                    //Save data edited or edit new data
                    if (txt_CodeDepartment.Text.Equals(currentRow.Row.ItemArray[0].ToString()))
                    {
                        currentRow.Row.ItemArray = new object[] { txt_CodeDepartment.Text,
                                                                  txt_NameDepartment.Text,
                                                                  txt_CodeBrand.Text};
                    }
                    else
                    {
                        txt_CodeDepartment.ReadOnly = true;
                        txt_CodeDepartment.Text = currentRow.Row.ItemArray[0].ToString();
                        txt_NameDepartment.Text = currentRow.Row.ItemArray[1].ToString();
                        txt_CodeBrand.Text = currentRow.Row.ItemArray[2].ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn dữ liệu muốn sửa!");
                }
            }
            else
            {
                grb_Option.Text = "Sửa";
                txt_CodeDepartment.ReadOnly = true;
                txt_CodeDepartment.Text = currentRow.Row.ItemArray[0].ToString();
                txt_NameDepartment.Text = currentRow.Row.ItemArray[1].ToString();
                txt_CodeBrand.Text = currentRow.Row.ItemArray[2].ToString();
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

    }
}