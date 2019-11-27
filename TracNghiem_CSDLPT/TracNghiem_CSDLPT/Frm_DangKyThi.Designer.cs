namespace TracNghiem_CSDLPT
{
    partial class Frm_DangKyThi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_DangKyThi));
            this.ds_TN_CSDLPT = new TracNghiem_CSDLPT.TN_CSDLPTDataSet();
            this.tbla_GVDK = new TracNghiem_CSDLPT.TN_CSDLPTDataSetTableAdapters.GIAOVIEN_DANGKYTableAdapter();
            this.tableAdapterManager = new TracNghiem_CSDLPT.TN_CSDLPTDataSetTableAdapters.TableAdapterManager();
            this.tbla_GiaoVien = new TracNghiem_CSDLPT.TN_CSDLPTDataSetTableAdapters.GIAOVIENTableAdapter();
            this.bs_GiaoVien = new System.Windows.Forms.BindingSource(this.components);
            this.bs_GVDK = new System.Windows.Forms.BindingSource(this.components);
            this.gvc_GVDK = new DevExpress.XtraGrid.GridControl();
            this.cms_Menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmi_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMAGV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMAMH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMALOP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTRINHDO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNGAYTHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLAN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSOCAUTHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTHOIGIAN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar4 = new DevExpress.XtraBars.Bar();
            this.bar5 = new DevExpress.XtraBars.Bar();
            this.btn_Register = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Write = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Reset = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Exit = new DevExpress.XtraBars.BarButtonItem();
            this.bar6 = new DevExpress.XtraBars.Bar();
            this.barDockControl3 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.cmb_Level = new System.Windows.Forms.ComboBox();
            this.cmb_Class = new System.Windows.Forms.ComboBox();
            this.bs_Lop = new System.Windows.Forms.BindingSource(this.components);
            this.cmb_Course = new System.Windows.Forms.ComboBox();
            this.bs_MonHoc = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_TeacherCode = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.nud_Hour = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Minute = new System.Windows.Forms.TextBox();
            this.txt_Quantity = new System.Windows.Forms.TextBox();
            this.txt_TimesStep = new System.Windows.Forms.TextBox();
            this.dtp_DateExam = new System.Windows.Forms.DateTimePicker();
            this.tbl_MonHoc = new TracNghiem_CSDLPT.TN_CSDLPTDataSetTableAdapters.MONHOCTableAdapter();
            this.tbl_Lop = new TracNghiem_CSDLPT.TN_CSDLPTDataSetTableAdapters.LOPTableAdapter();
            this.tN_CSDLPTDataSet1 = new TracNghiem_CSDLPT.TN_CSDLPTDataSet();
            ((System.ComponentModel.ISupportInitialize)(this.ds_TN_CSDLPT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_GiaoVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_GVDK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvc_GVDK)).BeginInit();
            this.cms_Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bs_Lop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_MonHoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Hour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tN_CSDLPTDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // ds_TN_CSDLPT
            // 
            this.ds_TN_CSDLPT.DataSetName = "TN_CSDLPTDataSet";
            this.ds_TN_CSDLPT.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbla_GVDK
            // 
            this.tbla_GVDK.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.BANGDIEMTableAdapter = null;
            this.tableAdapterManager.BODETableAdapter = null;
            this.tableAdapterManager.COSOTableAdapter = null;
            this.tableAdapterManager.GIAOVIEN_DANGKYTableAdapter = this.tbla_GVDK;
            this.tableAdapterManager.GIAOVIENTableAdapter = this.tbla_GiaoVien;
            this.tableAdapterManager.KHOATableAdapter = null;
            this.tableAdapterManager.LOPTableAdapter = null;
            this.tableAdapterManager.MONHOCTableAdapter = null;
            this.tableAdapterManager.SINHVIENTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = TracNghiem_CSDLPT.TN_CSDLPTDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // tbla_GiaoVien
            // 
            this.tbla_GiaoVien.ClearBeforeFill = true;
            // 
            // bs_GiaoVien
            // 
            this.bs_GiaoVien.DataMember = "GIAOVIEN";
            this.bs_GiaoVien.DataSource = this.ds_TN_CSDLPT;
            // 
            // bs_GVDK
            // 
            this.bs_GVDK.DataMember = "FK_GIAOVIEN_DANGKY_GIAOVIEN1";
            this.bs_GVDK.DataSource = this.bs_GiaoVien;
            // 
            // gvc_GVDK
            // 
            this.gvc_GVDK.ContextMenuStrip = this.cms_Menu;
            this.gvc_GVDK.DataSource = this.bs_GVDK;
            this.gvc_GVDK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvc_GVDK.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.gvc_GVDK.Location = new System.Drawing.Point(0, 0);
            this.gvc_GVDK.MainView = this.gridView1;
            this.gvc_GVDK.Margin = new System.Windows.Forms.Padding(2);
            this.gvc_GVDK.Name = "gvc_GVDK";
            this.gvc_GVDK.Size = new System.Drawing.Size(943, 286);
            this.gvc_GVDK.TabIndex = 0;
            this.gvc_GVDK.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // cms_Menu
            // 
            this.cms_Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_Delete,
            this.tsmi_Edit});
            this.cms_Menu.Name = "contextMenuStrip1";
            this.cms_Menu.Size = new System.Drawing.Size(95, 48);
            // 
            // tsmi_Delete
            // 
            this.tsmi_Delete.Name = "tsmi_Delete";
            this.tsmi_Delete.Size = new System.Drawing.Size(94, 22);
            this.tsmi_Delete.Text = "Xóa";
            // 
            // tsmi_Edit
            // 
            this.tsmi_Edit.Name = "tsmi_Edit";
            this.tsmi_Edit.Size = new System.Drawing.Size(94, 22);
            this.tsmi_Edit.Text = "Sửa";
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMAGV,
            this.colMAMH,
            this.colMALOP,
            this.colTRINHDO,
            this.colNGAYTHI,
            this.colLAN,
            this.colSOCAUTHI,
            this.colTHOIGIAN});
            this.gridView1.GridControl = this.gvc_GVDK;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            // 
            // colMAGV
            // 
            this.colMAGV.FieldName = "MAGV";
            this.colMAGV.Name = "colMAGV";
            this.colMAGV.Visible = true;
            this.colMAGV.VisibleIndex = 0;
            // 
            // colMAMH
            // 
            this.colMAMH.FieldName = "MAMH";
            this.colMAMH.Name = "colMAMH";
            this.colMAMH.Visible = true;
            this.colMAMH.VisibleIndex = 1;
            // 
            // colMALOP
            // 
            this.colMALOP.FieldName = "MALOP";
            this.colMALOP.Name = "colMALOP";
            this.colMALOP.Visible = true;
            this.colMALOP.VisibleIndex = 2;
            // 
            // colTRINHDO
            // 
            this.colTRINHDO.FieldName = "TRINHDO";
            this.colTRINHDO.Name = "colTRINHDO";
            this.colTRINHDO.Visible = true;
            this.colTRINHDO.VisibleIndex = 3;
            // 
            // colNGAYTHI
            // 
            this.colNGAYTHI.FieldName = "NGAYTHI";
            this.colNGAYTHI.Name = "colNGAYTHI";
            this.colNGAYTHI.Visible = true;
            this.colNGAYTHI.VisibleIndex = 4;
            // 
            // colLAN
            // 
            this.colLAN.FieldName = "LAN";
            this.colLAN.Name = "colLAN";
            this.colLAN.Visible = true;
            this.colLAN.VisibleIndex = 5;
            // 
            // colSOCAUTHI
            // 
            this.colSOCAUTHI.FieldName = "SOCAUTHI";
            this.colSOCAUTHI.Name = "colSOCAUTHI";
            this.colSOCAUTHI.Visible = true;
            this.colSOCAUTHI.VisibleIndex = 6;
            // 
            // colTHOIGIAN
            // 
            this.colTHOIGIAN.FieldName = "THOIGIAN";
            this.colTHOIGIAN.Name = "colTHOIGIAN";
            this.colTHOIGIAN.Visible = true;
            this.colTHOIGIAN.VisibleIndex = 7;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar4,
            this.bar5,
            this.bar6});
            this.barManager1.DockControls.Add(this.barDockControl3);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btn_Register,
            this.btn_Write,
            this.btn_Reset,
            this.btn_Exit});
            this.barManager1.MainMenu = this.bar5;
            this.barManager1.MaxItemId = 6;
            this.barManager1.StatusBar = this.bar6;
            // 
            // bar4
            // 
            this.bar4.BarName = "Tools";
            this.bar4.DockCol = 0;
            this.bar4.DockRow = 1;
            this.bar4.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar4.Text = "Tools";
            // 
            // bar5
            // 
            this.bar5.BarName = "Main menu";
            this.bar5.DockCol = 0;
            this.bar5.DockRow = 0;
            this.bar5.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar5.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btn_Register, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btn_Write, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btn_Reset, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btn_Exit, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar5.OptionsBar.MultiLine = true;
            this.bar5.OptionsBar.UseWholeRow = true;
            this.bar5.Text = "Main menu";
            // 
            // btn_Register
            // 
            this.btn_Register.Caption = "Đăng Ký";
            this.btn_Register.Id = 0;
            this.btn_Register.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Register.ImageOptions.Image")));
            this.btn_Register.Name = "btn_Register";
            // 
            // btn_Write
            // 
            this.btn_Write.Caption = "Ghi";
            this.btn_Write.Id = 2;
            this.btn_Write.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Write.ImageOptions.Image")));
            this.btn_Write.Name = "btn_Write";
            // 
            // btn_Reset
            // 
            this.btn_Reset.Caption = "Phục Hồi";
            this.btn_Reset.Id = 3;
            this.btn_Reset.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Reset.ImageOptions.Image")));
            this.btn_Reset.Name = "btn_Reset";
            // 
            // btn_Exit
            // 
            this.btn_Exit.Caption = "Thoát";
            this.btn_Exit.Id = 5;
            this.btn_Exit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Exit.ImageOptions.Image")));
            this.btn_Exit.Name = "btn_Exit";
            // 
            // bar6
            // 
            this.bar6.BarName = "Status bar";
            this.bar6.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar6.DockCol = 0;
            this.bar6.DockRow = 0;
            this.bar6.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar6.OptionsBar.AllowQuickCustomization = false;
            this.bar6.OptionsBar.DrawDragBorder = false;
            this.bar6.OptionsBar.UseWholeRow = true;
            this.bar6.Text = "Status bar";
            // 
            // barDockControl3
            // 
            this.barDockControl3.CausesValidation = false;
            this.barDockControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControl3.Location = new System.Drawing.Point(0, 0);
            this.barDockControl3.Manager = this.barManager1;
            this.barDockControl3.Margin = new System.Windows.Forms.Padding(5);
            this.barDockControl3.Size = new System.Drawing.Size(943, 69);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 552);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(5);
            this.barDockControlBottom.Size = new System.Drawing.Size(943, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 69);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(5);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 483);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(943, 69);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(5);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 483);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 69);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gvc_GVDK);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(943, 483);
            this.splitContainer1.SplitterDistance = 286;
            this.splitContainer1.TabIndex = 5;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.cmb_Level);
            this.splitContainer2.Panel1.Controls.Add(this.cmb_Class);
            this.splitContainer2.Panel1.Controls.Add(this.cmb_Course);
            this.splitContainer2.Panel1.Controls.Add(this.label4);
            this.splitContainer2.Panel1.Controls.Add(this.label3);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.txt_TeacherCode);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.AutoScroll = true;
            this.splitContainer2.Panel2.Controls.Add(this.label10);
            this.splitContainer2.Panel2.Controls.Add(this.label9);
            this.splitContainer2.Panel2.Controls.Add(this.nud_Hour);
            this.splitContainer2.Panel2.Controls.Add(this.label8);
            this.splitContainer2.Panel2.Controls.Add(this.label7);
            this.splitContainer2.Panel2.Controls.Add(this.label6);
            this.splitContainer2.Panel2.Controls.Add(this.label5);
            this.splitContainer2.Panel2.Controls.Add(this.txt_Minute);
            this.splitContainer2.Panel2.Controls.Add(this.txt_Quantity);
            this.splitContainer2.Panel2.Controls.Add(this.txt_TimesStep);
            this.splitContainer2.Panel2.Controls.Add(this.dtp_DateExam);
            this.splitContainer2.Size = new System.Drawing.Size(943, 193);
            this.splitContainer2.SplitterDistance = 386;
            this.splitContainer2.SplitterWidth = 3;
            this.splitContainer2.TabIndex = 0;
            // 
            // cmb_Level
            // 
            this.cmb_Level.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmb_Level.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_Level.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Level.FormattingEnabled = true;
            this.cmb_Level.Location = new System.Drawing.Point(98, 116);
            this.cmb_Level.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmb_Level.Name = "cmb_Level";
            this.cmb_Level.Size = new System.Drawing.Size(92, 25);
            this.cmb_Level.TabIndex = 7;
            // 
            // cmb_Class
            // 
            this.cmb_Class.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmb_Class.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_Class.DataSource = this.bs_Lop;
            this.cmb_Class.DisplayMember = "TENLOP";
            this.cmb_Class.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Class.FormattingEnabled = true;
            this.cmb_Class.Location = new System.Drawing.Point(98, 80);
            this.cmb_Class.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmb_Class.Name = "cmb_Class";
            this.cmb_Class.Size = new System.Drawing.Size(156, 25);
            this.cmb_Class.TabIndex = 6;
            this.cmb_Class.ValueMember = "MALOP";
            // 
            // bs_Lop
            // 
            this.bs_Lop.DataMember = "LOP";
            this.bs_Lop.DataSource = this.ds_TN_CSDLPT;
            // 
            // cmb_Course
            // 
            this.cmb_Course.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmb_Course.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_Course.DataSource = this.bs_MonHoc;
            this.cmb_Course.DisplayMember = "TENMH";
            this.cmb_Course.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Course.FormattingEnabled = true;
            this.cmb_Course.Location = new System.Drawing.Point(98, 49);
            this.cmb_Course.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmb_Course.Name = "cmb_Course";
            this.cmb_Course.Size = new System.Drawing.Size(156, 25);
            this.cmb_Course.TabIndex = 5;
            this.cmb_Course.ValueMember = "MAMH";
            // 
            // bs_MonHoc
            // 
            this.bs_MonHoc.DataMember = "MONHOC";
            this.bs_MonHoc.DataSource = this.ds_TN_CSDLPT;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 116);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Trình Độ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 83);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Lớp";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 51);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Môn Học";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã Giáo Viên";
            // 
            // txt_TeacherCode
            // 
            this.txt_TeacherCode.Location = new System.Drawing.Point(98, 15);
            this.txt_TeacherCode.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_TeacherCode.Name = "txt_TeacherCode";
            this.txt_TeacherCode.ReadOnly = true;
            this.txt_TeacherCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_TeacherCode.Size = new System.Drawing.Size(93, 25);
            this.txt_TeacherCode.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(218, 120);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 17);
            this.label10.TabIndex = 10;
            this.label10.Text = "phút";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(162, 120);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 17);
            this.label9.TabIndex = 9;
            this.label9.Text = "giờ";
            // 
            // nud_Hour
            // 
            this.nud_Hour.Location = new System.Drawing.Point(128, 117);
            this.nud_Hour.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nud_Hour.Name = "nud_Hour";
            this.nud_Hour.Size = new System.Drawing.Size(26, 25);
            this.nud_Hour.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(31, 122);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 17);
            this.label8.TabIndex = 7;
            this.label8.Text = "Thời gian";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 85);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "Số câu";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 54);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Lần thi";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 21);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Ngày thi";
            // 
            // txt_Minute
            // 
            this.txt_Minute.Location = new System.Drawing.Point(188, 116);
            this.txt_Minute.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_Minute.Name = "txt_Minute";
            this.txt_Minute.Size = new System.Drawing.Size(27, 25);
            this.txt_Minute.TabIndex = 3;
            // 
            // txt_Quantity
            // 
            this.txt_Quantity.Location = new System.Drawing.Point(128, 83);
            this.txt_Quantity.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_Quantity.Name = "txt_Quantity";
            this.txt_Quantity.Size = new System.Drawing.Size(54, 25);
            this.txt_Quantity.TabIndex = 2;
            // 
            // txt_TimesStep
            // 
            this.txt_TimesStep.Location = new System.Drawing.Point(128, 52);
            this.txt_TimesStep.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_TimesStep.Name = "txt_TimesStep";
            this.txt_TimesStep.Size = new System.Drawing.Size(54, 25);
            this.txt_TimesStep.TabIndex = 1;
            // 
            // dtp_DateExam
            // 
            this.dtp_DateExam.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_DateExam.Location = new System.Drawing.Point(128, 17);
            this.dtp_DateExam.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtp_DateExam.Name = "dtp_DateExam";
            this.dtp_DateExam.Size = new System.Drawing.Size(137, 25);
            this.dtp_DateExam.TabIndex = 0;
            // 
            // tbl_MonHoc
            // 
            this.tbl_MonHoc.ClearBeforeFill = true;
            // 
            // tbl_Lop
            // 
            this.tbl_Lop.ClearBeforeFill = true;
            // 
            // tN_CSDLPTDataSet1
            // 
            this.tN_CSDLPTDataSet1.DataSetName = "TN_CSDLPTDataSet";
            this.tN_CSDLPTDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Frm_DangKyThi
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 575);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControl3);
            this.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Frm_DangKyThi";
            this.Text = "Frm_DangKyThi";
            this.Load += new System.EventHandler(this.Frm_DangKyThi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ds_TN_CSDLPT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_GiaoVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_GVDK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvc_GVDK)).EndInit();
            this.cms_Menu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bs_Lop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_MonHoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Hour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tN_CSDLPTDataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TN_CSDLPTDataSet ds_TN_CSDLPT;
        private TN_CSDLPTDataSetTableAdapters.GIAOVIEN_DANGKYTableAdapter tbla_GVDK;
        private TN_CSDLPTDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private TN_CSDLPTDataSetTableAdapters.GIAOVIENTableAdapter tbla_GiaoVien;
        private System.Windows.Forms.BindingSource bs_GiaoVien;
        private System.Windows.Forms.BindingSource bs_GVDK;
        private DevExpress.XtraGrid.GridControl gvc_GVDK;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colMAGV;
        private DevExpress.XtraGrid.Columns.GridColumn colMAMH;
        private DevExpress.XtraGrid.Columns.GridColumn colMALOP;
        private DevExpress.XtraGrid.Columns.GridColumn colTRINHDO;
        private DevExpress.XtraGrid.Columns.GridColumn colNGAYTHI;
        private DevExpress.XtraGrid.Columns.GridColumn colLAN;
        private DevExpress.XtraGrid.Columns.GridColumn colSOCAUTHI;
        private DevExpress.XtraGrid.Columns.GridColumn colTHOIGIAN;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar4;
        private DevExpress.XtraBars.Bar bar5;
        private DevExpress.XtraBars.BarButtonItem btn_Register;
        private DevExpress.XtraBars.BarButtonItem btn_Write;
        private DevExpress.XtraBars.BarButtonItem btn_Reset;
        private DevExpress.XtraBars.BarButtonItem btn_Exit;
        private DevExpress.XtraBars.Bar bar6;
        private DevExpress.XtraBars.BarDockControl barDockControl3;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ContextMenuStrip cms_Menu;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Delete;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Edit;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ComboBox cmb_Course;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_TeacherCode;
        private System.Windows.Forms.BindingSource bs_MonHoc;
        private TN_CSDLPTDataSetTableAdapters.MONHOCTableAdapter tbl_MonHoc;
        private System.Windows.Forms.BindingSource bs_Lop;
        private TN_CSDLPTDataSetTableAdapters.LOPTableAdapter tbl_Lop;
        private System.Windows.Forms.ComboBox cmb_Class;
        private System.Windows.Forms.ComboBox cmb_Level;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown nud_Hour;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_Minute;
        private System.Windows.Forms.TextBox txt_Quantity;
        private System.Windows.Forms.TextBox txt_TimesStep;
        private System.Windows.Forms.DateTimePicker dtp_DateExam;
        private TN_CSDLPTDataSet tN_CSDLPTDataSet1;
    }
}