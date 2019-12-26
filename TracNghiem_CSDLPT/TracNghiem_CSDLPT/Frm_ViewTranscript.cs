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
    public partial class Frm_ViewTranscript : DevExpress.XtraEditors.XtraForm
    {
        public Frm_ViewTranscript()
        {
            InitializeComponent();
        }

        private void lOPBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bs_LOP.EndEdit();
            this.tableAdapterManager.UpdateAll(this.TN_CSDLPT);

        }

        private void Frm_ViewTranscript_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tN_CSDLPTDataSet.MONHOC' table. You can move, or remove it, as needed.
            this.tbla_MONHOC.Fill(this.TN_CSDLPT.MONHOC);
            // TODO: This line of code loads data into the 'tN_CSDLPTDataSet.LOP' table. You can move, or remove it, as needed.
            this.tbla_LOP.Fill(this.TN_CSDLPT.LOP);

        }
    }
}