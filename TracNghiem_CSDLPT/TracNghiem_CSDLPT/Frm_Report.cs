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
using DevExpress.XtraReports.UI;
using TracNghiem_CSDLPT.Share;

namespace TracNghiem_CSDLPT
{
    public partial class Frm_Report : DevExpress.XtraEditors.XtraForm
    {
        public Frm_Report()
        {
            InitializeComponent();

            SetUp();

            lbl_Err_Summary.Text = "";
        }

        private void SetUp()
        {
            DataTable table = new DataTable();

            DataColumn column = new DataColumn("MACS");
            table.Columns.Add(column);
            column = new DataColumn("TENCS");
            table.Columns.Add(column);

            DataRow row = table.NewRow();
            row.ItemArray = new object[] { "CS1", "Cơ sở 1" };
            table.Rows.Add(row);

            row = table.NewRow();
            row.ItemArray = new object[] { "CS2", "Cơ sở 2" };
            table.Rows.Add(row);

            this.cmb_Brand.DataSource = table;

            this.cmb_Brand.DisplayMember = "TENCS";
            cmb_Brand.ValueMember = "MACS";
            this.cmb_Brand.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

        }

        private void btn_Preview_Click(object sender, EventArgs e)
        {
            if (dtp_From.Value > dtp_To.Value)
            {
                ErrorHandler.ShowError(lbl_Err_Summary, new string[] { "OxA001" });
                return;
            }

            try
            {
                this.sp_GetReportTableAdapter.Fill(this.tN_CSDLPTDataSet.sp_GetReport
                    , cmb_Brand.SelectedValue.ToString(), dtp_From.Value.ToShortDateString()
                    , dtp_To.Value.ToShortDateString());
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            if(dtp_From.Value > dtp_To.Value)
            {
                ErrorHandler.ShowError(lbl_Err_Summary, new string[] { "OxA001" });
                return;
            }

            xrp_RegisterExam xrp_RegisterExam = new xrp_RegisterExam(cmb_Brand.SelectedValue.ToString()
                    , dtp_From.Value.ToShortDateString()
                    , dtp_To.Value.ToShortDateString());

            xrp_RegisterExam.lbl_BrandNumber.Text = cmb_Brand.SelectedValue.ToString().Substring(2, 1);
            xrp_RegisterExam.lbl_DateFrom.Text = dtp_From.Value.ToShortDateString();
            xrp_RegisterExam.lbl_DateTo.Text = dtp_To.Value.ToShortDateString();

            ReportPrintTool tool = new ReportPrintTool(xrp_RegisterExam);

            tool.ShowPreviewDialog();
        }
    }
}