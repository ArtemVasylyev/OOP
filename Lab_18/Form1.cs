using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Text;

namespace Lab_18
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetupGrid();
            LoadProcesses();
        }


        private void SetupGrid()
        {
            dgvProcesses.ColumnCount = 3;
            dgvProcesses.Columns[0].Name = "ID Процесу";
            dgvProcesses.Columns[1].Name = "Назва (ProcessName)";
            dgvProcesses.Columns[2].Name = "Віртуальна пам'ять (МБ)";
            dgvProcesses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        private void LoadProcesses()
        {
            dgvProcesses.Rows.Clear();
            Process[] processes = Process.GetProcesses(); 

            foreach (Process p in processes)
            {
                try
                {
                    
                    long memoryMB = p.VirtualMemorySize64 / (1024 * 1024);
                    dgvProcesses.Rows.Add(p.Id, p.ProcessName, memoryMB);
                }
                catch
                {
                    
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadProcesses();
        }


        private Process GetSelectedProcess()
        {
            if (dgvProcesses.SelectedRows.Count == 0) return null;

            int id = Convert.ToInt32(dgvProcesses.SelectedRows[0].Cells[0].Value);
            return Process.GetProcessById(id); 
        }


        private void menuInfo_Click(object sender, EventArgs e)
        {
            try
            {
                Process p = GetSelectedProcess();
                if (p != null)
                {
                    string info = $"ID: {p.Id}\n" +
                                  $"Ім'я: {p.ProcessName}\n" +
                                  $"Час запуску: {p.StartTime}\n" +
                                  $"Основний модуль: {p.MainModule.FileName}";
                    MessageBox.Show(info, "Інформація про процес", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Немає доступу до інформації цього процесу:\n" + ex.Message, "Помилка доступу");
            }
        }


        private void menuThreads_Click(object sender, EventArgs e)
        {
            try
            {
                Process p = GetSelectedProcess();
                if (p == null) return;

                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"--- ПОТОКИ ({p.Threads.Count} шт.) ---");


                int threadCount = Math.Min(5, p.Threads.Count);
                for (int i = 0; i < threadCount; i++)
                {
                    ProcessThread thread = p.Threads[i];
                    sb.AppendLine($"Потік ID: {thread.Id}, Пріоритет: {thread.CurrentPriority}");
                }

                sb.AppendLine("\n--- МОДУЛІ ---");

                int moduleCount = Math.Min(5, p.Modules.Count);
                for (int i = 0; i < moduleCount; i++)
                {
                    ProcessModule module = p.Modules[i];
                    sb.AppendLine($"Модуль: {module.ModuleName}");
                }

                MessageBox.Show(sb.ToString(), "Потоки та модулі " + p.ProcessName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Немає доступу до потоків/модулів:\n" + ex.Message, "Помилка доступу");
            }
        }


        private void menuKill_Click(object sender, EventArgs e)
        {
            try
            {
                Process p = GetSelectedProcess();
                if (p != null)
                {
                    DialogResult res = MessageBox.Show($"Ти дійсно хочеш завершити процес {p.ProcessName}?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (res == DialogResult.Yes)
                    {
                        p.Kill(); 
                        MessageBox.Show("Процес успішно завершено.");
                        LoadProcesses(); 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не вдалося зупинити процес (можливо він системний):\n" + ex.Message, "Помилка");
            }
        }


        private void btnExport_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Текстовий файл (*.txt)|*.txt";
            saveFileDialog1.FileName = "ProcessesLog.txt";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                {
                    sw.WriteLine($"Список процесів на {DateTime.Now}");
                    sw.WriteLine("ID\tНазва процесу\tПам'ять (МБ)");
                    sw.WriteLine("--------------------------------------------------");

                    foreach (DataGridViewRow row in dgvProcesses.Rows)
                    {
                        if (row.Cells[0].Value != null)
                        {
                            sw.WriteLine($"{row.Cells[0].Value}\t{row.Cells[1].Value}\t{row.Cells[2].Value}");
                        }
                    }
                }
                MessageBox.Show("Список процесів успішно збережено!");
            }
        }
    }
}