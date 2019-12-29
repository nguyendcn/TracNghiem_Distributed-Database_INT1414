namespace TracNghiem_CSDLPT.Account
{
    partial class Frm_ChangePassword
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
            this.lbl_Title = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_OldPassword = new System.Windows.Forms.TextBox();
            this.txt_NewPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_RepeatNewPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_ChagePassword = new System.Windows.Forms.Button();
            this.lbl_Err_Summary = new System.Windows.Forms.Label();
            this.lbl_Err_OldPassword = new System.Windows.Forms.Label();
            this.lbl_Err_NewPassword = new System.Windows.Forms.Label();
            this.lbl_Err_RepeatNewPassword = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_Title
            // 
            this.lbl_Title.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_Title.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Title.Location = new System.Drawing.Point(143, 9);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(154, 22);
            this.lbl_Title.TabIndex = 0;
            this.lbl_Title.Text = "ĐỔI MẬT KHẨU";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mật khẩu cũ:";
            // 
            // txt_OldPassword
            // 
            this.txt_OldPassword.Location = new System.Drawing.Point(120, 33);
            this.txt_OldPassword.Name = "txt_OldPassword";
            this.txt_OldPassword.PasswordChar = '*';
            this.txt_OldPassword.Size = new System.Drawing.Size(243, 26);
            this.txt_OldPassword.TabIndex = 2;
            // 
            // txt_NewPassword
            // 
            this.txt_NewPassword.Location = new System.Drawing.Point(120, 124);
            this.txt_NewPassword.Name = "txt_NewPassword";
            this.txt_NewPassword.PasswordChar = '*';
            this.txt_NewPassword.Size = new System.Drawing.Size(243, 26);
            this.txt_NewPassword.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 38);
            this.label3.TabIndex = 3;
            this.label3.Text = "Mật khẩu mới";
            // 
            // txt_RepeatNewPassword
            // 
            this.txt_RepeatNewPassword.Location = new System.Drawing.Point(120, 215);
            this.txt_RepeatNewPassword.Name = "txt_RepeatNewPassword";
            this.txt_RepeatNewPassword.PasswordChar = '*';
            this.txt_RepeatNewPassword.Size = new System.Drawing.Size(243, 26);
            this.txt_RepeatNewPassword.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 38);
            this.label4.TabIndex = 5;
            this.label4.Text = "Nhập lại mật khẩu mới";
            // 
            // btn_ChagePassword
            // 
            this.btn_ChagePassword.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ChagePassword.Location = new System.Drawing.Point(101, 30);
            this.btn_ChagePassword.Name = "btn_ChagePassword";
            this.btn_ChagePassword.Size = new System.Drawing.Size(165, 60);
            this.btn_ChagePassword.TabIndex = 7;
            this.btn_ChagePassword.Text = "Đổi Mật Khẩu";
            this.btn_ChagePassword.UseVisualStyleBackColor = true;
            this.btn_ChagePassword.Click += new System.EventHandler(this.btn_ChagePassword_Click);
            // 
            // lbl_Err_Summary
            // 
            this.lbl_Err_Summary.AutoSize = true;
            this.lbl_Err_Summary.ForeColor = System.Drawing.Color.Red;
            this.lbl_Err_Summary.Location = new System.Drawing.Point(54, 5);
            this.lbl_Err_Summary.Name = "lbl_Err_Summary";
            this.lbl_Err_Summary.Size = new System.Drawing.Size(45, 19);
            this.lbl_Err_Summary.TabIndex = 8;
            this.lbl_Err_Summary.Text = "label5";
            // 
            // lbl_Err_OldPassword
            // 
            this.lbl_Err_OldPassword.AutoSize = true;
            this.lbl_Err_OldPassword.ForeColor = System.Drawing.Color.Red;
            this.lbl_Err_OldPassword.Location = new System.Drawing.Point(120, 6);
            this.lbl_Err_OldPassword.Name = "lbl_Err_OldPassword";
            this.lbl_Err_OldPassword.Size = new System.Drawing.Size(45, 19);
            this.lbl_Err_OldPassword.TabIndex = 9;
            this.lbl_Err_OldPassword.Text = "label6";
            // 
            // lbl_Err_NewPassword
            // 
            this.lbl_Err_NewPassword.AutoSize = true;
            this.lbl_Err_NewPassword.ForeColor = System.Drawing.Color.Red;
            this.lbl_Err_NewPassword.Location = new System.Drawing.Point(120, 97);
            this.lbl_Err_NewPassword.Name = "lbl_Err_NewPassword";
            this.lbl_Err_NewPassword.Size = new System.Drawing.Size(45, 19);
            this.lbl_Err_NewPassword.TabIndex = 10;
            this.lbl_Err_NewPassword.Text = "label7";
            // 
            // lbl_Err_RepeatNewPassword
            // 
            this.lbl_Err_RepeatNewPassword.AutoSize = true;
            this.lbl_Err_RepeatNewPassword.ForeColor = System.Drawing.Color.Red;
            this.lbl_Err_RepeatNewPassword.Location = new System.Drawing.Point(120, 188);
            this.lbl_Err_RepeatNewPassword.Name = "lbl_Err_RepeatNewPassword";
            this.lbl_Err_RepeatNewPassword.Size = new System.Drawing.Size(45, 19);
            this.lbl_Err_RepeatNewPassword.TabIndex = 11;
            this.lbl_Err_RepeatNewPassword.Text = "label8";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 96F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 48);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.423581F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 62.00873F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.41921F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(409, 458);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.tableLayoutPanel2.Controls.Add(this.txt_RepeatNewPassword, 4, 8);
            this.tableLayoutPanel2.Controls.Add(this.lbl_Err_RepeatNewPassword, 4, 7);
            this.tableLayoutPanel2.Controls.Add(this.label4, 1, 8);
            this.tableLayoutPanel2.Controls.Add(this.lbl_Err_NewPassword, 4, 4);
            this.tableLayoutPanel2.Controls.Add(this.label3, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.lbl_Err_OldPassword, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.txt_NewPassword, 4, 5);
            this.tableLayoutPanel2.Controls.Add(this.txt_OldPassword, 4, 2);
            this.tableLayoutPanel2.Controls.Add(this.label2, 1, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(11, 46);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 9;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.222222F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.888889F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.222222F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.888889F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.222222F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.888889F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(386, 278);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_ChagePassword);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(11, 330);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(386, 115);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbl_Err_Summary);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(11, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(386, 28);
            this.panel2.TabIndex = 2;
            // 
            // Frm_ChangePassword
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 504);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.lbl_Title);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Frm_ChangePassword";
            this.Text = "Frm_ChangePassword";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_OldPassword;
        private System.Windows.Forms.TextBox txt_NewPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_RepeatNewPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_ChagePassword;
        private System.Windows.Forms.Label lbl_Err_Summary;
        private System.Windows.Forms.Label lbl_Err_OldPassword;
        private System.Windows.Forms.Label lbl_Err_NewPassword;
        private System.Windows.Forms.Label lbl_Err_RepeatNewPassword;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}