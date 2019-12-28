namespace TracNghiem_CSDLPT.Account
{
    partial class Frm_CreateAccount
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
            this.cmb_Employees = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_LoginName = new System.Windows.Forms.TextBox();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_Register = new System.Windows.Forms.Button();
            this.lbl_Err_Employee = new System.Windows.Forms.Label();
            this.lbl_Err_LoginName = new System.Windows.Forms.Label();
            this.lbl_Err_Password = new System.Windows.Forms.Label();
            this.lbl_Err_Summary = new System.Windows.Forms.Label();
            this.cmb_Role = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.Location = new System.Drawing.Point(134, 23);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(100, 19);
            this.lbl_Title.TabIndex = 0;
            this.lbl_Title.Text = "Some text here";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Giáo viên";
            // 
            // cmb_Employees
            // 
            this.cmb_Employees.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmb_Employees.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_Employees.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Employees.FormattingEnabled = true;
            this.cmb_Employees.Location = new System.Drawing.Point(149, 134);
            this.cmb_Employees.Name = "cmb_Employees";
            this.cmb_Employees.Size = new System.Drawing.Size(179, 27);
            this.cmb_Employees.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tên dăng nhập";
            // 
            // txt_LoginName
            // 
            this.txt_LoginName.Location = new System.Drawing.Point(149, 191);
            this.txt_LoginName.Name = "txt_LoginName";
            this.txt_LoginName.Size = new System.Drawing.Size(179, 26);
            this.txt_LoginName.TabIndex = 4;
            // 
            // txt_Password
            // 
            this.txt_Password.Location = new System.Drawing.Point(149, 242);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.Size = new System.Drawing.Size(179, 26);
            this.txt_Password.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 242);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 19);
            this.label4.TabIndex = 5;
            this.label4.Text = "Mật khẩu";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 297);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 19);
            this.label5.TabIndex = 7;
            this.label5.Text = "Quyền";
            // 
            // btn_Register
            // 
            this.btn_Register.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Register.Location = new System.Drawing.Point(119, 357);
            this.btn_Register.Name = "btn_Register";
            this.btn_Register.Size = new System.Drawing.Size(144, 53);
            this.btn_Register.TabIndex = 9;
            this.btn_Register.Text = "Tạo";
            this.btn_Register.UseVisualStyleBackColor = true;
            this.btn_Register.Click += new System.EventHandler(this.btn_Register_Click);
            // 
            // lbl_Err_Employee
            // 
            this.lbl_Err_Employee.AutoSize = true;
            this.lbl_Err_Employee.ForeColor = System.Drawing.Color.Red;
            this.lbl_Err_Employee.Location = new System.Drawing.Point(145, 112);
            this.lbl_Err_Employee.Name = "lbl_Err_Employee";
            this.lbl_Err_Employee.Size = new System.Drawing.Size(45, 19);
            this.lbl_Err_Employee.TabIndex = 10;
            this.lbl_Err_Employee.Text = "label6";
            // 
            // lbl_Err_LoginName
            // 
            this.lbl_Err_LoginName.AutoSize = true;
            this.lbl_Err_LoginName.ForeColor = System.Drawing.Color.Red;
            this.lbl_Err_LoginName.Location = new System.Drawing.Point(145, 168);
            this.lbl_Err_LoginName.Name = "lbl_Err_LoginName";
            this.lbl_Err_LoginName.Size = new System.Drawing.Size(45, 19);
            this.lbl_Err_LoginName.TabIndex = 11;
            this.lbl_Err_LoginName.Text = "label7";
            // 
            // lbl_Err_Password
            // 
            this.lbl_Err_Password.AutoSize = true;
            this.lbl_Err_Password.ForeColor = System.Drawing.Color.Red;
            this.lbl_Err_Password.Location = new System.Drawing.Point(145, 220);
            this.lbl_Err_Password.Name = "lbl_Err_Password";
            this.lbl_Err_Password.Size = new System.Drawing.Size(45, 19);
            this.lbl_Err_Password.TabIndex = 12;
            this.lbl_Err_Password.Text = "label8";
            // 
            // lbl_Err_Summary
            // 
            this.lbl_Err_Summary.AutoSize = true;
            this.lbl_Err_Summary.ForeColor = System.Drawing.Color.Red;
            this.lbl_Err_Summary.Location = new System.Drawing.Point(85, 73);
            this.lbl_Err_Summary.Name = "lbl_Err_Summary";
            this.lbl_Err_Summary.Size = new System.Drawing.Size(45, 19);
            this.lbl_Err_Summary.TabIndex = 13;
            this.lbl_Err_Summary.Text = "label9";
            // 
            // cmb_Role
            // 
            this.cmb_Role.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmb_Role.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_Role.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmb_Role.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Role.FormattingEnabled = true;
            this.cmb_Role.Location = new System.Drawing.Point(149, 294);
            this.cmb_Role.Name = "cmb_Role";
            this.cmb_Role.Size = new System.Drawing.Size(179, 27);
            this.cmb_Role.TabIndex = 14;
            // 
            // Frm_CreateAccount
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 448);
            this.Controls.Add(this.cmb_Role);
            this.Controls.Add(this.lbl_Err_Summary);
            this.Controls.Add(this.lbl_Err_Password);
            this.Controls.Add(this.lbl_Err_LoginName);
            this.Controls.Add(this.lbl_Err_Employee);
            this.Controls.Add(this.btn_Register);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_Password);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_LoginName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmb_Employees);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_Title);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Frm_CreateAccount";
            this.Text = "Frm_CreateAccount";
            this.Load += new System.EventHandler(this.Frm_CreateAccount_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_Employees;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_LoginName;
        private System.Windows.Forms.TextBox txt_Password;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_Register;
        private System.Windows.Forms.Label lbl_Err_Employee;
        private System.Windows.Forms.Label lbl_Err_LoginName;
        private System.Windows.Forms.Label lbl_Err_Password;
        private System.Windows.Forms.Label lbl_Err_Summary;
        private System.Windows.Forms.ComboBox cmb_Role;
    }
}