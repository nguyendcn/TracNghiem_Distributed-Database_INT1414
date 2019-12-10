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
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgv_Data = new System.Windows.Forms.DataGridView();
            this.btn_Yes = new System.Windows.Forms.Button();
            this.btn_No = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_Action = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Data)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl_Action);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(591, 56);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_No);
            this.panel2.Controls.Add(this.btn_Yes);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 212);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(591, 69);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgv_Data);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 56);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(591, 156);
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
            this.dgv_Data.Size = new System.Drawing.Size(591, 156);
            this.dgv_Data.TabIndex = 0;
            // 
            // btn_Yes
            // 
            this.btn_Yes.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Yes.Location = new System.Drawing.Point(156, 22);
            this.btn_Yes.Name = "btn_Yes";
            this.btn_Yes.Size = new System.Drawing.Size(86, 35);
            this.btn_Yes.TabIndex = 0;
            this.btn_Yes.Text = "Yes";
            this.btn_Yes.UseVisualStyleBackColor = true;
            this.btn_Yes.Click += new System.EventHandler(this.btn_Yes_Click);
            // 
            // btn_No
            // 
            this.btn_No.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_No.Location = new System.Drawing.Point(329, 22);
            this.btn_No.Name = "btn_No";
            this.btn_No.Size = new System.Drawing.Size(86, 35);
            this.btn_No.TabIndex = 1;
            this.btn_No.Text = "No";
            this.btn_No.UseVisualStyleBackColor = true;
            this.btn_No.Click += new System.EventHandler(this.btn_No_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(120, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(268, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bạn có chắc muốn phục hồi dữ liệu đã được";
            // 
            // lbl_Action
            // 
            this.lbl_Action.AutoSize = true;
            this.lbl_Action.Location = new System.Drawing.Point(385, 21);
            this.lbl_Action.Name = "lbl_Action";
            this.lbl_Action.Size = new System.Drawing.Size(47, 17);
            this.lbl_Action.TabIndex = 1;
            this.lbl_Action.Text = "Action";
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
        private System.Windows.Forms.Label lbl_Action;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_No;
        private System.Windows.Forms.Button btn_Yes;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgv_Data;
    }
}