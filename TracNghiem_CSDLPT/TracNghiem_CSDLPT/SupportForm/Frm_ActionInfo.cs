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
using TracNghiem_CSDLPT.Share;

namespace TracNghiem_CSDLPT.SupportForm
{
    public partial class Frm_ActionInfo : DevExpress.XtraEditors.XtraForm
    {

        public delegate void ChoosenAction(DialogResult result);

        public event ChoosenAction Choosen;

        public Frm_ActionInfo()
        {
            InitializeComponent();

        }

        public Frm_ActionInfo(CallBackAction cb)
        {
            InitializeComponent();

            if(cb.BackAction == Share.Action.Delete)
            {
                this.lbl_Action.Text = "Xóa";
            }
            else if(cb.BackAction == Share.Action.Edit)
            {
                this.lbl_Action.Text = "Sửa";
            }
            else if (cb.BackAction == Share.Action.Add)
            {
                this.lbl_Action.Text = "Thêm";
            }

            this.dgv_Data.DataSource = cb.Table;
        }

        private void btn_Yes_Click(object sender, EventArgs e)
        {
            OnChoosen(DialogResult.Yes);
            this.Dispose();
        }

        private void btn_No_Click(object sender, EventArgs e)
        {
            OnChoosen(DialogResult.No);
            this.Dispose();
        }

        public virtual void OnChoosen(DialogResult result)
        {
            if (Choosen != null)
                Choosen(result);
        }
    }
}