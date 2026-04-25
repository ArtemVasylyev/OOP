using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Word = Microsoft.Office.Interop.Word;

namespace Lab_12
{
    public partial class Form1 : Form
    {
        private Word.Application wordApp;
        private Word.Document doc;

        public Form1()
        {
            InitializeComponent();

            if (comboBox1.Items.Count == 0)
            {
                comboBox1.Items.Add("Шаблон 1");
                comboBox1.Items.Add("Шаблон 2");
            }
            comboBox1.SelectedIndex = 0;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRecipient.Text) || string.IsNullOrWhiteSpace(txtAmount.Text))
            {
                MessageBox.Show("Будь ласка, заповніть поля отримувача та суми!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string templatePath = "";
            if (comboBox1.SelectedIndex == 0)
                templatePath = @"C:\Users\av335\Desktop\cert1.dotx";
            else
                templatePath = @"C:\Users\av335\Desktop\cert2.dotx";

            try
            {
                wordApp = new Word.Application();
                Object templatePathObj = templatePath;
                Object missingObj = System.Reflection.Missing.Value;

                doc = wordApp.Documents.Add(ref templatePathObj, ref missingObj, ref missingObj, ref missingObj);
                doc.Activate();

                foreach (Word.FormField field in doc.FormFields)
                {
                    switch (field.Name)
                    {
                        case "Recipient":
                            field.Range.Text = txtRecipient.Text;
                            break;
                        case "Amount":
                            field.Range.Text = txtAmount.Text;
                            break;
                    }
                }

                if (!string.IsNullOrWhiteSpace(txtSearch.Text) && !string.IsNullOrWhiteSpace(txtReplace.Text))
                {
                    Word.Find findObject = wordApp.Selection.Find;
                    findObject.ClearFormatting();
                    findObject.Text = txtSearch.Text;
                    findObject.Replacement.ClearFormatting();
                    findObject.Replacement.Text = txtReplace.Text;

                    object replaceAll = Word.WdReplace.wdReplaceAll;
                    findObject.Execute(ref missingObj, ref missingObj, ref missingObj, ref missingObj, ref missingObj,
                        ref missingObj, ref missingObj, ref missingObj, ref missingObj, ref missingObj,
                        ref replaceAll, ref missingObj, ref missingObj, ref missingObj, ref missingObj);
                }

                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Word Document (*.docx)|*.docx";
                saveDialog.FileName = "Готовий_Сертифікат.docx";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    object savePath = saveDialog.FileName;
                    doc.SaveAs2(ref savePath);
                    MessageBox.Show("Документ успішно створено та збережено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                wordApp.Visible = true;
            }
            catch (Exception ex)
            {
                CleanUpWord();
                MessageBox.Show("Помилка: " + ex.Message + "\n\nПереконайтеся, що файл шаблону існує за вказаним шляхом.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            CleanUpWord();
        }

        private void CleanUpWord()
        {
            if (doc != null)
            {
                try
                {
                    object saveChanges = Word.WdSaveOptions.wdDoNotSaveChanges;
                    doc.Close(ref saveChanges);
                }
                catch { } // Ігноруємо помилку, якщо документ вже закрито вручну

                doc = null;
            }

            if (wordApp != null)
            {
                try
                {
                    wordApp.Quit();
                }
                catch { } // Ігноруємо помилку, якщо Word вже закрито

                wordApp = null;
            }
        }
    }
}