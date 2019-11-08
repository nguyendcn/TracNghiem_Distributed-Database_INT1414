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
            if (grb_Option.Text.Equals("Thêm"))
            {
                if(txt_CodeCourse.Text.Trim() == String.Empty || txt_NameCourse.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("Mã và tên môn học không được để trống!");
                    return;
                }

                // TODO: Check code course
                DataView dt = (DataView)bs_MonHoc.List;
                dt.Sort = "MAMH";
                if (dt.FindRows(txt_CodeCourse.Text).Length != 0)
                {
                    MessageBox.Show("Mã môn học đã tồn tại.Vui lòng nhập lại!");
                }
                else {
                    DataRowView drv = (DataRowView)bs_MonHoc.AddNew();
                    drv.Row.ItemArray = new object[] { txt_CodeCourse.Text, txt_NameCourse.Text };
                }
                
            }
            else
            {
                this.txt_CodeCourse.ReadOnly = false;
                this.grb_Option.Text = "Thêm";
                this.ActiveControl = this.txt_CodeCourse;
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
            DataRowView currentRow = (DataRowView)bs_MonHoc.Current;
            if (grb_Option.Text.Equals("Sửa"))
            {
                if (currentRow != null)
                {
                    //Save data edited or edit new data
                    if (txt_CodeCourse.Text.Equals(currentRow.Row.ItemArray[0].ToString()))
                    {
                        currentRow.Row.ItemArray = new object[] { txt_CodeCourse.Text, txt_NameCourse.Text};
                    }
                    else
                    {
                        txt_CodeCourse.ReadOnly = true;
                        txt_CodeCourse.Text = currentRow.Row.ItemArray[0].ToString();
                        txt_NameCourse.Text = currentRow.Row.ItemArray[1].ToString();
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
                txt_CodeCourse.ReadOnly = true;
                txt_CodeCourse.Text = currentRow.Row.ItemArray[0].ToString();
                txt_NameCourse.Text = currentRow.Row.ItemArray[1].ToString();
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
    }
}