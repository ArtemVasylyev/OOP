namespace Lab_7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void створитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DocumentForm doc = new DocumentForm();
            doc.MdiParent = this;
            doc.Show();
        }

        private void шрифтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is DocumentForm doc)
            {
                if (fontDialog1.ShowDialog() == DialogResult.OK)
                {
                    doc.richTextBox1.SelectionFont = fontDialog1.Font;
                }
            }
        }

        private void зберегтиВRTFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is DocumentForm doc)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    doc.richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.RichText);
                }
            }
        }

        private void справаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is DocumentForm doc)
            {
                doc.richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
            }
        }

        private void зліваToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is DocumentForm doc)
            {
                doc.richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
            }
        }

        private void поЦентруToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is DocumentForm doc)
            {
                doc.richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            }
        }

        private void зображенняToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.ActiveMdiChild is DocumentForm doc)
{
                openFileDialog1.Filter = "Images|*.png;*.jpg;*.bmp";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Image img = Image.FromFile(openFileDialog1.FileName);
                    Clipboard.SetImage(img);
                    doc.richTextBox1.Paste();
                }
            }
        }
    }
}
