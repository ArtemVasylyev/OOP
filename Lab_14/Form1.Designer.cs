namespace Lab_14
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
            this.comboBoxDrives = new System.Windows.Forms.ComboBox();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.rtbProperties = new System.Windows.Forms.RichTextBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.listBoxFolders = new System.Windows.Forms.ListBox();
            this.listBoxFiles = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.створитиПапкуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.створитиФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.копіюватиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.переміститиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.перейменуватиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.видалитиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вАрхівZIPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.розпакуватиZIPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.chkReadOnly = new System.Windows.Forms.CheckBox();
            this.chkHidden = new System.Windows.Forms.CheckBox();
            this.btnApplyAttributes = new System.Windows.Forms.Button();
            this.btnSaveText = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxDrives
            // 
            this.comboBoxDrives.FormattingEnabled = true;
            this.comboBoxDrives.Location = new System.Drawing.Point(12, 12);
            this.comboBoxDrives.Name = "comboBoxDrives";
            this.comboBoxDrives.Size = new System.Drawing.Size(121, 28);
            this.comboBoxDrives.TabIndex = 0;
            this.comboBoxDrives.SelectedIndexChanged += new System.EventHandler(this.comboBoxDrives_SelectedIndexChanged);
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(170, 14);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(424, 26);
            this.txtFilter.TabIndex = 1;
            // 
            // rtbProperties
            // 
            this.rtbProperties.Location = new System.Drawing.Point(756, 349);
            this.rtbProperties.Name = "rtbProperties";
            this.rtbProperties.Size = new System.Drawing.Size(288, 392);
            this.rtbProperties.TabIndex = 2;
            this.rtbProperties.Text = "";
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(229, 46);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(269, 45);
            this.btnFilter.TabIndex = 3;
            this.btnFilter.Text = "Застосувати фільтр";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // listBoxFolders
            // 
            this.listBoxFolders.ContextMenuStrip = this.contextMenuStrip1;
            this.listBoxFolders.FormattingEnabled = true;
            this.listBoxFolders.ItemHeight = 20;
            this.listBoxFolders.Location = new System.Drawing.Point(12, 349);
            this.listBoxFolders.Name = "listBoxFolders";
            this.listBoxFolders.Size = new System.Drawing.Size(350, 304);
            this.listBoxFolders.TabIndex = 4;
            this.listBoxFolders.SelectedIndexChanged += new System.EventHandler(this.listBoxFolders_SelectedIndexChanged);
            this.listBoxFolders.DoubleClick += new System.EventHandler(this.listBoxFolders_DoubleClick);
            // 
            // listBoxFiles
            // 
            this.listBoxFiles.ContextMenuStrip = this.contextMenuStrip1;
            this.listBoxFiles.FormattingEnabled = true;
            this.listBoxFiles.ItemHeight = 20;
            this.listBoxFiles.Location = new System.Drawing.Point(368, 349);
            this.listBoxFiles.Name = "listBoxFiles";
            this.listBoxFiles.Size = new System.Drawing.Size(382, 304);
            this.listBoxFiles.TabIndex = 5;
            this.listBoxFiles.SelectedIndexChanged += new System.EventHandler(this.listBoxFiles_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(1115, 386);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(249, 206);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.створитиПапкуToolStripMenuItem,
            this.створитиФайлToolStripMenuItem,
            this.копіюватиToolStripMenuItem,
            this.переміститиToolStripMenuItem,
            this.перейменуватиToolStripMenuItem,
            this.видалитиToolStripMenuItem,
            this.вАрхівZIPToolStripMenuItem,
            this.розпакуватиZIPToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(227, 260);
            // 
            // створитиПапкуToolStripMenuItem
            // 
            this.створитиПапкуToolStripMenuItem.Name = "створитиПапкуToolStripMenuItem";
            this.створитиПапкуToolStripMenuItem.Size = new System.Drawing.Size(226, 32);
            this.створитиПапкуToolStripMenuItem.Text = "Створити папку";
            this.створитиПапкуToolStripMenuItem.Click += new System.EventHandler(this.створитиПапкуToolStripMenuItem_Click);
            // 
            // створитиФайлToolStripMenuItem
            // 
            this.створитиФайлToolStripMenuItem.Name = "створитиФайлToolStripMenuItem";
            this.створитиФайлToolStripMenuItem.Size = new System.Drawing.Size(226, 32);
            this.створитиФайлToolStripMenuItem.Text = "Створити файл";
            this.створитиФайлToolStripMenuItem.Click += new System.EventHandler(this.створитиФайлToolStripMenuItem_Click);
            // 
            // копіюватиToolStripMenuItem
            // 
            this.копіюватиToolStripMenuItem.Name = "копіюватиToolStripMenuItem";
            this.копіюватиToolStripMenuItem.Size = new System.Drawing.Size(226, 32);
            this.копіюватиToolStripMenuItem.Text = "Копіювати";
            this.копіюватиToolStripMenuItem.Click += new System.EventHandler(this.копіюватиToolStripMenuItem_Click);
            // 
            // переміститиToolStripMenuItem
            // 
            this.переміститиToolStripMenuItem.Name = "переміститиToolStripMenuItem";
            this.переміститиToolStripMenuItem.Size = new System.Drawing.Size(226, 32);
            this.переміститиToolStripMenuItem.Text = "Перемістити";
            this.переміститиToolStripMenuItem.Click += new System.EventHandler(this.переміститиToolStripMenuItem_Click);
            // 
            // перейменуватиToolStripMenuItem
            // 
            this.перейменуватиToolStripMenuItem.Name = "перейменуватиToolStripMenuItem";
            this.перейменуватиToolStripMenuItem.Size = new System.Drawing.Size(226, 32);
            this.перейменуватиToolStripMenuItem.Text = "Перейменувати";
            this.перейменуватиToolStripMenuItem.Click += new System.EventHandler(this.перейменуватиToolStripMenuItem_Click);
            // 
            // видалитиToolStripMenuItem
            // 
            this.видалитиToolStripMenuItem.Name = "видалитиToolStripMenuItem";
            this.видалитиToolStripMenuItem.Size = new System.Drawing.Size(226, 32);
            this.видалитиToolStripMenuItem.Text = "Видалити";
            this.видалитиToolStripMenuItem.Click += new System.EventHandler(this.видалитиToolStripMenuItem_Click);
            // 
            // вАрхівZIPToolStripMenuItem
            // 
            this.вАрхівZIPToolStripMenuItem.Name = "вАрхівZIPToolStripMenuItem";
            this.вАрхівZIPToolStripMenuItem.Size = new System.Drawing.Size(226, 32);
            this.вАрхівZIPToolStripMenuItem.Text = "В архів (ZIP)";
            this.вАрхівZIPToolStripMenuItem.Click += new System.EventHandler(this.вАрхівZIPToolStripMenuItem_Click);
            // 
            // розпакуватиZIPToolStripMenuItem
            // 
            this.розпакуватиZIPToolStripMenuItem.Name = "розпакуватиZIPToolStripMenuItem";
            this.розпакуватиZIPToolStripMenuItem.Size = new System.Drawing.Size(226, 32);
            this.розпакуватиZIPToolStripMenuItem.Text = "Розпакувати (ZIP)";
            this.розпакуватиZIPToolStripMenuItem.Click += new System.EventHandler(this.розпакуватиZIPToolStripMenuItem_Click);
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(737, 13);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(292, 26);
            this.txtInput.TabIndex = 8;
            // 
            // chkReadOnly
            // 
            this.chkReadOnly.AutoSize = true;
            this.chkReadOnly.Location = new System.Drawing.Point(65, 100);
            this.chkReadOnly.Name = "chkReadOnly";
            this.chkReadOnly.Size = new System.Drawing.Size(106, 24);
            this.chkReadOnly.TabIndex = 9;
            this.chkReadOnly.Text = "Read only";
            this.chkReadOnly.UseVisualStyleBackColor = true;
            // 
            // chkHidden
            // 
            this.chkHidden.AutoSize = true;
            this.chkHidden.Location = new System.Drawing.Point(65, 154);
            this.chkHidden.Name = "chkHidden";
            this.chkHidden.Size = new System.Drawing.Size(77, 24);
            this.chkHidden.TabIndex = 10;
            this.chkHidden.Text = "Hiden";
            this.chkHidden.UseVisualStyleBackColor = true;
            // 
            // btnApplyAttributes
            // 
            this.btnApplyAttributes.Location = new System.Drawing.Point(198, 125);
            this.btnApplyAttributes.Name = "btnApplyAttributes";
            this.btnApplyAttributes.Size = new System.Drawing.Size(188, 37);
            this.btnApplyAttributes.TabIndex = 11;
            this.btnApplyAttributes.Text = "Застосувати атрибут";
            this.btnApplyAttributes.UseVisualStyleBackColor = true;
            this.btnApplyAttributes.Click += new System.EventHandler(this.btnApplyAttributes_Click);
            // 
            // btnSaveText
            // 
            this.btnSaveText.Location = new System.Drawing.Point(779, 45);
            this.btnSaveText.Name = "btnSaveText";
            this.btnSaveText.Size = new System.Drawing.Size(218, 42);
            this.btnSaveText.TabIndex = 12;
            this.btnSaveText.Text = "Зберегти текст";
            this.btnSaveText.UseVisualStyleBackColor = true;
            this.btnSaveText.Click += new System.EventHandler(this.btnSaveText_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1538, 1191);
            this.Controls.Add(this.btnSaveText);
            this.Controls.Add(this.btnApplyAttributes);
            this.Controls.Add(this.chkHidden);
            this.Controls.Add(this.chkReadOnly);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.listBoxFiles);
            this.Controls.Add(this.listBoxFolders);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.rtbProperties);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.comboBoxDrives);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxDrives;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.RichTextBox rtbProperties;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.ListBox listBoxFolders;
        private System.Windows.Forms.ListBox listBoxFiles;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem створитиПапкуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem створитиФайлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem копіюватиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem переміститиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem перейменуватиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem видалитиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вАрхівZIPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem розпакуватиZIPToolStripMenuItem;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.CheckBox chkReadOnly;
        private System.Windows.Forms.CheckBox chkHidden;
        private System.Windows.Forms.Button btnApplyAttributes;
        private System.Windows.Forms.Button btnSaveText;
    }
}

