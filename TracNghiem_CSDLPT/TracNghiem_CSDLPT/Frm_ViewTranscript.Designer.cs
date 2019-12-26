namespace TracNghiem_CSDLPT
{
    partial class Frm_ViewTranscript
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tlp_Transcript = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgv_Transcript = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_ClassName = new System.Windows.Forms.Label();
            this.lbl_CourseName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_TimesStep = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.TN_CSDLPT = new TracNghiem_CSDLPT.TN_CSDLPTDataSet();
            this.bs_LOP = new System.Windows.Forms.BindingSource(this.components);
            this.tbla_LOP = new TracNghiem_CSDLPT.TN_CSDLPTDataSetTableAdapters.LOPTableAdapter();
            this.tableAdapterManager = new TracNghiem_CSDLPT.TN_CSDLPTDataSetTableAdapters.TableAdapterManager();
            this.bs_MONHOC = new System.Windows.Forms.BindingSource(this.components);
            this.tbla_MONHOC = new TracNghiem_CSDLPT.TN_CSDLPTDataSetTableAdapters.MONHOCTableAdapter();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_View = new System.Windows.Forms.Button();
            this.nud_TimesStep = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.cmb_Course = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmb_Class = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.grb_Tool = new System.Windows.Forms.GroupBox();
            this.btn_PrintTranscript = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tlp_Transcript.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Transcript)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TN_CSDLPT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_LOP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_MONHOC)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_TimesStep)).BeginInit();
            this.grb_Tool.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tlp_Transcript);
            this.splitContainer1.Size = new System.Drawing.Size(885, 536);
            this.splitContainer1.SplitterDistance = 313;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grb_Tool);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(313, 536);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // tlp_Transcript
            // 
            this.tlp_Transcript.ColumnCount = 3;
            this.tlp_Transcript.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.tlp_Transcript.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 96F));
            this.tlp_Transcript.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.tlp_Transcript.Controls.Add(this.panel1, 1, 1);
            this.tlp_Transcript.Controls.Add(this.dgv_Transcript, 1, 2);
            this.tlp_Transcript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Transcript.Location = new System.Drawing.Point(0, 0);
            this.tlp_Transcript.Name = "tlp_Transcript";
            this.tlp_Transcript.RowCount = 4;
            this.tlp_Transcript.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.tlp_Transcript.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlp_Transcript.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 76F));
            this.tlp_Transcript.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.tlp_Transcript.Size = new System.Drawing.Size(566, 536);
            this.tlp_Transcript.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl_TimesStep);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.lbl_CourseName);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lbl_ClassName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(14, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(537, 101);
            this.panel1.TabIndex = 0;
            // 
            // dgv_Transcript
            // 
            this.dgv_Transcript.AllowUserToAddRows = false;
            this.dgv_Transcript.AllowUserToDeleteRows = false;
            this.dgv_Transcript.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Transcript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Transcript.Location = new System.Drawing.Point(14, 120);
            this.dgv_Transcript.Name = "dgv_Transcript";
            this.dgv_Transcript.ReadOnly = true;
            this.dgv_Transcript.Size = new System.Drawing.Size(537, 401);
            this.dgv_Transcript.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(209, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "BẢNG ĐIỂM";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên lớp:";
            // 
            // lbl_ClassName
            // 
            this.lbl_ClassName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_ClassName.AutoSize = true;
            this.lbl_ClassName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ClassName.Location = new System.Drawing.Point(95, 60);
            this.lbl_ClassName.Name = "lbl_ClassName";
            this.lbl_ClassName.Size = new System.Drawing.Size(49, 19);
            this.lbl_ClassName.TabIndex = 2;
            this.lbl_ClassName.Text = "label3";
            // 
            // lbl_CourseName
            // 
            this.lbl_CourseName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_CourseName.AutoSize = true;
            this.lbl_CourseName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CourseName.Location = new System.Drawing.Point(266, 60);
            this.lbl_CourseName.Name = "lbl_CourseName";
            this.lbl_CourseName.Size = new System.Drawing.Size(49, 19);
            this.lbl_CourseName.TabIndex = 4;
            this.lbl_CourseName.Text = "label4";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(198, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 19);
            this.label5.TabIndex = 3;
            this.label5.Text = "Tên môn:";
            // 
            // lbl_TimesStep
            // 
            this.lbl_TimesStep.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_TimesStep.AutoSize = true;
            this.lbl_TimesStep.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TimesStep.Location = new System.Drawing.Point(433, 60);
            this.lbl_TimesStep.Name = "lbl_TimesStep";
            this.lbl_TimesStep.Size = new System.Drawing.Size(49, 19);
            this.lbl_TimesStep.TabIndex = 6;
            this.lbl_TimesStep.Text = "label6";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(370, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 19);
            this.label7.TabIndex = 5;
            this.label7.Text = "Lần thi:";
            // 
            // TN_CSDLPT
            // 
            this.TN_CSDLPT.DataSetName = "TN_CSDLPTDataSet";
            this.TN_CSDLPT.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bs_LOP
            // 
            this.bs_LOP.DataMember = "LOP";
            this.bs_LOP.DataSource = this.TN_CSDLPT;
            // 
            // tbla_LOP
            // 
            this.tbla_LOP.ClearBeforeFill = true;
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
            this.tableAdapterManager.LOPTableAdapter = this.tbla_LOP;
            this.tableAdapterManager.MONHOCTableAdapter = this.tbla_MONHOC;
            this.tableAdapterManager.SINHVIENTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = TracNghiem_CSDLPT.TN_CSDLPTDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // bs_MONHOC
            // 
            this.bs_MONHOC.DataMember = "MONHOC";
            this.bs_MONHOC.DataSource = this.TN_CSDLPT;
            // 
            // tbla_MONHOC
            // 
            this.tbla_MONHOC.ClearBeforeFill = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox2.Controls.Add(this.btn_View);
            this.groupBox2.Controls.Add(this.nud_TimesStep);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cmb_Course);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cmb_Class);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(295, 254);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin bảng điểm";
            // 
            // btn_View
            // 
            this.btn_View.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_View.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_View.Location = new System.Drawing.Point(84, 201);
            this.btn_View.Name = "btn_View";
            this.btn_View.Size = new System.Drawing.Size(123, 46);
            this.btn_View.TabIndex = 13;
            this.btn_View.Text = "Xem";
            this.btn_View.UseVisualStyleBackColor = true;
            // 
            // nud_TimesStep
            // 
            this.nud_TimesStep.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.nud_TimesStep.Location = new System.Drawing.Point(109, 151);
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
            this.nud_TimesStep.Size = new System.Drawing.Size(55, 26);
            this.nud_TimesStep.TabIndex = 12;
            this.nud_TimesStep.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(39, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 19);
            this.label6.TabIndex = 11;
            this.label6.Text = "Lần thi";
            // 
            // cmb_Course
            // 
            this.cmb_Course.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmb_Course.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmb_Course.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_Course.DataSource = this.bs_MONHOC;
            this.cmb_Course.DisplayMember = "TENMH";
            this.cmb_Course.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Course.FormattingEnabled = true;
            this.cmb_Course.Location = new System.Drawing.Point(109, 95);
            this.cmb_Course.Name = "cmb_Course";
            this.cmb_Course.Size = new System.Drawing.Size(166, 27);
            this.cmb_Course.TabIndex = 10;
            this.cmb_Course.ValueMember = "MAMH";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 19);
            this.label4.TabIndex = 9;
            this.label4.Text = "Môn thi";
            // 
            // cmb_Class
            // 
            this.cmb_Class.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmb_Class.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmb_Class.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_Class.DataSource = this.bs_LOP;
            this.cmb_Class.DisplayMember = "TENLOP";
            this.cmb_Class.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Class.FormattingEnabled = true;
            this.cmb_Class.Location = new System.Drawing.Point(109, 40);
            this.cmb_Class.Name = "cmb_Class";
            this.cmb_Class.Size = new System.Drawing.Size(166, 27);
            this.cmb_Class.TabIndex = 8;
            this.cmb_Class.ValueMember = "TENLOP";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 19);
            this.label3.TabIndex = 7;
            this.label3.Text = "Lớp:";
            // 
            // grb_Tool
            // 
            this.grb_Tool.Controls.Add(this.btn_PrintTranscript);
            this.grb_Tool.Location = new System.Drawing.Point(13, 308);
            this.grb_Tool.Name = "grb_Tool";
            this.grb_Tool.Size = new System.Drawing.Size(294, 158);
            this.grb_Tool.TabIndex = 1;
            this.grb_Tool.TabStop = false;
            this.grb_Tool.Text = "Công cụ";
            // 
            // btn_PrintTranscript
            // 
            this.btn_PrintTranscript.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_PrintTranscript.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_PrintTranscript.Location = new System.Drawing.Point(83, 47);
            this.btn_PrintTranscript.Name = "btn_PrintTranscript";
            this.btn_PrintTranscript.Size = new System.Drawing.Size(123, 46);
            this.btn_PrintTranscript.TabIndex = 14;
            this.btn_PrintTranscript.Text = "In Bảng Điểm";
            this.btn_PrintTranscript.UseVisualStyleBackColor = true;
            // 
            // Frm_ViewTranscript
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 536);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Frm_ViewTranscript";
            this.Text = "Frm_ViewTranscript";
            this.Load += new System.EventHandler(this.Frm_ViewTranscript_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tlp_Transcript.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Transcript)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TN_CSDLPT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_LOP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_MONHOC)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_TimesStep)).EndInit();
            this.grb_Tool.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tlp_Transcript;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_TimesStep;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_CourseName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_ClassName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_Transcript;
        private TN_CSDLPTDataSet TN_CSDLPT;
        private System.Windows.Forms.BindingSource bs_LOP;
        private TN_CSDLPTDataSetTableAdapters.LOPTableAdapter tbla_LOP;
        private TN_CSDLPTDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private TN_CSDLPTDataSetTableAdapters.MONHOCTableAdapter tbla_MONHOC;
        private System.Windows.Forms.BindingSource bs_MONHOC;
        private System.Windows.Forms.GroupBox grb_Tool;
        private System.Windows.Forms.Button btn_PrintTranscript;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_View;
        private System.Windows.Forms.NumericUpDown nud_TimesStep;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmb_Course;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmb_Class;
        private System.Windows.Forms.Label label3;
    }
}