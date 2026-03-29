using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab4_WinForms
{
    public class MainForm : Form
    {
        private Button btnTask1;
        private Button btnTask2;
        private RichTextBox txtOutput;

        public MainForm()
        {
            // Налаштування головного вікна
            this.Text = "Лабораторна робота 4 - Варіант 1 (WinForms)";
            this.Size = new Size(550, 450);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Кнопка для Завдання 1
            btnTask1 = new Button();
            btnTask1.Text = "Виконати Завдання 1";
            btnTask1.Location = new Point(20, 20);
            btnTask1.Size = new Size(150, 40);
            btnTask1.Click += BtnTask1_Click; // Прив'язка події кліку
            this.Controls.Add(btnTask1);

            // Кнопка для Завдання 2
            btnTask2 = new Button();
            btnTask2.Text = "Виконати Завдання 2";
            btnTask2.Location = new Point(190, 20);
            btnTask2.Size = new Size(150, 40);
            btnTask2.Click += BtnTask2_Click;
            this.Controls.Add(btnTask2);

            // Текстове поле для виведення результатів
            txtOutput = new RichTextBox();
            txtOutput.Location = new Point(20, 80);
            txtOutput.Size = new Size(490, 310);
            txtOutput.ReadOnly = true;
            txtOutput.Font = new Font("Consolas", 11);
            this.Controls.Add(txtOutput);
        }

        private void BtnTask1_Click(object sender, EventArgs e)
        {
            double[] arr = { 4.5, -2.0, 7.1, -1.5, 3.2, 0.5, -4.3, 9.8, 1.1 };
            
            // Викликаємо логіку з окремого файлу
            Task1Logic task1 = new Task1Logic(arr);

            txtOutput.Clear();
            txtOutput.AppendText("=== ЗАВДАННЯ 1 (Одновимірний масив) ===\n");
            txtOutput.AppendText("Початковий масив: " + string.Join("; ", arr) + "\n\n");
            txtOutput.AppendText($"а) Сума від'ємних елементів: {task1.GetSumOfNegatives()}\n");
            txtOutput.AppendText($"б) Добуток елементів між min і max: {task1.GetProductBetweenMinMax()}\n\n");
            
            double[] sortedArr = task1.GetSortedArray();
            txtOutput.AppendText("Впорядкований масив: " + string.Join("; ", sortedArr) + "\n");
        }

        private void BtnTask2_Click(object sender, EventArgs e)
        {
            int[,] matrix = {
                { 11, 12, 13, 14 },
                { 21, 22, 23, 24 },
                { 31, 32, 33, 34 }
            };

            // Викликаємо логіку з окремого файлу
            Task2Logic task2 = new Task2Logic(matrix);

            txtOutput.Clear();
            txtOutput.AppendText("=== ЗАВДАННЯ 2 (Двовимірний масив) ===\n");
            txtOutput.AppendText("1) Масив:\n" + task2.GetMatrixAsString() + "\n");
            txtOutput.AppendText($"2) Елемент у правому верхньому куті: {task2.GetTopRightElement()}\n");
            txtOutput.AppendText($"3) Елемент у лівому нижньому куті: {task2.GetBottomLeftElement()}\n");
        }
    }
}