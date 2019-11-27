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
using TracNghiem_CSDLPT.Common;

namespace TracNghiem_CSDLPT
{
    public partial class Frm_NhapDe : DevExpress.XtraEditors.XtraForm
    {
        public Frm_NhapDe()
        {
            InitializeComponent();

            SetUp();

            bs_BoDe.CurrentChanged += Bs_BoDe_CurrentChanged;
        }

        private void Bs_BoDe_CurrentChanged(object sender, EventArgs e)
        {
            if(bs_BoDe.Position != -1)
            {
                txt_QuestionCode.Text = ((DataRowView)bs_BoDe[bs_BoDe.Position])["CAUHOI"].ToString().Trim();

                cmb_CourseCode.SelectedIndex = bs_MonHoc.Find("MAMH", ((DataRowView)bs_BoDe[bs_BoDe.Position])["MAMH"].ToString().Trim());

                cmb_Level.SelectedIndex = GetIndexOfDataTable((DataTable)cmb_Level.DataSource,
                    ((DataRowView)bs_BoDe[bs_BoDe.Position])["TRINHDO"].ToString().Trim());

                txt_QuestionContent.Text = ((DataRowView)bs_BoDe[bs_BoDe.Position])["NOIDUNG"].ToString().Trim();
                txt_AnsA.Text = ((DataRowView)bs_BoDe[bs_BoDe.Position])["A"].ToString().Trim();
                txt_AnsB.Text = ((DataRowView)bs_BoDe[bs_BoDe.Position])["B"].ToString().Trim();
                txt_AnsC.Text = ((DataRowView)bs_BoDe[bs_BoDe.Position])["C"].ToString().Trim();
                txt_AnsD.Text = ((DataRowView)bs_BoDe[bs_BoDe.Position])["D"].ToString().Trim();

                cmb_TrueAnswer.SelectedIndex = cmb_TrueAnswer.FindString(((DataRowView)bs_BoDe[bs_BoDe.Position])["DAP_AN"].ToString().Trim());

            }
        }


        public void SetUp()
        {
            DataTable tableLevel = new DataTable("Level");
            tableLevel.Columns.Add("Symbol");
            tableLevel.Columns.Add("Name");

            DataRow dataRow = tableLevel.NewRow();
            dataRow.ItemArray = new object[] {"A", "Đại Học" };
            tableLevel.Rows.Add(dataRow);

            dataRow = tableLevel.NewRow();
            dataRow.ItemArray = new object[] { "B", "Cao Đẳng" };
            tableLevel.Rows.Add(dataRow);

            dataRow = tableLevel.NewRow();
            dataRow.ItemArray = new object[] { "C", "Trung Cấp" };
            tableLevel.Rows.Add(dataRow);

            cmb_Level.DataSource = tableLevel;
            cmb_Level.ValueMember = "Symbol";
            cmb_Level.DisplayMember = "Name";

        }

        private int GetIndexOfDataTable(DataTable dt, String key)
        {
            for(int i =0; i< dt.Rows.Count; i++)
            {
                if (dt.Rows[i].ItemArray[0].Equals(key))
                    return i;
            }
            return -1;
        }

        private int FindPointionCurrentTeacher(String teacherCode)
        {
            return bs_GiaoVien.Find("MAGV", teacherCode);
        }

        private bool DataEmptyOrNull()
        {
            if (String.IsNullOrEmpty(txt_QuestionContent.Text.Trim()))
            {
                this.ActiveControl = txt_QuestionContent;
                return true;
            }
            else if (String.IsNullOrEmpty(txt_AnsA.Text.Trim()))
            {
                this.ActiveControl = txt_AnsA;
                return true;
            }
            else if (String.IsNullOrEmpty(txt_AnsB.Text.Trim()))
            {
                this.ActiveControl = txt_AnsB;
                return true;
            }
            else if (String.IsNullOrEmpty(txt_AnsC.Text.Trim()))
            {
                this.ActiveControl = txt_AnsC;
                return true;
            }
            else if (String.IsNullOrEmpty(txt_AnsD.Text.Trim()))
            {
                this.ActiveControl = txt_AnsD;
                return true;
            }
            return false;
        }

        private int GetIndexCodeForQuestion()
        {
            List<int> lCode = SqlRequestFunction.GetListQuestionCode();
            int count = lCode.Count;

            for (int index = 0; index < count; index++)
            {
                int expectValue = index + 1;
                if (expectValue != lCode[index]) return expectValue;
            }
            return lCode[count - 1] + 1;
        }



        private void Frm_NhapDe_Load(object sender, EventArgs e)
        {
           

            this.ds_TN_CSDLPT.EnforceConstraints = false;

            this.tbl_MonHoc.Connection.ConnectionString = Program.connstr;
            this.tbl_MonHoc.Fill(this.ds_TN_CSDLPT.MONHOC);

            this.tbla_BoDe.Connection.ConnectionString = Program.connstr;
            this.tbla_BoDe.Fill(this.ds_TN_CSDLPT.BODE);

            this.tbla_GiaoVien.Connection.ConnectionString = Program.connstr;
            this.tbla_GiaoVien.Fill(this.ds_TN_CSDLPT.GIAOVIEN);

            this.bs_GiaoVien.Position = FindPointionCurrentTeacher(Program.username);
        }

        private void btn_Add_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool isEmpty = DataEmptyOrNull();

            if (!isEmpty)
            {
                try
                {
                    int qCode = GetIndexCodeForQuestion();
                    object[] data = new object[] {qCode, cmb_CourseCode.SelectedValue, cmb_Level.SelectedValue,
                    txt_QuestionContent.Text, txt_AnsA.Text, txt_AnsB.Text, txt_AnsC.Text,
                    txt_AnsD.Text, cmb_TrueAnswer.Text };

                    DataRowView drv = (DataRowView)bs_BoDe.AddNew();
                    drv.Row.ItemArray = data;
                }
                catch(Exception ex)
                {
                    Debug.Fail("Error.");
                }
                
            }
        }

        private void Txt__MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TextBox tb = sender as TextBox;

            tb.SelectAll();
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

        private void btn_Delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataRowView currentRow = (DataRowView)bs_BoDe.Current;

            DialogResult dialogResult = MessageBox.Show(
                   "Bạn có chắc muốn xóa câu hỏi: {" + currentRow.Row.ItemArray[0] + ", " + currentRow.Row.ItemArray[1] + "}.",
                   "Xoá",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    bs_BoDe.RemoveCurrent();
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