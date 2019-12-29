using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Parameters;

namespace TracNghiem_CSDLPT
{
    public partial class XtraReport1 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport1(String MACS, String FROM, String TO)
        {
            InitializeComponent();

            this.BeforePrint += XtraReport1_BeforePrint;

            tN_CSDLPTDataSet1.EnforceConstraints = false;
            this.sp_GetReportTableAdapter1.Connection.ConnectionString = Program.connstr;
            this.sp_GetReportTableAdapter1.Fill(this.tN_CSDLPTDataSet1.sp_GetReport, MACS, FROM, TO);
        }

        private void XtraReport1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            int a = Parameters.Count;

            Parameter parameter1 = new Parameter();
            parameter1.Name = "@MACS";
            parameter1.Type = typeof(System.String);
            parameter1.ValueInfo = "CS1";

            Parameter parameter2 = new Parameter();
            parameter2.Name = "@FROM";
            parameter2.Type = typeof(System.String);
            parameter2.ValueInfo = "2019-12-12";

            Parameter parameter3 = new Parameter();
            parameter3.Name = "@TO";
            parameter3.Type = typeof(System.String);
            parameter3.ValueInfo = "2019-12-29";

            Parameters.AddRange(new Parameter[] { parameter1, parameter2, parameter3 });

            this.sp_GetReportTableAdapter1.Fill(
                (this.DataSource as TN_CSDLPTDataSet).sp_GetReport,
                 Parameters["@MACS"].Value.ToString(), "2019-12-12", "2019-12-29");
        }
    }
}
