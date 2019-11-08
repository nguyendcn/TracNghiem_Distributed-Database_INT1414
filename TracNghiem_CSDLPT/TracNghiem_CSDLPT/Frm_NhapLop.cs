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

            bs_Lop.CurrentChanged += Bs_Lop_CurrentChanged;
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
                object[] data = new object[] { txt_CodeClass.Text, txt_NameClass.Text, codeDepartment};
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
    }
}
