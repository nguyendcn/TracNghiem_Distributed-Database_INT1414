using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace TracNghiem_CSDLPT
{
    public partial class XtraReport1 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport1(string MACS, string FROM, string TO)
        {
            InitializeComponent();

            tN_CSDLPTDataSet1.EnforceConstraints = false;
            this.sp_GetReportTableAdapter1.Connection.ConnectionString = Program.connstr;
            this.sp_GetReportTableAdapter1.Fill(this.tN_CSDLPTDataSet1.sp_GetReport, MACS, FROM, TO);
        }

    }
}
