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
            this.SuspendLayout();
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_Title.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Title.Location = new System.Drawing.Point(126, 23);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(146, 22);
            this.lbl_Title.TabIndex = 0;
            this.lbl_Title.Text = "Sample text here";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mật khẩu cũ:";
            // 
            // txt_OldPassword
            // 
            this.txt_OldPassword.Location = new System.Drawing.Point(178, 177);
            this.txt_OldPassword.Name = "txt_OldPassword";
            this.txt_OldPassword.PasswordChar = '*';
            this.txt_OldPassword.Size = new System.Drawing.Size(166, 26);
            this.txt_OldPassword.TabIndex = 2;
            // 
            // txt_NewPassword
            // 
            this.txt_NewPassword.Location = new System.Drawing.Point(178, 239);
            this.txt_NewPassword.Name = "txt_NewPassword";
            this.txt_NewPassword.PasswordChar = '*';
            this.txt_NewPassword.Size = new System.Drawing.Size(166, 26);
            this.txt_NewPassword.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 239);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Mật khẩu mới";
            // 
            // txt_RepeatNewPassword
            // 
            this.txt_RepeatNewPassword.Location = new System.Drawing.Point(178, 291);
            this.txt_RepeatNewPassword.Name = "txt_RepeatNewPassword";
            this.txt_RepeatNewPassword.PasswordChar = '*';
            this.txt_RepeatNewPassword.Size = new System.Drawing.Size(166, 26);
            this.txt_RepeatNewPassword.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 291);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 19);
            this.label4.TabIndex = 5;
            this.label4.Text = "Nhập lại mật khẩu mới";
            // 
            // btn_ChagePassword
            // 
            this.btn_ChagePassword.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ChagePassword.Location = new System.Drawing.Point(130, 377);
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
            this.lbl_Err_Summary.Location = new System.Drawing.Point(74, 101);
            this.lbl_Err_Summary.Name = "lbl_Err_Summary";
            this.lbl_Err_Summary.Size = new System.Drawing.Size(45, 19);
            this.lbl_Err_Summary.TabIndex = 8;
            this.lbl_Err_Summary.Text = "label5";
            // 
            // lbl_Err_OldPassword
            // 
            this.lbl_Err_OldPassword.AutoSize = true;
            this.lbl_Err_OldPassword.ForeColor = System.Drawing.Color.Red;
            this.lbl_Err_OldPassword.Location = new System.Drawing.Point(174, 151);
            this.lbl_Err_OldPassword.Name = "lbl_Err_OldPassword";
            this.lbl_Err_OldPassword.Size = new System.Drawing.Size(45, 19);
            this.lbl_Err_OldPassword.TabIndex = 9;
            this.lbl_Err_OldPassword.Text = "label6";
            // 
            // lbl_Err_NewPassword
            // 
            this.lbl_Err_NewPassword.AutoSize = true;
            this.lbl_Err_NewPassword.ForeColor = System.Drawing.Color.Red;
            this.lbl_Err_NewPassword.Location = new System.Drawing.Point(174, 217);
            this.lbl_Err_NewPassword.Name = "lbl_Err_NewPassword";
            this.lbl_Err_NewPassword.Size = new System.Drawing.Size(45, 19);
            this.lbl_Err_NewPassword.TabIndex = 10;
            this.lbl_Err_NewPassword.Text = "label7";
            // 
            // lbl_Err_RepeatNewPassword
            // 
            this.lbl_Err_RepeatNewPassword.AutoSize = true;
            this.lbl_Err_RepeatNewPassword.ForeColor = System.Drawing.Color.Red;
            this.lbl_Err_RepeatNewPassword.Location = new System.Drawing.Point(174, 269);
            this.lbl_Err_RepeatNewPassword.Name = "lbl_Err_RepeatNewPassword";
            this.lbl_Err_RepeatNewPassword.Size = new System.Drawing.Size(45, 19);
            this.lbl_Err_RepeatNewPassword.TabIndex = 11;
            this.lbl_Err_RepeatNewPassword.Text = "label8";
            // 
            // Frm_ChangePassword
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 504);
            this.Controls.Add(this.lbl_Err_RepeatNewPassword);
            this.Controls.Add(this.lbl_Err_NewPassword);
            this.Controls.Add(this.lbl_Err_OldPassword);
            this.Controls.Add(this.lbl_Err_Summary);
            this.Controls.Add(this.btn_ChagePassword);
            this.Controls.Add(this.txt_RepeatNewPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_NewPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_OldPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_Title);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Frm_ChangePassword";
            this.Text = "Frm_ChangePassword";
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
    }
}