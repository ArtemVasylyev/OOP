using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lab_7
{
    public partial class DocumentForm : Form
    {
        public DocumentForm()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            int pos = richTextBox1.SelectionStart;

            
            string[] keywords = { "int", "void", "string", "class", "public", "if", "else" };

            this.SuspendLayout(); 

            richTextBox1.SelectAll();
            richTextBox1.SelectionColor = Color.Black;

            foreach (string word in keywords)
            {
                int start = 0;
                while ((start = richTextBox1.Find(word, start, RichTextBoxFinds.WholeWord)) != -1)
                {
                    richTextBox1.SelectionStart = start;
                    richTextBox1.SelectionLength = word.Length;
                    richTextBox1.SelectionColor = Color.Blue; 
                    start += word.Length;
                }
            }

            
            richTextBox1.SelectionStart = pos;
            richTextBox1.SelectionLength = 0;
            richTextBox1.SelectionColor = Color.Black;

            this.ResumeLayout();
        }
    }
}
