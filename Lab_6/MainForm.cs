using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab6_WinForms
{
    public class MainForm : Form
    {
        private TextBox txtA, txtB, txtC;
        private Label lblResult;
        private Button btnCalculate;

        public MainForm()
        {
            this.Text = "Лабораторна №6 - Площа трикутника";
            this.Size = new Size(400, 320);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Створення елементів керування
            Label lblA = new Label { Text = "Сторона A:", Location = new Point(20, 20), AutoSize = true };
            txtA = new TextBox { Location = new Point(120, 20), Width = 150 };

            Label lblB = new Label { Text = "Сторона B:", Location = new Point(20, 60), AutoSize = true };
            txtB = new TextBox { Location = new Point(120, 60), Width = 150 };

            Label lblC = new Label { Text = "Сторона C:", Location = new Point(20, 100), AutoSize = true };
            txtC = new TextBox { Location = new Point(120, 100), Width = 150 };

            btnCalculate = new Button { 
                Text = "Обчислити площу", 
                Location = new Point(20, 150), 
                Width = 250, 
                Height = 40,
                BackColor = Color.LightGray 
            };
            btnCalculate.Click += BtnCalculate_Click;

            lblResult = new Label { 
                Text = "Результат: ", 
                Location = new Point(20, 210), 
                AutoSize = true, 
                Font = new Font("Segoe UI", 10, FontStyle.Bold) 
            };

            this.Controls.AddRange(new Control[] { lblA, txtA, lblB, txtB, lblC, txtC, btnCalculate, lblResult });
        }

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            TriangleLogic logic = new TriangleLogic();
            lblResult.ForeColor = Color.Black;

            // Початок блоку обробки виключень
            try 
            {
                // Спроба парсингу тексту в числа
                double a = double.Parse(txtA.Text);
                double b = double.Parse(txtB.Text);
                double c = double.Parse(txtC.Text);

                // Виклик методу, який може викинути помилку
                double area = logic.CalculateArea(a, b, c);
                
                lblResult.Text = $"Площа трикутника: {area:F4}";
            }
            // Обробка помилки формату (якщо ввели літери)
            catch (FormatException)
            {
                lblResult.ForeColor = Color.Red;
                lblResult.Text = "Помилка: Вводьте лише числа!";
            }
            // Обробка всіх інших помилок через базовий клас Exception
            catch (Exception ex)
            {
                lblResult.ForeColor = Color.Red;
                lblResult.Text = $"Помилка: {ex.Message}";
            }
            // Блок, який виконується завжди після try/catch
            finally
            {
                Console.WriteLine("Операцію обчислення завершено.");
            }
        }
    }
}