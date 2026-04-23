using System;
using System.Threading;
using System.Windows.Forms;

// ВАЖНО: Проверь, чтобы название ниже СОВПАДАЛО с названием твоего проекта!
namespace Lab_10
{
    public partial class Form1 : Form
    {
        private Thread threadDES;
        private Thread threadSnefru;
        private Thread threadKnapsack;
        private bool isWork = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void RunDES()
        {
            while (isWork)
            {
                LogToUI("Потік 1: Виконується шифрування DES...");
                Thread.Sleep(1200);
            }
        }

        private void RunSnefru()
        {
            while (isWork)
            {
                LogToUI("Потік 2: Обчислення хешу Snefru...");
                Thread.Sleep(1800);
            }
        }

        private void RunKnapsack()
        {
            while (isWork)
            {
                LogToUI("Потік 3: Робота алгоритму Рюкзака...");
                Thread.Sleep(2500);
            }
        }

        private void LogToUI(string message)
        {
            if (listBoxLog.InvokeRequired)
            {
                listBoxLog.Invoke(new Action<string>(LogToUI), message);
            }
            else
            {
                listBoxLog.Items.Add($"{DateTime.Now.ToLongTimeString()}: {message}");
                listBoxLog.SelectedIndex = listBoxLog.Items.Count - 1;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (isWork) return;
            isWork = true;
            listBoxLog.Items.Clear();

            threadDES = new Thread(new ThreadStart(RunDES));
            threadSnefru = new Thread(new ThreadStart(RunSnefru));
            threadKnapsack = new Thread(new ThreadStart(RunKnapsack));

            threadDES.Start();
            threadSnefru.Start();
            threadKnapsack.Start();

            LogToUI("СИСТЕМА: Усі потоки успішно запущені.");
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            isWork = false;
            LogToUI("СИСТЕМА: Запит на зупинку потоків...");
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            isWork = false;
            base.OnFormClosing(e);
        }
    }
}