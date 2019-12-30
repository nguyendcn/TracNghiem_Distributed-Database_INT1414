using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.Sql;
using System.Collections.Generic;

namespace TracNghiem_CSDLPT
{
    public partial class xrp_RegisterExam : DevExpress.XtraReports.UI.XtraReport
    {
        public xrp_RegisterExam(String MACS, String FROM, String TO)
        {
            InitializeComponent();

            List<QueryParameter> lparam = this.sqlDataSource1.Queries[0].Parameters;

            lparam[0].Value = MACS;
            lparam[1].Value = FROM;
            lparam[2].Value = TO;
        }

    }
}
