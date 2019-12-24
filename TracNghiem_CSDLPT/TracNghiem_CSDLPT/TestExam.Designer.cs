namespace TracNghiem_CSDLPT
{
    partial class TestExam
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_Question = new System.Windows.Forms.Label();
            this.btn_Next = new System.Windows.Forms.Button();
            this.btn_Submit = new System.Windows.Forms.Button();
            this.btn_Previous = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdb_D = new System.Windows.Forms.RadioButton();
            this.rdb_B = new System.Windows.Forms.RadioButton();
            this.rdb_C = new System.Windows.Forms.RadioButton();
            this.rdb_A = new System.Windows.Forms.RadioButton();
            this.txt_D = new System.Windows.Forms.TextBox();
            this.txt_C = new System.Windows.Forms.TextBox();
            this.txt_B = new System.Windows.Forms.TextBox();
            this.txt_A = new System.Windows.Forms.TextBox();
            this.txt_QuestionContent = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_CountDown = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.219178F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.78082F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(705, 464);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl_Question);
            this.panel1.Controls.Add(this.btn_Next);
            this.panel1.Controls.Add(this.btn_Submit);
            this.panel1.Controls.Add(this.btn_Previous);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.txt_QuestionContent);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(699, 396);
            this.panel1.TabIndex = 0;
            // 
            // lbl_Question
            // 
            this.lbl_Question.AutoSize = true;
            this.lbl_Question.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Question.Location = new System.Drawing.Point(319, 3);
            this.lbl_Question.Name = "lbl_Question";
            this.lbl_Question.Size = new System.Drawing.Size(60, 19);
            this.lbl_Question.TabIndex = 5;
            this.lbl_Question.Text = "Câu hỏi";
            // 
            // btn_Next
            // 
            this.btn_Next.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Next.Location = new System.Drawing.Point(450, 355);
            this.btn_Next.Name = "btn_Next";
            this.btn_Next.Size = new System.Drawing.Size(85, 38);
            this.btn_Next.TabIndex = 4;
            this.btn_Next.Text = "Câu tiếp";
            this.btn_Next.UseVisualStyleBackColor = true;
            this.btn_Next.Click += new System.EventHandler(this.btn_Next_Click);
            // 
            // btn_Submit
            // 
            this.btn_Submit.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Submit.Location = new System.Drawing.Point(308, 355);
            this.btn_Submit.Name = "btn_Submit";
            this.btn_Submit.Size = new System.Drawing.Size(85, 38);
            this.btn_Submit.TabIndex = 3;
            this.btn_Submit.Text = "Nộp bài";
            this.btn_Submit.UseVisualStyleBackColor = true;
            this.btn_Submit.Click += new System.EventHandler(this.btn_Submit_Click);
            // 
            // btn_Previous
            // 
            this.btn_Previous.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Previous.Location = new System.Drawing.Point(166, 355);
            this.btn_Previous.Name = "btn_Previous";
            this.btn_Previous.Size = new System.Drawing.Size(85, 38);
            this.btn_Previous.TabIndex = 2;
            this.btn_Previous.Text = "Câu trước";
            this.btn_Previous.UseVisualStyleBackColor = true;
            this.btn_Previous.Click += new System.EventHandler(this.btn_Previous_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdb_D);
            this.groupBox1.Controls.Add(this.rdb_B);
            this.groupBox1.Controls.Add(this.rdb_C);
            this.groupBox1.Controls.Add(this.rdb_A);
            this.groupBox1.Controls.Add(this.txt_D);
            this.groupBox1.Controls.Add(this.txt_C);
            this.groupBox1.Controls.Add(this.txt_B);
            this.groupBox1.Controls.Add(this.txt_A);
            this.groupBox1.Location = new System.Drawing.Point(44, 195);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(604, 154);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // rdb_D
            // 
            this.rdb_D.AutoSize = true;
            this.rdb_D.Location = new System.Drawing.Point(376, 109);
            this.rdb_D.Name = "rdb_D";
            this.rdb_D.Size = new System.Drawing.Size(14, 13);
            this.rdb_D.TabIndex = 6;
            this.rdb_D.TabStop = true;
            this.rdb_D.UseVisualStyleBackColor = true;
            // 
            // rdb_B
            // 
            this.rdb_B.AutoSize = true;
            this.rdb_B.Location = new System.Drawing.Point(376, 47);
            this.rdb_B.Name = "rdb_B";
            this.rdb_B.Size = new System.Drawing.Size(14, 13);
            this.rdb_B.TabIndex = 5;
            this.rdb_B.TabStop = true;
            this.rdb_B.UseVisualStyleBackColor = true;
            // 
            // rdb_C
            // 
            this.rdb_C.AutoSize = true;
            this.rdb_C.Location = new System.Drawing.Point(43, 109);
            this.rdb_C.Name = "rdb_C";
            this.rdb_C.Size = new System.Drawing.Size(14, 13);
            this.rdb_C.TabIndex = 5;
            this.rdb_C.TabStop = true;
            this.rdb_C.UseVisualStyleBackColor = true;
            // 
            // rdb_A
            // 
            this.rdb_A.AutoSize = true;
            this.rdb_A.Location = new System.Drawing.Point(43, 46);
            this.rdb_A.Name = "rdb_A";
            this.rdb_A.Size = new System.Drawing.Size(14, 13);
            this.rdb_A.TabIndex = 4;
            this.rdb_A.TabStop = true;
            this.rdb_A.UseVisualStyleBackColor = true;
            // 
            // txt_D
            // 
            this.txt_D.Location = new System.Drawing.Point(406, 97);
            this.txt_D.Multiline = true;
            this.txt_D.Name = "txt_D";
            this.txt_D.Size = new System.Drawing.Size(179, 41);
            this.txt_D.TabIndex = 3;
            // 
            // txt_C
            // 
            this.txt_C.Location = new System.Drawing.Point(66, 97);
            this.txt_C.Multiline = true;
            this.txt_C.Name = "txt_C";
            this.txt_C.Size = new System.Drawing.Size(179, 41);
            this.txt_C.TabIndex = 2;
            // 
            // txt_B
            // 
            this.txt_B.Location = new System.Drawing.Point(406, 33);
            this.txt_B.Multiline = true;
            this.txt_B.Name = "txt_B";
            this.txt_B.Size = new System.Drawing.Size(179, 41);
            this.txt_B.TabIndex = 1;
            // 
            // txt_A
            // 
            this.txt_A.Location = new System.Drawing.Point(66, 33);
            this.txt_A.Multiline = true;
            this.txt_A.Name = "txt_A";
            this.txt_A.Size = new System.Drawing.Size(179, 41);
            this.txt_A.TabIndex = 0;
            // 
            // txt_QuestionContent
            // 
            this.txt_QuestionContent.Location = new System.Drawing.Point(122, 25);
            this.txt_QuestionContent.Multiline = true;
            this.txt_QuestionContent.Name = "txt_QuestionContent";
            this.txt_QuestionContent.Size = new System.Drawing.Size(461, 164);
            this.txt_QuestionContent.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbl_CountDown);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(699, 30);
            this.panel2.TabIndex = 1;
            // 
            // lbl_CountDown
            // 
            this.lbl_CountDown.AutoSize = true;
            this.lbl_CountDown.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CountDown.Location = new System.Drawing.Point(341, 6);
            this.lbl_CountDown.Name = "lbl_CountDown";
            this.lbl_CountDown.Size = new System.Drawing.Size(38, 19);
            this.lbl_CountDown.TabIndex = 7;
            this.lbl_CountDown.Text = "1:30";
            // 
            // TestExam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 464);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TestExam";
            this.Text = "TestExam";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_Question;
        private System.Windows.Forms.Button btn_Next;
        private System.Windows.Forms.Button btn_Submit;
        private System.Windows.Forms.Button btn_Previous;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdb_D;
        private System.Windows.Forms.RadioButton rdb_B;
        private System.Windows.Forms.RadioButton rdb_C;
        private System.Windows.Forms.RadioButton rdb_A;
        private System.Windows.Forms.TextBox txt_D;
        private System.Windows.Forms.TextBox txt_C;
        private System.Windows.Forms.TextBox txt_B;
        private System.Windows.Forms.TextBox txt_A;
        private System.Windows.Forms.TextBox txt_QuestionContent;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_CountDown;
    }
}