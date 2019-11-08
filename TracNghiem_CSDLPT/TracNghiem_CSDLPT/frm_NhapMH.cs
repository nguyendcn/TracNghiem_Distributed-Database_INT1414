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

namespace TracNghiem_CSDLPT
{
    public partial class frm_NhapMH : DevExpress.XtraEditors.XtraForm
    {
        public frm_NhapMH()
        {
            InitializeComponent();

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

        private void gcv_MonHoc_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_Add_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool isEmpty = ValidateEmpty();

            if (!isEmpty)
                return;

            // TODO: Check code course
            DataView dt = (DataView)bs_MonHoc.List;
            dt.Sort = "MAMH";
            if (dt.FindRows(txt_CodeCourse.Text).Length != 0)
            {
                MessageBox.Show("Mã môn học đã tồn tại.Vui lòng nhập lại!");
            }
            else
            {
                object[] data = new object[] { txt_CodeCourse.Text, txt_NameCourse.Text};
                DataRowView drv = (DataRowView)bs_MonHoc.AddNew();
                drv.Row.ItemArray = data;
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
                    this.tbla_MonHoc.Fill(this.ds_TN_CSDLPT.MONHOC);
                    MessageBox.Show("Phục hồi dữ liệu thành công.");
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_Write_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bs_MonHoc.EndEdit();
                bs_MonHoc.ResetCurrentItem();
                this.tbla_MonHoc.Update(this.ds_TN_CSDLPT.MONHOC);

                MessageBox.Show("Ghi dư liệu thành công.");
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
            bool isEmpty = ValidateEmpty();

            if (!isEmpty)
                return;

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
                    object[] data = new object[] { txt_CodeCourse.Text, txt_NameCourse.Text};
                    currentRow.Row.ItemArray = data;

                    MessageBox.Show("Sửa dữ liệu thành công.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dữ liệu muốn sửa!");
            }

        }

        private void btn_Delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataRowView currentRow = (DataRowView)bs_MonHoc.Current;
            if (bs_GVDK.Count != 0)
            {
                MessageBox.Show("Không thể xóa môn học. Vì môn học đã được đăng ký thi.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(bs_BangDiem.Count != 0)
            {
                MessageBox.Show("Không thể xóa môn học. Vì môn học đã được thi.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(bs_BoDe.Count != 0)
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

                if(dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        bs_MonHoc.RemoveCurrent();
                        MessageBox.Show("Xóa thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }catch(Exception ex)
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

            if(dialogResult == DialogResult.Yes)
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
    }
}