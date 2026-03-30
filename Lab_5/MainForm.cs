using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab5_WinForms
{
    public class MainForm : Form
    {
        private TextBox txtInput;      // Поле для введення тексту
        private RichTextBox txtResult; // Поле для результату
        private Button btnProcess;     // Кнопка запуску
        private Label lblHint;         // Підказка

        public MainForm()
        {
            // Налаштування вікна
            this.Text = "Лабораторна робота №5 - Варіант 1";
            this.Size = new Size(500, 400);
            this.StartPosition = FormStartPosition.CenterScreen;

            lblHint = new Label { Text = "Введіть текст із зайвими пробілами:", Location = new Point(20, 10), AutoSize = true };
            
            txtInput = new TextBox { 
                Location = new Point(20, 35), 
                Size = new Size(440, 60), 
                Multiline = true,
                ScrollBars = ScrollBars.Vertical
            };

            btnProcess = new Button { 
                Text = "Очистити пробіли", 
                Location = new Point(20, 105), 
                Size = new Size(150, 40),
                BackColor = Color.LightBlue
            };
            btnProcess.Click += BtnProcess_Click;

            txtResult = new RichTextBox { 
                Location = new Point(20, 160), 
                Size = new Size(440, 180), 
                ReadOnly = true,
                Font = new Font("Segoe UI", 10)
            };

            // Додаємо елементи на форму
            this.Controls.Add(lblHint);
            this.Controls.Add(txtInput);
            this.Controls.Add(btnProcess);
            this.Controls.Add(txtResult);
        }

        private void BtnProcess_Click(object sender, EventArgs e)
        {
            string inputText = txtInput.Text;
            
            // Створюємо об'єкт логіки
            StringLogic logic = new StringLogic();
            
            // Отримуємо результат
            string cleanText = logic.RemoveDuplicateSpaces(inputText);

            // Виводимо
            txtResult.Clear();
            if (string.IsNullOrEmpty(cleanText))
            {
                txtResult.SelectionColor = Color.Red;
                txtResult.AppendText("Помилка: Рядок порожній або містить лише пробіли.");
            }
            else
            {
                txtResult.SelectionColor = Color.DarkGreen;
                txtResult.AppendText("Оброблений текст:\n\n");
                txtResult.SelectionColor = Color.Black;
                txtResult.AppendText(cleanText);
            }
        }
    }
}