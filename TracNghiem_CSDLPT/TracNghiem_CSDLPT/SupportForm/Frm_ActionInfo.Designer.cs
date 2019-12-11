namespace TracNghiem_CSDLPT.SupportForm
{
    partial class Frm_ActionInfo
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
            this.lbl_Caption = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_No = new System.Windows.Forms.Button();
            this.btn_Yes = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgv_Data = new System.Windows.Forms.DataGridView();
            this.btn_Ok = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Data)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl_Caption);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(591, 50);
            this.panel1.TabIndex = 0;
            // 
            // lbl_Caption
            // 
            this.lbl_Caption.AutoSize = true;
            this.lbl_Caption.Location = new System.Drawing.Point(120, 21);
            this.lbl_Caption.Name = "lbl_Caption";
            this.lbl_Caption.Size = new System.Drawing.Size(53, 17);
            this.lbl_Caption.TabIndex = 0;
            this.lbl_Caption.Text = "Caption";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_Ok);
            this.panel2.Controls.Add(this.btn_No);
            this.panel2.Controls.Add(this.btn_Yes);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 212);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(591, 69);
            this.panel2.TabIndex = 1;
            // 
            // btn_No
            // 
            this.btn_No.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_No.Location = new System.Drawing.Point(329, 22);
            this.btn_No.Name = "btn_No";
            this.btn_No.Size = new System.Drawing.Size(86, 35);
            this.btn_No.TabIndex = 1;
            this.btn_No.Tag = "NO";
            this.btn_No.Text = "No";
            this.btn_No.UseVisualStyleBackColor = true;
            this.btn_No.Click += new System.EventHandler(this.btn_Option_Click);
            // 
            // btn_Yes
            // 
            this.btn_Yes.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Yes.Location = new System.Drawing.Point(156, 22);
            this.btn_Yes.Name = "btn_Yes";
            this.btn_Yes.Size = new System.Drawing.Size(86, 35);
            this.btn_Yes.TabIndex = 0;
            this.btn_Yes.Tag = "YES";
            this.btn_Yes.Text = "Yes";
            this.btn_Yes.UseVisualStyleBackColor = true;
            this.btn_Yes.Click += new System.EventHandler(this.btn_Option_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgv_Data);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 50);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(591, 162);
            this.panel3.TabIndex = 2;
            // 
            // dgv_Data
            // 
            this.dgv_Data.AllowUserToAddRows = false;
            this.dgv_Data.AllowUserToDeleteRows = false;
            this.dgv_Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Data.Location = new System.Drawing.Point(0, 0);
            this.dgv_Data.Name = "dgv_Data";
            this.dgv_Data.ReadOnly = true;
            this.dgv_Data.Size = new System.Drawing.Size(591, 162);
            this.dgv_Data.TabIndex = 0;
            // 
            // btn_Ok
            // 
            this.btn_Ok.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Ok.Location = new System.Drawing.Point(242, 22);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(86, 35);
            this.btn_Ok.TabIndex = 2;
            this.btn_Ok.Tag = "OK";
            this.btn_Ok.Text = "OK";
            this.btn_Ok.UseVisualStyleBackColor = true;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Option_Click);
            // 
            // Frm_ActionInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 281);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Frm_ActionInfo";
            this.Text = "Frm_ActionInfo";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Data)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_Caption;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_No;
        private System.Windows.Forms.Button btn_Yes;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgv_Data;
        private System.Windows.Forms.Button btn_Ok;
    }
}