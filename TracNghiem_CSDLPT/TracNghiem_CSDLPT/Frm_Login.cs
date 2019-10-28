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
    public partial class Frm_Login : Form
    {
        public Frm_Login()
        {
            InitializeComponent();
        }

        private void btn_SV_Click(object sender, EventArgs e)
        {
            pnl_GV.Visible = false;
            pnl_SV.Visible = true;
            pnl_SV.BringToFront();
            btn_SV.BringToFront();
            btn_GV.SendToBack();

            btn_SV.BackColor = Color.SandyBrown;
            btn_GV.BackColor = Color.PeachPuff;
        }

        private void btn_GV_Click(object sender, EventArgs e)
        {
            pnl_SV.Visible = false;
            pnl_GV.Visible = true;
            pnl_GV.BringToFront();
            btn_SV.SendToBack();
            btn_GV.BringToFront();

            btn_GV.BackColor = Color.SandyBrown;
            btn_SV.BackColor = Color.PeachPuff;
        }

        private void btn_Login_SV_Click(object sender, EventArgs e)
        {

        }
    }
}
