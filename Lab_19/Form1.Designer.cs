namespace Lab_19
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
            this.cmbHardwareType = new System.Windows.Forms.ComboBox();
            this.btnGetInfo = new System.Windows.Forms.Button();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cmbHardwareType
            // 
            this.cmbHardwareType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHardwareType.FormattingEnabled = true;
            this.cmbHardwareType.Items.AddRange(new object[] {
            "CPU",
            "GPU",
            "HDD/SSD",
            "Motherboard",
            "BIOS",
            "Network adapters"});
            this.cmbHardwareType.Location = new System.Drawing.Point(12, 12);
            this.cmbHardwareType.Name = "cmbHardwareType";
            this.cmbHardwareType.Size = new System.Drawing.Size(209, 28);
            this.cmbHardwareType.TabIndex = 0;
            // 
            // btnGetInfo
            // 
            this.btnGetInfo.Location = new System.Drawing.Point(12, 394);
            this.btnGetInfo.Name = "btnGetInfo";
            this.btnGetInfo.Size = new System.Drawing.Size(121, 44);
            this.btnGetInfo.TabIndex = 1;
            this.btnGetInfo.Text = "Get info";
            this.btnGetInfo.UseVisualStyleBackColor = true;
            this.btnGetInfo.Click += new System.EventHandler(this.btnGetInfo_Click);
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(401, 12);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ReadOnly = true;
            this.txtInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInfo.Size = new System.Drawing.Size(387, 426);
            this.txtInfo.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.btnGetInfo);
            this.Controls.Add(this.cmbHardwareType);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbHardwareType;
        private System.Windows.Forms.Button btnGetInfo;
        private System.Windows.Forms.TextBox txtInfo;
    }
}

