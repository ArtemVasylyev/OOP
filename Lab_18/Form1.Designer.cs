namespace Lab_18
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
            this.dgvProcesses = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.contextMenuProcess = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.infoAboutPrecessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flowsAndModulesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopProcessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcesses)).BeginInit();
            this.contextMenuProcess.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvProcesses
            // 
            this.dgvProcesses.AllowUserToAddRows = false;
            this.dgvProcesses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProcesses.ContextMenuStrip = this.contextMenuProcess;
            this.dgvProcesses.Location = new System.Drawing.Point(243, 12);
            this.dgvProcesses.Name = "dgvProcesses";
            this.dgvProcesses.ReadOnly = true;
            this.dgvProcesses.RowHeadersWidth = 62;
            this.dgvProcesses.RowTemplate.Height = 28;
            this.dgvProcesses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProcesses.Size = new System.Drawing.Size(545, 406);
            this.dgvProcesses.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(24, 68);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(146, 56);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh List";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(24, 194);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(146, 57);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "Export to TXT";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // contextMenuProcess
            // 
            this.contextMenuProcess.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuProcess.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoAboutPrecessToolStripMenuItem,
            this.flowsAndModulesToolStripMenuItem,
            this.stopProcessToolStripMenuItem});
            this.contextMenuProcess.Name = "contextMenuProcess";
            this.contextMenuProcess.Size = new System.Drawing.Size(241, 133);
            // 
            // infoAboutPrecessToolStripMenuItem
            // 
            this.infoAboutPrecessToolStripMenuItem.Name = "infoAboutPrecessToolStripMenuItem";
            this.infoAboutPrecessToolStripMenuItem.Size = new System.Drawing.Size(240, 32);
            this.infoAboutPrecessToolStripMenuItem.Text = "Info about precess";
            this.infoAboutPrecessToolStripMenuItem.Click += new System.EventHandler(this.menuInfo_Click);
            // 
            // flowsAndModulesToolStripMenuItem
            // 
            this.flowsAndModulesToolStripMenuItem.Name = "flowsAndModulesToolStripMenuItem";
            this.flowsAndModulesToolStripMenuItem.Size = new System.Drawing.Size(240, 32);
            this.flowsAndModulesToolStripMenuItem.Text = "Flows and modules";
            this.flowsAndModulesToolStripMenuItem.Click += new System.EventHandler(this.menuThreads_Click);
            // 
            // stopProcessToolStripMenuItem
            // 
            this.stopProcessToolStripMenuItem.Name = "stopProcessToolStripMenuItem";
            this.stopProcessToolStripMenuItem.Size = new System.Drawing.Size(240, 32);
            this.stopProcessToolStripMenuItem.Text = "Stop process";
            this.stopProcessToolStripMenuItem.Click += new System.EventHandler(this.menuKill_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dgvProcesses);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcesses)).EndInit();
            this.contextMenuProcess.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProcesses;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ContextMenuStrip contextMenuProcess;
        private System.Windows.Forms.ToolStripMenuItem infoAboutPrecessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flowsAndModulesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopProcessToolStripMenuItem;
    }
}

