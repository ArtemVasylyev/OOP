namespace Lab_7
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            створитиToolStripMenuItem = new ToolStripMenuItem();
            зберегтиВRTFToolStripMenuItem = new ToolStripMenuItem();
            форматToolStripMenuItem = new ToolStripMenuItem();
            шрифтToolStripMenuItem = new ToolStripMenuItem();
            зліваToolStripMenuItem = new ToolStripMenuItem();
            поЦентруToolStripMenuItem = new ToolStripMenuItem();
            справаToolStripMenuItem = new ToolStripMenuItem();
            вставкаToolStripMenuItem = new ToolStripMenuItem();
            зображенняToolStripMenuItem = new ToolStripMenuItem();
            fontDialog1 = new FontDialog();
            saveFileDialog1 = new SaveFileDialog();
            openFileDialog1 = new OpenFileDialog();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem, форматToolStripMenuItem, вставкаToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 33);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { створитиToolStripMenuItem, зберегтиВRTFToolStripMenuItem });
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(69, 29);
            файлToolStripMenuItem.Text = "Файл";
            // 
            // створитиToolStripMenuItem
            // 
            створитиToolStripMenuItem.Name = "створитиToolStripMenuItem";
            створитиToolStripMenuItem.Size = new Size(235, 34);
            створитиToolStripMenuItem.Text = "Створити";
            створитиToolStripMenuItem.Click += створитиToolStripMenuItem_Click;
            // 
            // зберегтиВRTFToolStripMenuItem
            // 
            зберегтиВRTFToolStripMenuItem.Name = "зберегтиВRTFToolStripMenuItem";
            зберегтиВRTFToolStripMenuItem.Size = new Size(235, 34);
            зберегтиВRTFToolStripMenuItem.Text = "Зберегти в RTF";
            зберегтиВRTFToolStripMenuItem.Click += зберегтиВRTFToolStripMenuItem_Click;
            // 
            // форматToolStripMenuItem
            // 
            форматToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { шрифтToolStripMenuItem, зліваToolStripMenuItem, поЦентруToolStripMenuItem, справаToolStripMenuItem });
            форматToolStripMenuItem.Name = "форматToolStripMenuItem";
            форматToolStripMenuItem.Size = new Size(92, 29);
            форматToolStripMenuItem.Text = "Формат";
            // 
            // шрифтToolStripMenuItem
            // 
            шрифтToolStripMenuItem.Name = "шрифтToolStripMenuItem";
            шрифтToolStripMenuItem.Size = new Size(270, 34);
            шрифтToolStripMenuItem.Text = "Шрифт";
            шрифтToolStripMenuItem.Click += шрифтToolStripMenuItem_Click;
            // 
            // зліваToolStripMenuItem
            // 
            зліваToolStripMenuItem.Name = "зліваToolStripMenuItem";
            зліваToolStripMenuItem.Size = new Size(270, 34);
            зліваToolStripMenuItem.Text = "По лівому краю";
            зліваToolStripMenuItem.Click += зліваToolStripMenuItem_Click;
            // 
            // поЦентруToolStripMenuItem
            // 
            поЦентруToolStripMenuItem.Name = "поЦентруToolStripMenuItem";
            поЦентруToolStripMenuItem.Size = new Size(270, 34);
            поЦентруToolStripMenuItem.Text = "По центру";
            поЦентруToolStripMenuItem.Click += поЦентруToolStripMenuItem_Click;
            // 
            // справаToolStripMenuItem
            // 
            справаToolStripMenuItem.Name = "справаToolStripMenuItem";
            справаToolStripMenuItem.Size = new Size(270, 34);
            справаToolStripMenuItem.Text = "По правому краю";
            справаToolStripMenuItem.Click += справаToolStripMenuItem_Click;
            // 
            // вставкаToolStripMenuItem
            // 
            вставкаToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { зображенняToolStripMenuItem });
            вставкаToolStripMenuItem.Name = "вставкаToolStripMenuItem";
            вставкаToolStripMenuItem.Size = new Size(90, 29);
            вставкаToolStripMenuItem.Text = "Вставка";
            // 
            // зображенняToolStripMenuItem
            // 
            зображенняToolStripMenuItem.Name = "зображенняToolStripMenuItem";
            зображенняToolStripMenuItem.Size = new Size(270, 34);
            зображенняToolStripMenuItem.Text = "Зображення";
            зображенняToolStripMenuItem.Click += зображенняToolStripMenuItem_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem створитиToolStripMenuItem;
        private ToolStripMenuItem зберегтиВRTFToolStripMenuItem;
        private ToolStripMenuItem форматToolStripMenuItem;
        private ToolStripMenuItem шрифтToolStripMenuItem;
        private ToolStripMenuItem поЦентруToolStripMenuItem;
        private ToolStripMenuItem вставкаToolStripMenuItem;
        private ToolStripMenuItem зображенняToolStripMenuItem;
        private FontDialog fontDialog1;
        private SaveFileDialog saveFileDialog1;
        private OpenFileDialog openFileDialog1;
        private ToolStripMenuItem справаToolStripMenuItem;
        private ToolStripMenuItem зліваToolStripMenuItem;
    }
}
