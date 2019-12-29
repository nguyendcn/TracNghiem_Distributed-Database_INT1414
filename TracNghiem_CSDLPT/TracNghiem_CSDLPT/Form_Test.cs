using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TracNghiem_CSDLPT
{
    public partial class Form_Test : Form
    {
        public Form_Test()
        {
            InitializeComponent();
        }

        private void fillToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.sp_GetReportTableAdapter.Fill(this.tN_CSDLPTDataSet.sp_GetReport, mACSToolStripTextBox.Text, fROMToolStripTextBox.Text, tOToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }
}
