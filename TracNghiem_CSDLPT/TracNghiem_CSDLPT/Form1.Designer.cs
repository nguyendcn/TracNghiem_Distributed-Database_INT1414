namespace TracNghiem_CSDLPT
{
    partial class Form1
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
            this.btn_Login = new System.Windows.Forms.Button();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.txt_Username = new System.Windows.Forms.TextBox();
            this.cmb_CoSo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btn_Login
            // 
            this.btn_Login.Location = new System.Drawing.Point(162, 309);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(75, 23);
            this.btn_Login.TabIndex = 0;
            this.btn_Login.Text = "Login";
            this.btn_Login.UseVisualStyleBackColor = true;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // txt_Password
            // 
            this.txt_Password.Location = new System.Drawing.Point(129, 260);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.Size = new System.Drawing.Size(150, 20);
            this.txt_Password.TabIndex = 1;
            // 
            // txt_Username
            // 
            this.txt_Username.Location = new System.Drawing.Point(129, 228);
            this.txt_Username.Name = "txt_Username";
            this.txt_Username.Size = new System.Drawing.Size(150, 20);
            this.txt_Username.TabIndex = 2;
            // 
            // cmb_CoSo
            // 
            this.cmb_CoSo.FormattingEnabled = true;
            this.cmb_CoSo.Location = new System.Drawing.Point(129, 45);
            this.cmb_CoSo.Name = "cmb_CoSo";
            this.cmb_CoSo.Size = new System.Drawing.Size(136, 21);
            this.cmb_CoSo.TabIndex = 3;
            this.cmb_CoSo.SelectedIndexChanged += new System.EventHandler(this.cmb_CoSo_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 501);
            this.Controls.Add(this.cmb_CoSo);
            this.Controls.Add(this.txt_Username);
            this.Controls.Add(this.txt_Password);
            this.Controls.Add(this.btn_Login);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.TextBox txt_Password;
        private System.Windows.Forms.TextBox txt_Username;
        private System.Windows.Forms.ComboBox cmb_CoSo;
    }
}

