using System;
using System.IO;
using System.Windows.Forms;

namespace Lab_15
{
    public partial class SettingsForm : Form
    {
        // Файл для збереження налаштувань
        private string settingsFile = "settings.txt";

        public SettingsForm()
        {
            InitializeComponent();
            LoadSettings(); // При відкритті форми відразу вантажимо старі налаштування
        }

        private void LoadSettings()
        {
            // Якщо файл існує, читаємо з нього 3 рядки: хост, логін, пароль
            if (File.Exists(settingsFile))
            {
                string[] lines = File.ReadAllLines(settingsFile);
                if (lines.Length >= 3)
                {
                    txtHost.Text = lines[0];
                    txtUser.Text = lines[1];
                    txtPass.Text = lines[2];
                }
            }
            else
            {
                // Стандартні значення при першому запуску
                txtHost.Text = "ftp://192.168.178.70/"; //  IP-адреса!
                txtUser.Text = "admin"; //  логін з Xlight
                txtPass.Text = "1234";  //  пароль
            }
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            // Зберігаємо налаштування у текстовий файл
            string[] lines = { txtHost.Text, txtUser.Text, txtPass.Text };
            File.WriteAllLines(settingsFile, lines);

            MessageBox.Show("Налаштування успішно збережено!");
            this.Close(); // Закриваємо форму
        }
    }
}