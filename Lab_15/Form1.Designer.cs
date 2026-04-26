namespace Lab_15
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
            this.components = new System.ComponentModel.Container();
            this.treeViewFTP = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.створитиПапкуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.завантажитиФайлНаСерверUploadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.скачатиФайлDownloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.перейменуватиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.видалитиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeViewFTP
            // 
            this.treeViewFTP.ContextMenuStrip = this.contextMenuStrip1;
            this.treeViewFTP.Location = new System.Drawing.Point(12, 12);
            this.treeViewFTP.Name = "treeViewFTP";
            this.treeViewFTP.Size = new System.Drawing.Size(418, 786);
            this.treeViewFTP.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.створитиПапкуToolStripMenuItem,
            this.завантажитиФайлНаСерверUploadToolStripMenuItem,
            this.скачатиФайлDownloadToolStripMenuItem,
            this.перейменуватиToolStripMenuItem,
            this.видалитиToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(394, 164);
            // 
            // створитиПапкуToolStripMenuItem
            // 
            this.створитиПапкуToolStripMenuItem.Name = "створитиПапкуToolStripMenuItem";
            this.створитиПапкуToolStripMenuItem.Size = new System.Drawing.Size(393, 32);
            this.створитиПапкуToolStripMenuItem.Text = "Створити папку";
            this.створитиПапкуToolStripMenuItem.Click += new System.EventHandler(this.створитиПапкуToolStripMenuItem_Click);
            // 
            // завантажитиФайлНаСерверUploadToolStripMenuItem
            // 
            this.завантажитиФайлНаСерверUploadToolStripMenuItem.Name = "завантажитиФайлНаСерверUploadToolStripMenuItem";
            this.завантажитиФайлНаСерверUploadToolStripMenuItem.Size = new System.Drawing.Size(393, 32);
            this.завантажитиФайлНаСерверUploadToolStripMenuItem.Text = "Завантажити файл на сервер (Upload)";
            this.завантажитиФайлНаСерверUploadToolStripMenuItem.Click += new System.EventHandler(this.завантажитиФайлНаСерверUploadToolStripMenuItem_Click);
            // 
            // скачатиФайлDownloadToolStripMenuItem
            // 
            this.скачатиФайлDownloadToolStripMenuItem.Name = "скачатиФайлDownloadToolStripMenuItem";
            this.скачатиФайлDownloadToolStripMenuItem.Size = new System.Drawing.Size(393, 32);
            this.скачатиФайлDownloadToolStripMenuItem.Text = "Скачати файл (Download)";
            this.скачатиФайлDownloadToolStripMenuItem.Click += new System.EventHandler(this.скачатиФайлDownloadToolStripMenuItem_Click);
            // 
            // перейменуватиToolStripMenuItem
            // 
            this.перейменуватиToolStripMenuItem.Name = "перейменуватиToolStripMenuItem";
            this.перейменуватиToolStripMenuItem.Size = new System.Drawing.Size(393, 32);
            this.перейменуватиToolStripMenuItem.Text = "Перейменувати";
            this.перейменуватиToolStripMenuItem.Click += new System.EventHandler(this.перейменуватиToolStripMenuItem_Click);
            // 
            // видалитиToolStripMenuItem
            // 
            this.видалитиToolStripMenuItem.Name = "видалитиToolStripMenuItem";
            this.видалитиToolStripMenuItem.Size = new System.Drawing.Size(393, 32);
            this.видалитиToolStripMenuItem.Text = "Видалити";
            this.видалитиToolStripMenuItem.Click += new System.EventHandler(this.видалитиToolStripMenuItem_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(436, 736);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(247, 62);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "Connnect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(689, 736);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(246, 62);
            this.btnSettings.TabIndex = 2;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(436, 12);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(544, 26);
            this.txtInput.TabIndex = 3;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1227, 810);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.treeViewFTP);
            this.Name = "Form1";
            this.Text = "Form1";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewFTP;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem створитиПапкуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem завантажитиФайлНаСерверUploadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem скачатиФайлDownloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem перейменуватиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem видалитиToolStripMenuItem;
    }
}

