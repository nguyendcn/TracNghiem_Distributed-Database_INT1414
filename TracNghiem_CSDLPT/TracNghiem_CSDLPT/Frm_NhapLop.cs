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

namespace TracNghiem_CSDLPT
{
    public partial class Frm_NhapLop : DevExpress.XtraEditors.XtraForm
    {
        public Frm_NhapLop()
        {
            InitializeComponent();
        }

        private void lOPBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bs_Lop.EndEdit();
            this.tableAdapterManager.UpdateAll(this.ds_TN_CSDLPT);

        }

        private void btn_Add_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grb_Option.Text.Equals("Thêm"))
            {
                if (txt_CodeClass.Text.Trim() == String.Empty || txt_NameClass.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("Mã và tên môn học không được để trống!");
                    return;
                }

                // TODO: Check code course
                DataView dt = (DataView)bs_Lop.List;
                dt.Sort = "MALOP";
                if (dt.FindRows(txt_CodeClass.Text).Length != 0)
                {
                    MessageBox.Show("Mã môn học đã tồn tại.Vui lòng nhập lại!");
                }
                else
                {
                    DataRowView drv = (DataRowView)bs_Lop.AddNew();
                    DataRowView rowView = (DataRowView)cmb_Khoa.SelectedItem;
                    drv.Row.ItemArray = new object[] { txt_CodeClass.Text, txt_NameClass.Text,
                                                       rowView.Row.ItemArray[0] };
                }

            }
            else
            {
                this.txt_CodeClass.ReadOnly = false;
                this.cmb_Khoa.Enabled = true;
                this.grb_Option.Text = "Thêm";
                this.ActiveControl = this.txt_CodeClass;
            }
        }

        private void btn_Edit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataRowView currentRow = (DataRowView)bs_Lop.Current;
            if (grb_Option.Text.Equals("Sửa"))
            {
                if (currentRow != null)
                {
                    //Save data edited or edit new data
                    if (txt_CodeClass.Text.Equals(currentRow.Row.ItemArray[0].ToString()))
                    {
                        DataRowView rowView = (DataRowView)cmb_Khoa.SelectedItem;
                        currentRow.Row.ItemArray = new object[] { txt_CodeClass.Text, txt_NameClass.Text,
                                                                  rowView.Row.ItemArray[0]};
                    }
                    else
                    {
                        txt_CodeClass.ReadOnly = true;
                        txt_CodeClass.Text = currentRow.Row.ItemArray[0].ToString();
                        txt_NameClass.Text = currentRow.Row.ItemArray[1].ToString();
                        cmb_Khoa.SelectedIndex = 0;
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
                txt_CodeClass.ReadOnly = true;
                txt_CodeClass.Text = currentRow.Row.ItemArray[0].ToString();
                txt_NameClass.Text = currentRow.Row.ItemArray[1].ToString();
                cmb_Khoa.SelectedIndex = 0;
                cmb_Khoa.Enabled = false;
            }
        }

        private void btn_Write_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bs_Lop.EndEdit();
                bs_Lop.ResetCurrentItem();
                this.tbla_Lop.Update(this.ds_TN_CSDLPT.LOP);

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

            this.tbla_SinhVien.Connection.ConnectionString = Program.connstr;
            this.tbla_SinhVien.Fill(this.ds_TN_CSDLPT.SINHVIEN);

            this.tbla_Khoa.Connection.ConnectionString = Program.connstr;
            this.tbla_Khoa.Fill(this.ds_TN_CSDLPT.KHOA);

            this.tbla_Lop.Connection.ConnectionString = Program.connstr;
            this.tbla_Lop.Fill(this.ds_TN_CSDLPT.LOP);
        }
    }
}
