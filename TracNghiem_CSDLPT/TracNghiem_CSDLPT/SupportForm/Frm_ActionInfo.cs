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
using DevExpress.XtraBars;
using System.Diagnostics;

namespace TracNghiem_CSDLPT.SupportForm
{
    public partial class Frm_ActionInfo : DevExpress.XtraEditors.XtraForm
    {
        private Object[] lControl;
        private List<List<bool>> statusControl = new List<List<bool>>();

        public delegate void ChoosenAction(DialogResult result);

        public event ChoosenAction Choosen;

        public Frm_ActionInfo()
        {
            InitializeComponent();

        }

        public Frm_ActionInfo(Object[] lControl, CallBackAction cb)
        {
            InitializeComponent();

            this.lControl = lControl;

            SetupForBgUnderForm(false);

            SetupForm(cb);

            this.FormClosing += Frm_ActionInfo_FormClosing;
        }

        private void Frm_ActionInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            SetupForBgUnderForm(true);
        }

        private void btn_Option_Click(object sender, EventArgs e)
        {
            if((sender as Button).Tag.Equals("NO"))
            {
                OnChoosen(DialogResult.No);
            }
            else if((sender as Button).Tag.Equals("YES"))
            {
                OnChoosen(DialogResult.Yes);
            }
            else if ((sender as Button).Tag.Equals("OK"))
            {
                OnChoosen(DialogResult.OK);
            }

            this.Close();
            this.Dispose();
        }

        public virtual void OnChoosen(DialogResult result)
        {
            if (Choosen != null)
                Choosen(result);
        }

        public void SetupForBgUnderForm(bool isEnable)
        {
            if (this.lControl != null)
            {
                int index = 0;
                foreach(Object obj in lControl)
                {
                    List<bool> status = new List<bool>();

                    if(obj is Control)
                    {
                        if (!isEnable)
                        {
                            status.Add((obj as Control).Enabled);
                            (obj as Control).Enabled = isEnable;
                        }
                        else
                        {
                            (obj as Control).Enabled = statusControl[index][0];
                        }
                        
                    }
                    else if(obj is BarManager)
                    {
                        int col = 0;
                        BarItems items = (obj as BarManager).Items;
                        foreach(BarItem item in items)
                        {
                            if (!isEnable)
                            {
                                status.Add(item.Enabled);
                                item.Enabled = isEnable;
                            }
                            else
                            {
                                item.Enabled = statusControl[index][col];
                            }
                            col++;
                        }
                    }

                    statusControl.Add(status);

                    index++;
                }
            }
        }

        public void Reset()
        {
           
        }

        public void SetupForm(CallBackAction cb)
        {
            this.TopLevel = false;
            this.BringToFront();

            switch (cb.BackAction)
            {
                case Share.Action.RecoveryDelete:
                    this.lbl_Caption.Text = StringLibrary.R_Delete;
                    this.btn_Ok.Visible = false;
                    break;
                case Share.Action.RecoveryEdit:
                    this.lbl_Caption.Text = StringLibrary.R_Edit;
                    this.btn_Ok.Visible = false;
                    break;
                case Share.Action.RecoveryAdd:
                    this.lbl_Caption.Text = StringLibrary.R_Add;
                    this.btn_Ok.Visible = false;
                    break;
                case Share.Action.AddSuccess:
                    this.lbl_Caption.Text = StringLibrary.A_Success;
                    this.btn_No.Visible = this.btn_Yes.Visible = false;
                    break;
                case Share.Action.Delete:
                    this.lbl_Caption.Text = StringLibrary.D_Delete;
                    this.btn_Ok.Visible = false;
                    break;
                case Share.Action.DeleteSuccess:
                    this.lbl_Caption.Text = StringLibrary.D_Success;
                    this.btn_No.Visible = this.btn_Yes.Visible = false;
                    break;
                case Share.Action.EditSuccess:
                    this.lbl_Caption.Text = StringLibrary.E_EditSuccess;
                    this.btn_No.Visible = this.btn_Yes.Visible = false;
                    break;
                case Share.Action.Edit:
                    this.lbl_Caption.Text = StringLibrary.EDIT;
                    this.btn_Ok.Visible = false;
                    break;
                default:
                    return;
            }

            this.dgv_Data.DataSource = cb.Table;

            this.dgv_Data.ColumnAdded += Dgv_Data_ColumnAdded;
        }

        private void Dgv_Data_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
    }
}