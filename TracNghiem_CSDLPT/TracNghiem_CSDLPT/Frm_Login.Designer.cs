namespace TracNghiem_CSDLPT
{
    partial class Frm_Login
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnl_GV = new System.Windows.Forms.Panel();
            this.lbl_Error_GV = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_UserName = new System.Windows.Forms.TextBox();
            this.btn_Login_GV = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmb_Brand_GV = new System.Windows.Forms.ComboBox();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.pnl_SV = new System.Windows.Forms.Panel();
            this.lbl_Error_SV = new System.Windows.Forms.Label();
            this.btn_Login_SV = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_Brand_SV = new System.Windows.Forms.ComboBox();
            this.txt_StudentCode = new System.Windows.Forms.TextBox();
            this.btn_SV = new System.Windows.Forms.Button();
            this.btn_GV = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.pnl_GV.SuspendLayout();
            this.pnl_SV.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pnl_GV);
            this.panel1.Controls.Add(this.pnl_SV);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 97);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(497, 482);
            this.panel1.TabIndex = 0;
            // 
            // pnl_GV
            // 
            this.pnl_GV.BackColor = System.Drawing.Color.SandyBrown;
            this.pnl_GV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_GV.Controls.Add(this.lbl_Error_GV);
            this.pnl_GV.Controls.Add(this.label5);
            this.pnl_GV.Controls.Add(this.txt_UserName);
            this.pnl_GV.Controls.Add(this.btn_Login_GV);
            this.pnl_GV.Controls.Add(this.label3);
            this.pnl_GV.Controls.Add(this.label4);
            this.pnl_GV.Controls.Add(this.cmb_Brand_GV);
            this.pnl_GV.Controls.Add(this.txt_Password);
            this.pnl_GV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_GV.Location = new System.Drawing.Point(0, 0);
            this.pnl_GV.Name = "pnl_GV";
            this.pnl_GV.Size = new System.Drawing.Size(495, 480);
            this.pnl_GV.TabIndex = 0;
            this.pnl_GV.Visible = false;
            // 
            // lbl_Error_GV
            // 
            this.lbl_Error_GV.AutoSize = true;
            this.lbl_Error_GV.ForeColor = System.Drawing.Color.DarkRed;
            this.lbl_Error_GV.Location = new System.Drawing.Point(119, 55);
            this.lbl_Error_GV.Name = "lbl_Error_GV";
            this.lbl_Error_GV.Size = new System.Drawing.Size(40, 15);
            this.lbl_Error_GV.TabIndex = 12;
            this.lbl_Error_GV.Text = "label6";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(78, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 22);
            this.label5.TabIndex = 11;
            this.label5.Text = "Tên Đăng Nhập:";
            // 
            // txt_UserName
            // 
            this.txt_UserName.BackColor = System.Drawing.Color.SandyBrown;
            this.txt_UserName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_UserName.Location = new System.Drawing.Point(235, 174);
            this.txt_UserName.Name = "txt_UserName";
            this.txt_UserName.Size = new System.Drawing.Size(180, 26);
            this.txt_UserName.TabIndex = 10;
            // 
            // btn_Login_GV
            // 
            this.btn_Login_GV.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Login_GV.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Login_GV.Location = new System.Drawing.Point(165, 308);
            this.btn_Login_GV.Name = "btn_Login_GV";
            this.btn_Login_GV.Size = new System.Drawing.Size(139, 61);
            this.btn_Login_GV.TabIndex = 9;
            this.btn_Login_GV.Text = "Đăng Nhập";
            this.btn_Login_GV.UseVisualStyleBackColor = true;
            this.btn_Login_GV.Click += new System.EventHandler(this.btn_Login_GV_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(78, 230);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 22);
            this.label3.TabIndex = 8;
            this.label3.Text = "Mật Khẩu:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(78, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 22);
            this.label4.TabIndex = 7;
            this.label4.Text = "Cơ Sở: ";
            // 
            // cmb_Brand_GV
            // 
            this.cmb_Brand_GV.BackColor = System.Drawing.Color.SandyBrown;
            this.cmb_Brand_GV.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Brand_GV.FormattingEnabled = true;
            this.cmb_Brand_GV.Location = new System.Drawing.Point(235, 116);
            this.cmb_Brand_GV.Name = "cmb_Brand_GV";
            this.cmb_Brand_GV.Size = new System.Drawing.Size(180, 27);
            this.cmb_Brand_GV.TabIndex = 6;
            this.cmb_Brand_GV.Text = "Chọn cơ sở";
            this.cmb_Brand_GV.SelectedIndexChanged += new System.EventHandler(this.cmb_Brand_GV_SelectedIndexChanged);
            // 
            // txt_Password
            // 
            this.txt_Password.BackColor = System.Drawing.Color.SandyBrown;
            this.txt_Password.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Password.Location = new System.Drawing.Point(235, 230);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.Size = new System.Drawing.Size(180, 26);
            this.txt_Password.TabIndex = 5;
            // 
            // pnl_SV
            // 
            this.pnl_SV.BackColor = System.Drawing.Color.SandyBrown;
            this.pnl_SV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl_SV.Controls.Add(this.lbl_Error_SV);
            this.pnl_SV.Controls.Add(this.btn_Login_SV);
            this.pnl_SV.Controls.Add(this.label2);
            this.pnl_SV.Controls.Add(this.label1);
            this.pnl_SV.Controls.Add(this.cmb_Brand_SV);
            this.pnl_SV.Controls.Add(this.txt_StudentCode);
            this.pnl_SV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_SV.Location = new System.Drawing.Point(0, 0);
            this.pnl_SV.Name = "pnl_SV";
            this.pnl_SV.Size = new System.Drawing.Size(495, 480);
            this.pnl_SV.TabIndex = 1;
            // 
            // lbl_Error_SV
            // 
            this.lbl_Error_SV.AutoSize = true;
            this.lbl_Error_SV.ForeColor = System.Drawing.Color.DarkRed;
            this.lbl_Error_SV.Location = new System.Drawing.Point(135, 54);
            this.lbl_Error_SV.Name = "lbl_Error_SV";
            this.lbl_Error_SV.Size = new System.Drawing.Size(40, 15);
            this.lbl_Error_SV.TabIndex = 5;
            this.lbl_Error_SV.Text = "label6";
            // 
            // btn_Login_SV
            // 
            this.btn_Login_SV.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Login_SV.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Login_SV.Location = new System.Drawing.Point(173, 310);
            this.btn_Login_SV.Name = "btn_Login_SV";
            this.btn_Login_SV.Size = new System.Drawing.Size(139, 61);
            this.btn_Login_SV.TabIndex = 4;
            this.btn_Login_SV.Text = "Đăng Nhập";
            this.btn_Login_SV.UseVisualStyleBackColor = true;
            this.btn_Login_SV.Click += new System.EventHandler(this.btn_Login_SV_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(86, 226);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mã Sinh Viên: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(86, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cơ Sở: ";
            // 
            // cmb_Brand_SV
            // 
            this.cmb_Brand_SV.BackColor = System.Drawing.Color.SandyBrown;
            this.cmb_Brand_SV.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Brand_SV.FormattingEnabled = true;
            this.cmb_Brand_SV.Location = new System.Drawing.Point(243, 125);
            this.cmb_Brand_SV.Name = "cmb_Brand_SV";
            this.cmb_Brand_SV.Size = new System.Drawing.Size(180, 27);
            this.cmb_Brand_SV.TabIndex = 1;
            this.cmb_Brand_SV.SelectedIndexChanged += new System.EventHandler(this.cmb_Brand_SV_SelectedIndexChanged);
            // 
            // txt_StudentCode
            // 
            this.txt_StudentCode.BackColor = System.Drawing.Color.SandyBrown;
            this.txt_StudentCode.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_StudentCode.Location = new System.Drawing.Point(243, 226);
            this.txt_StudentCode.Name = "txt_StudentCode";
            this.txt_StudentCode.Size = new System.Drawing.Size(180, 26);
            this.txt_StudentCode.TabIndex = 0;
            // 
            // btn_SV
            // 
            this.btn_SV.BackColor = System.Drawing.Color.SandyBrown;
            this.btn_SV.FlatAppearance.BorderSize = 0;
            this.btn_SV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SV.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SV.Location = new System.Drawing.Point(0, 0);
            this.btn_SV.Name = "btn_SV";
            this.btn_SV.Size = new System.Drawing.Size(252, 102);
            this.btn_SV.TabIndex = 1;
            this.btn_SV.Text = "Sinh Viên";
            this.btn_SV.UseVisualStyleBackColor = false;
            this.btn_SV.Click += new System.EventHandler(this.btn_SV_Click);
            // 
            // btn_GV
            // 
            this.btn_GV.BackColor = System.Drawing.Color.PeachPuff;
            this.btn_GV.FlatAppearance.BorderSize = 0;
            this.btn_GV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_GV.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_GV.Location = new System.Drawing.Point(250, 0);
            this.btn_GV.Name = "btn_GV";
            this.btn_GV.Size = new System.Drawing.Size(248, 102);
            this.btn_GV.TabIndex = 2;
            this.btn_GV.Text = "Giáo Viên";
            this.btn_GV.UseVisualStyleBackColor = false;
            this.btn_GV.Click += new System.EventHandler(this.btn_GV_Click);
            // 
            // Frm_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 579);
            this.Controls.Add(this.btn_GV);
            this.Controls.Add(this.btn_SV);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Frm_Login";
            this.Text = "Đăng Nhập";
            this.panel1.ResumeLayout(false);
            this.pnl_GV.ResumeLayout(false);
            this.pnl_GV.PerformLayout();
            this.pnl_SV.ResumeLayout(false);
            this.pnl_SV.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnl_SV;
        private System.Windows.Forms.Panel pnl_GV;
        private System.Windows.Forms.Button btn_SV;
        private System.Windows.Forms.Button btn_GV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_Brand_SV;
        private System.Windows.Forms.TextBox txt_StudentCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_UserName;
        private System.Windows.Forms.Button btn_Login_GV;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmb_Brand_GV;
        private System.Windows.Forms.TextBox txt_Password;
        private System.Windows.Forms.Button btn_Login_SV;
        private System.Windows.Forms.Label lbl_Error_SV;
        private System.Windows.Forms.Label lbl_Error_GV;
    }
}