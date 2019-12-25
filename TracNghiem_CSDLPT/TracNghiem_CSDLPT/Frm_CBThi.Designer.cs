namespace TracNghiem_CSDLPT
{
    partial class Frm_CBThi
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
            this.grb_InfoFind = new System.Windows.Forms.GroupBox();
            this.btn_Find = new System.Windows.Forms.Button();
            this.dtp_DateExam = new System.Windows.Forms.DateTimePicker();
            this.nud_TimesStep = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bs_MonHoc = new System.Windows.Forms.BindingSource(this.components);
            this.ds_TN_CSDLPT = new TracNghiem_CSDLPT.TN_CSDLPTDataSet();
            this.tbla_MONHOC = new TracNghiem_CSDLPT.TN_CSDLPTDataSetTableAdapters.MONHOCTableAdapter();
            this.tableAdapterManager = new TracNghiem_CSDLPT.TN_CSDLPTDataSetTableAdapters.TableAdapterManager();
            this.tbla_GVDK = new TracNghiem_CSDLPT.TN_CSDLPTDataSetTableAdapters.GIAOVIEN_DANGKYTableAdapter();
            this.grb_StartExam = new System.Windows.Forms.GroupBox();
            this.btn_Start = new System.Windows.Forms.Button();
            this.dgv_Results = new System.Windows.Forms.DataGridView();
            this.bs_GVDK = new System.Windows.Forms.BindingSource(this.components);
            this.grb_InfoStudent = new System.Windows.Forms.GroupBox();
            this.lbl_StudentCode = new System.Windows.Forms.Label();
            this.lbl_StudentName = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbl_ClassName = new System.Windows.Forms.Label();
            this.lbl_ClassCode = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmb_Course = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grb_InfoFind.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_TimesStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_MonHoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ds_TN_CSDLPT)).BeginInit();
            this.grb_StartExam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Results)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_GVDK)).BeginInit();
            this.grb_InfoStudent.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grb_InfoFind
            // 
            this.grb_InfoFind.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grb_InfoFind.Controls.Add(this.cmb_Course);
            this.grb_InfoFind.Controls.Add(this.btn_Find);
            this.grb_InfoFind.Controls.Add(this.dtp_DateExam);
            this.grb_InfoFind.Controls.Add(this.nud_TimesStep);
            this.grb_InfoFind.Controls.Add(this.label3);
            this.grb_InfoFind.Controls.Add(this.label2);
            this.grb_InfoFind.Controls.Add(this.label1);
            this.grb_InfoFind.Location = new System.Drawing.Point(3, 118);
            this.grb_InfoFind.Name = "grb_InfoFind";
            this.grb_InfoFind.Size = new System.Drawing.Size(774, 122);
            this.grb_InfoFind.TabIndex = 1;
            this.grb_InfoFind.TabStop = false;
            this.grb_InfoFind.Text = "Thông tin thi";
            // 
            // btn_Find
            // 
            this.btn_Find.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Find.Location = new System.Drawing.Point(260, 82);
            this.btn_Find.Name = "btn_Find";
            this.btn_Find.Size = new System.Drawing.Size(208, 34);
            this.btn_Find.TabIndex = 2;
            this.btn_Find.Text = "Tìm";
            this.btn_Find.UseVisualStyleBackColor = true;
            this.btn_Find.Click += new System.EventHandler(this.btn_Find_Click);
            // 
            // dtp_DateExam
            // 
            this.dtp_DateExam.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_DateExam.Location = new System.Drawing.Point(326, 25);
            this.dtp_DateExam.Name = "dtp_DateExam";
            this.dtp_DateExam.Size = new System.Drawing.Size(142, 26);
            this.dtp_DateExam.TabIndex = 6;
            // 
            // nud_TimesStep
            // 
            this.nud_TimesStep.InterceptArrowKeys = false;
            this.nud_TimesStep.Location = new System.Drawing.Point(579, 29);
            this.nud_TimesStep.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nud_TimesStep.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_TimesStep.Name = "nud_TimesStep";
            this.nud_TimesStep.Size = new System.Drawing.Size(45, 26);
            this.nud_TimesStep.TabIndex = 5;
            this.nud_TimesStep.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(520, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Lần thi:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(257, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ngày thi:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Môn thi:";
            // 
            // bs_MonHoc
            // 
            this.bs_MonHoc.DataMember = "MONHOC";
            this.bs_MonHoc.DataSource = this.ds_TN_CSDLPT;
            // 
            // ds_TN_CSDLPT
            // 
            this.ds_TN_CSDLPT.DataSetName = "TN_CSDLPTDataSet";
            this.ds_TN_CSDLPT.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbla_MONHOC
            // 
            this.tbla_MONHOC.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.BANGDIEMTableAdapter = null;
            this.tableAdapterManager.BODETableAdapter = null;
            this.tableAdapterManager.COSOTableAdapter = null;
            this.tableAdapterManager.GIAOVIEN_DANGKYTableAdapter = this.tbla_GVDK;
            this.tableAdapterManager.GIAOVIENTableAdapter = null;
            this.tableAdapterManager.KHOATableAdapter = null;
            this.tableAdapterManager.LOPTableAdapter = null;
            this.tableAdapterManager.MONHOCTableAdapter = this.tbla_MONHOC;
            this.tableAdapterManager.SINHVIENTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = TracNghiem_CSDLPT.TN_CSDLPTDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // tbla_GVDK
            // 
            this.tbla_GVDK.ClearBeforeFill = true;
            // 
            // grb_StartExam
            // 
            this.grb_StartExam.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grb_StartExam.Controls.Add(this.btn_Start);
            this.grb_StartExam.Controls.Add(this.dgv_Results);
            this.grb_StartExam.Location = new System.Drawing.Point(3, 246);
            this.grb_StartExam.Name = "grb_StartExam";
            this.grb_StartExam.Size = new System.Drawing.Size(774, 214);
            this.grb_StartExam.TabIndex = 2;
            this.grb_StartExam.TabStop = false;
            // 
            // btn_Start
            // 
            this.btn_Start.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Start.Location = new System.Drawing.Point(261, 143);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(257, 62);
            this.btn_Start.TabIndex = 1;
            this.btn_Start.Text = "Bắt Đầu Thi";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // dgv_Results
            // 
            this.dgv_Results.AllowUserToAddRows = false;
            this.dgv_Results.AllowUserToDeleteRows = false;
            this.dgv_Results.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_Results.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Results.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgv_Results.Location = new System.Drawing.Point(3, 22);
            this.dgv_Results.Name = "dgv_Results";
            this.dgv_Results.ReadOnly = true;
            this.dgv_Results.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Results.Size = new System.Drawing.Size(768, 106);
            this.dgv_Results.TabIndex = 0;
            // 
            // bs_GVDK
            // 
            this.bs_GVDK.DataMember = "GIAOVIEN_DANGKY";
            this.bs_GVDK.DataSource = this.ds_TN_CSDLPT;
            this.bs_GVDK.Sort = "MAMH, NGAYTHI, LAN ";
            // 
            // grb_InfoStudent
            // 
            this.grb_InfoStudent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grb_InfoStudent.Controls.Add(this.lbl_StudentCode);
            this.grb_InfoStudent.Controls.Add(this.lbl_StudentName);
            this.grb_InfoStudent.Controls.Add(this.label10);
            this.grb_InfoStudent.Controls.Add(this.label11);
            this.grb_InfoStudent.Controls.Add(this.lbl_ClassName);
            this.grb_InfoStudent.Controls.Add(this.lbl_ClassCode);
            this.grb_InfoStudent.Controls.Add(this.label5);
            this.grb_InfoStudent.Controls.Add(this.label4);
            this.grb_InfoStudent.Location = new System.Drawing.Point(3, 3);
            this.grb_InfoStudent.Name = "grb_InfoStudent";
            this.grb_InfoStudent.Size = new System.Drawing.Size(774, 109);
            this.grb_InfoStudent.TabIndex = 3;
            this.grb_InfoStudent.TabStop = false;
            this.grb_InfoStudent.Text = "Thông tin sinh viên";
            // 
            // lbl_StudentCode
            // 
            this.lbl_StudentCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_StudentCode.AutoSize = true;
            this.lbl_StudentCode.Location = new System.Drawing.Point(458, 77);
            this.lbl_StudentCode.Name = "lbl_StudentCode";
            this.lbl_StudentCode.Size = new System.Drawing.Size(45, 19);
            this.lbl_StudentCode.TabIndex = 7;
            this.lbl_StudentCode.Text = "label8";
            // 
            // lbl_StudentName
            // 
            this.lbl_StudentName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_StudentName.AutoSize = true;
            this.lbl_StudentName.Location = new System.Drawing.Point(458, 26);
            this.lbl_StudentName.Name = "lbl_StudentName";
            this.lbl_StudentName.Size = new System.Drawing.Size(45, 19);
            this.lbl_StudentName.TabIndex = 6;
            this.lbl_StudentName.Text = "label9";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(377, 77);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 19);
            this.label10.TabIndex = 5;
            this.label10.Text = "Ma SV:";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(377, 26);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 19);
            this.label11.TabIndex = 4;
            this.label11.Text = "Tên SV:";
            // 
            // lbl_ClassName
            // 
            this.lbl_ClassName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_ClassName.AutoSize = true;
            this.lbl_ClassName.Location = new System.Drawing.Point(109, 77);
            this.lbl_ClassName.Name = "lbl_ClassName";
            this.lbl_ClassName.Size = new System.Drawing.Size(45, 19);
            this.lbl_ClassName.TabIndex = 3;
            this.lbl_ClassName.Text = "label6";
            // 
            // lbl_ClassCode
            // 
            this.lbl_ClassCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_ClassCode.AutoSize = true;
            this.lbl_ClassCode.Location = new System.Drawing.Point(109, 26);
            this.lbl_ClassCode.Name = "lbl_ClassCode";
            this.lbl_ClassCode.Size = new System.Drawing.Size(45, 19);
            this.lbl_ClassCode.TabIndex = 2;
            this.lbl_ClassCode.Text = "label7";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 19);
            this.label5.TabIndex = 1;
            this.label5.Text = "Tên lớp:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "Mã lớp:";
            // 
            // cmb_Course
            // 
            this.cmb_Course.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmb_Course.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_Course.DataSource = this.bs_MonHoc;
            this.cmb_Course.DisplayMember = "TENMH";
            this.cmb_Course.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Course.FormattingEnabled = true;
            this.cmb_Course.Location = new System.Drawing.Point(113, 23);
            this.cmb_Course.Name = "cmb_Course";
            this.cmb_Course.Size = new System.Drawing.Size(114, 27);
            this.cmb_Course.TabIndex = 7;
            this.cmb_Course.ValueMember = "MAMH";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.grb_StartExam, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.grb_InfoStudent, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.grb_InfoFind, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.054F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.86177F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.30022F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(780, 463);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // Frm_CBThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 463);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Frm_CBThi";
            this.Text = "Frm_CBThi";
            this.Load += new System.EventHandler(this.Frm_CBThi_Load);
            this.grb_InfoFind.ResumeLayout(false);
            this.grb_InfoFind.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_TimesStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_MonHoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ds_TN_CSDLPT)).EndInit();
            this.grb_StartExam.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Results)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_GVDK)).EndInit();
            this.grb_InfoStudent.ResumeLayout(false);
            this.grb_InfoStudent.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox grb_InfoFind;
        private System.Windows.Forms.NumericUpDown nud_TimesStep;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private TN_CSDLPTDataSet ds_TN_CSDLPT;
        private System.Windows.Forms.BindingSource bs_MonHoc;
        private TN_CSDLPTDataSetTableAdapters.MONHOCTableAdapter tbla_MONHOC;
        private TN_CSDLPTDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DateTimePicker dtp_DateExam;
        private System.Windows.Forms.Button btn_Find;
        private System.Windows.Forms.GroupBox grb_StartExam;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.DataGridView dgv_Results;
        private TN_CSDLPTDataSetTableAdapters.GIAOVIEN_DANGKYTableAdapter tbla_GVDK;
        private System.Windows.Forms.BindingSource bs_GVDK;
        private System.Windows.Forms.GroupBox grb_InfoStudent;
        private System.Windows.Forms.Label lbl_StudentCode;
        private System.Windows.Forms.Label lbl_StudentName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbl_ClassName;
        private System.Windows.Forms.Label lbl_ClassCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmb_Course;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}