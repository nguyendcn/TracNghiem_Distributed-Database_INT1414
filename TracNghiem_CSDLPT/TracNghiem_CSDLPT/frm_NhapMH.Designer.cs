namespace TracNghiem_CSDLPT
{
    partial class frm_NhapMH
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_NhapMH));
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.brm_Option = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.btn_Add = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Edit = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Write = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Reset = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Delete = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Exit = new DevExpress.XtraBars.BarButtonItem();
            this.bar4 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.ds_TN_CSDLPT = new TracNghiem_CSDLPT.TN_CSDLPTDataSet();
            this.bs_MonHoc = new System.Windows.Forms.BindingSource(this.components);
            this.tbla_MonHoc = new TracNghiem_CSDLPT.TN_CSDLPTDataSetTableAdapters.MONHOCTableAdapter();
            this.tableAdapterManager = new TracNghiem_CSDLPT.TN_CSDLPTDataSetTableAdapters.TableAdapterManager();
            this.bs_GVDK = new System.Windows.Forms.BindingSource(this.components);
            this.tbla_GVDK = new TracNghiem_CSDLPT.TN_CSDLPTDataSetTableAdapters.GIAOVIEN_DANGKYTableAdapter();
            this.bs_BoDe = new System.Windows.Forms.BindingSource(this.components);
            this.tbla_BoDe = new TracNghiem_CSDLPT.TN_CSDLPTDataSetTableAdapters.BODETableAdapter();
            this.bs_BangDiem = new System.Windows.Forms.BindingSource(this.components);
            this.tbla_BangDiem = new TracNghiem_CSDLPT.TN_CSDLPTDataSetTableAdapters.BANGDIEMTableAdapter();
            this.splc_Container = new System.Windows.Forms.SplitContainer();
            this.gcv_MonHoc = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMAMH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTENMH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnl_ConstructArea = new System.Windows.Forms.Panel();
            this.lbl_Err_NameCourse = new System.Windows.Forms.Label();
            this.lbl_Err_CodeCourse = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_NameCourse = new System.Windows.Forms.TextBox();
            this.txt_CodeCourse = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.brm_Option)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ds_TN_CSDLPT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_MonHoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_GVDK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_BoDe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_BangDiem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splc_Container)).BeginInit();
            this.splc_Container.Panel1.SuspendLayout();
            this.splc_Container.Panel2.SuspendLayout();
            this.splc_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcv_MonHoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.pnl_ConstructArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // brm_Option
            // 
            this.brm_Option.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar3,
            this.bar4});
            this.brm_Option.DockControls.Add(this.barDockControlTop);
            this.brm_Option.DockControls.Add(this.barDockControlBottom);
            this.brm_Option.DockControls.Add(this.barDockControlLeft);
            this.brm_Option.DockControls.Add(this.barDockControlRight);
            this.brm_Option.Form = this;
            this.brm_Option.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btn_Add,
            this.btn_Edit,
            this.btn_Write,
            this.btn_Reset,
            this.btn_Delete,
            this.btn_Exit});
            this.brm_Option.MainMenu = this.bar3;
            this.brm_Option.MaxItemId = 6;
            this.brm_Option.StatusBar = this.bar4;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 1;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.Text = "Tools";
            // 
            // bar3
            // 
            this.bar3.BarName = "Main menu";
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btn_Add, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btn_Edit, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btn_Write, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btn_Reset, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btn_Delete, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btn_Exit, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar3.OptionsBar.MultiLine = true;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Main menu";
            // 
            // btn_Add
            // 
            this.btn_Add.Caption = "Thêm";
            this.btn_Add.Id = 0;
            this.btn_Add.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Add.ImageOptions.Image")));
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_Add_ItemClick);
            // 
            // btn_Edit
            // 
            this.btn_Edit.Caption = "Sửa";
            this.btn_Edit.Id = 1;
            this.btn_Edit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Edit.ImageOptions.Image")));
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_Edit_ItemClick);
            // 
            // btn_Write
            // 
            this.btn_Write.Caption = "Ghi";
            this.btn_Write.Id = 2;
            this.btn_Write.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Write.ImageOptions.Image")));
            this.btn_Write.Name = "btn_Write";
            this.btn_Write.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_Write_ItemClick);
            // 
            // btn_Reset
            // 
            this.btn_Reset.Caption = "Phục Hồi";
            this.btn_Reset.Id = 3;
            this.btn_Reset.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Reset.ImageOptions.Image")));
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_Reset_ItemClick);
            // 
            // btn_Delete
            // 
            this.btn_Delete.Caption = "Xóa";
            this.btn_Delete.Id = 4;
            this.btn_Delete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Delete.ImageOptions.Image")));
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_Delete_ItemClick);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Caption = "Thoát";
            this.btn_Exit.Id = 5;
            this.btn_Exit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Exit.ImageOptions.Image")));
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_Exit_ItemClick);
            // 
            // bar4
            // 
            this.bar4.BarName = "Status bar";
            this.bar4.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar4.DockCol = 0;
            this.bar4.DockRow = 0;
            this.bar4.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar4.OptionsBar.AllowQuickCustomization = false;
            this.bar4.OptionsBar.DrawDragBorder = false;
            this.bar4.OptionsBar.UseWholeRow = true;
            this.bar4.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.brm_Option;
            this.barDockControlTop.Size = new System.Drawing.Size(1010, 69);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 424);
            this.barDockControlBottom.Manager = this.brm_Option;
            this.barDockControlBottom.Size = new System.Drawing.Size(1010, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 69);
            this.barDockControlLeft.Manager = this.brm_Option;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 355);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1010, 69);
            this.barDockControlRight.Manager = this.brm_Option;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 355);
            // 
            // ds_TN_CSDLPT
            // 
            this.ds_TN_CSDLPT.DataSetName = "TN_CSDLPTDataSet";
            this.ds_TN_CSDLPT.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bs_MonHoc
            // 
            this.bs_MonHoc.DataMember = "MONHOC";
            this.bs_MonHoc.DataSource = this.ds_TN_CSDLPT;
            // 
            // tbla_MonHoc
            // 
            this.tbla_MonHoc.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.BANGDIEMTableAdapter = null;
            this.tableAdapterManager.BODETableAdapter = null;
            this.tableAdapterManager.COSOTableAdapter = null;
            this.tableAdapterManager.GIAOVIEN_DANGKYTableAdapter = null;
            this.tableAdapterManager.GIAOVIENTableAdapter = null;
            this.tableAdapterManager.KHOATableAdapter = null;
            this.tableAdapterManager.LOPTableAdapter = null;
            this.tableAdapterManager.MONHOCTableAdapter = this.tbla_MonHoc;
            this.tableAdapterManager.SINHVIENTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = TracNghiem_CSDLPT.TN_CSDLPTDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // bs_GVDK
            // 
            this.bs_GVDK.DataMember = "FK_GIAOVIEN_DANGKY_MONHOC1";
            this.bs_GVDK.DataSource = this.bs_MonHoc;
            // 
            // tbla_GVDK
            // 
            this.tbla_GVDK.ClearBeforeFill = true;
            // 
            // bs_BoDe
            // 
            this.bs_BoDe.DataMember = "FK_BODE_MONHOC";
            this.bs_BoDe.DataSource = this.bs_MonHoc;
            // 
            // tbla_BoDe
            // 
            this.tbla_BoDe.ClearBeforeFill = true;
            // 
            // bs_BangDiem
            // 
            this.bs_BangDiem.DataMember = "FK_BANGDIEM_MONHOC";
            this.bs_BangDiem.DataSource = this.bs_MonHoc;
            // 
            // tbla_BangDiem
            // 
            this.tbla_BangDiem.ClearBeforeFill = true;
            // 
            // splc_Container
            // 
            this.splc_Container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splc_Container.Location = new System.Drawing.Point(0, 69);
            this.splc_Container.Name = "splc_Container";
            this.splc_Container.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splc_Container.Panel1
            // 
            this.splc_Container.Panel1.Controls.Add(this.gcv_MonHoc);
            // 
            // splc_Container.Panel2
            // 
            this.splc_Container.Panel2.Controls.Add(this.pnl_ConstructArea);
            this.splc_Container.Size = new System.Drawing.Size(1010, 355);
            this.splc_Container.SplitterDistance = 232;
            this.splc_Container.TabIndex = 24;
            // 
            // gcv_MonHoc
            // 
            this.gcv_MonHoc.DataSource = this.bs_MonHoc;
            this.gcv_MonHoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcv_MonHoc.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.gcv_MonHoc.Location = new System.Drawing.Point(0, 0);
            this.gcv_MonHoc.MainView = this.gridView1;
            this.gcv_MonHoc.Margin = new System.Windows.Forms.Padding(2);
            this.gcv_MonHoc.MenuManager = this.brm_Option;
            this.gcv_MonHoc.Name = "gcv_MonHoc";
            this.gcv_MonHoc.Size = new System.Drawing.Size(1010, 232);
            this.gcv_MonHoc.TabIndex = 17;
            this.gcv_MonHoc.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMAMH,
            this.colTENMH});
            this.gridView1.GridControl = this.gcv_MonHoc;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            // 
            // colMAMH
            // 
            this.colMAMH.Caption = "Mã Môn học";
            this.colMAMH.FieldName = "MAMH";
            this.colMAMH.Name = "colMAMH";
            this.colMAMH.Visible = true;
            this.colMAMH.VisibleIndex = 0;
            // 
            // colTENMH
            // 
            this.colTENMH.Caption = "Tên Môn Học";
            this.colTENMH.FieldName = "TENMH";
            this.colTENMH.Name = "colTENMH";
            this.colTENMH.Visible = true;
            this.colTENMH.VisibleIndex = 1;
            // 
            // pnl_ConstructArea
            // 
            this.pnl_ConstructArea.Controls.Add(this.lbl_Err_NameCourse);
            this.pnl_ConstructArea.Controls.Add(this.lbl_Err_CodeCourse);
            this.pnl_ConstructArea.Controls.Add(this.label2);
            this.pnl_ConstructArea.Controls.Add(this.label1);
            this.pnl_ConstructArea.Controls.Add(this.txt_NameCourse);
            this.pnl_ConstructArea.Controls.Add(this.txt_CodeCourse);
            this.pnl_ConstructArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_ConstructArea.Enabled = false;
            this.pnl_ConstructArea.Location = new System.Drawing.Point(0, 0);
            this.pnl_ConstructArea.Margin = new System.Windows.Forms.Padding(2);
            this.pnl_ConstructArea.Name = "pnl_ConstructArea";
            this.pnl_ConstructArea.Size = new System.Drawing.Size(1010, 119);
            this.pnl_ConstructArea.TabIndex = 0;
            // 
            // lbl_Err_NameCourse
            // 
            this.lbl_Err_NameCourse.AutoSize = true;
            this.lbl_Err_NameCourse.ForeColor = System.Drawing.Color.Red;
            this.lbl_Err_NameCourse.Location = new System.Drawing.Point(604, 61);
            this.lbl_Err_NameCourse.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Err_NameCourse.Name = "lbl_Err_NameCourse";
            this.lbl_Err_NameCourse.Size = new System.Drawing.Size(27, 17);
            this.lbl_Err_NameCourse.TabIndex = 24;
            this.lbl_Err_NameCourse.Text = "Err";
            // 
            // lbl_Err_CodeCourse
            // 
            this.lbl_Err_CodeCourse.AutoSize = true;
            this.lbl_Err_CodeCourse.ForeColor = System.Drawing.Color.Red;
            this.lbl_Err_CodeCourse.Location = new System.Drawing.Point(604, 17);
            this.lbl_Err_CodeCourse.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Err_CodeCourse.Name = "lbl_Err_CodeCourse";
            this.lbl_Err_CodeCourse.Size = new System.Drawing.Size(27, 17);
            this.lbl_Err_CodeCourse.TabIndex = 23;
            this.lbl_Err_CodeCourse.Text = "Err";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(131, 61);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 17);
            this.label2.TabIndex = 22;
            this.label2.Text = "Tên môn học";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(131, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 17);
            this.label1.TabIndex = 21;
            this.label1.Text = "Mã môn học";
            // 
            // txt_NameCourse
            // 
            this.txt_NameCourse.Location = new System.Drawing.Point(292, 58);
            this.txt_NameCourse.Margin = new System.Windows.Forms.Padding(2);
            this.txt_NameCourse.Name = "txt_NameCourse";
            this.txt_NameCourse.Size = new System.Drawing.Size(308, 25);
            this.txt_NameCourse.TabIndex = 20;
            this.txt_NameCourse.DoubleClick += new System.EventHandler(this.Txt_InputText_DoubleClick);
            // 
            // txt_CodeCourse
            // 
            this.txt_CodeCourse.Location = new System.Drawing.Point(292, 14);
            this.txt_CodeCourse.Margin = new System.Windows.Forms.Padding(2);
            this.txt_CodeCourse.Name = "txt_CodeCourse";
            this.txt_CodeCourse.Size = new System.Drawing.Size(308, 25);
            this.txt_CodeCourse.TabIndex = 19;
            this.txt_CodeCourse.DoubleClick += new System.EventHandler(this.Txt_InputText_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(586, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(232, 89);
            this.panel1.TabIndex = 19;
            // 
            // frm_NhapMH
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 447);
            this.Controls.Add(this.splc_Container);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_NhapMH";
            this.Text = "frm_NhapMH";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_NhapMH_Load);
            ((System.ComponentModel.ISupportInitialize)(this.brm_Option)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ds_TN_CSDLPT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_MonHoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_GVDK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_BoDe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_BangDiem)).EndInit();
            this.splc_Container.Panel1.ResumeLayout(false);
            this.splc_Container.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splc_Container)).EndInit();
            this.splc_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcv_MonHoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.pnl_ConstructArea.ResumeLayout(false);
            this.pnl_ConstructArea.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarManager brm_Option;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarButtonItem btn_Add;
        private DevExpress.XtraBars.BarButtonItem btn_Edit;
        private DevExpress.XtraBars.BarButtonItem btn_Write;
        private DevExpress.XtraBars.BarButtonItem btn_Reset;
        private DevExpress.XtraBars.BarButtonItem btn_Delete;
        private DevExpress.XtraBars.BarButtonItem btn_Exit;
        private DevExpress.XtraBars.Bar bar4;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private System.Windows.Forms.BindingSource bs_MonHoc;
        private TN_CSDLPTDataSet ds_TN_CSDLPT;
        private TN_CSDLPTDataSetTableAdapters.MONHOCTableAdapter tbla_MonHoc;
        private TN_CSDLPTDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingSource bs_GVDK;
        private TN_CSDLPTDataSetTableAdapters.GIAOVIEN_DANGKYTableAdapter tbla_GVDK;
        private System.Windows.Forms.BindingSource bs_BoDe;
        private TN_CSDLPTDataSetTableAdapters.BODETableAdapter tbla_BoDe;
        private System.Windows.Forms.BindingSource bs_BangDiem;
        private TN_CSDLPTDataSetTableAdapters.BANGDIEMTableAdapter tbla_BangDiem;
        private System.Windows.Forms.SplitContainer splc_Container;
        private DevExpress.XtraGrid.GridControl gcv_MonHoc;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colMAMH;
        private DevExpress.XtraGrid.Columns.GridColumn colTENMH;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnl_ConstructArea;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_NameCourse;
        private System.Windows.Forms.TextBox txt_CodeCourse;
        private System.Windows.Forms.Label lbl_Err_NameCourse;
        private System.Windows.Forms.Label lbl_Err_CodeCourse;
    }
}