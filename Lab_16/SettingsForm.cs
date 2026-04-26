using System;
using System.IO;
using System.Windows.Forms;

namespace Lab_16
{
    public partial class SettingsForm : Form
    {
        private string settingsFile = "chat_settings.txt";

        public SettingsForm()
        {
            InitializeComponent();
            LoadSettings();
        }

        private void LoadSettings()
        {
            if (File.Exists(settingsFile))
            {
                string[] lines = File.ReadAllLines(settingsFile);
                if (lines.Length >= 2)
                {
                    txtIP.Text = lines[0];
                    txtPort.Text = lines[1];
                }
            }
            else
            {

                txtIP.Text = "235.5.5.1";
                txtPort.Text = "8001";
            }
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            
            string[] lines = { txtIP.Text, txtPort.Text };
            File.WriteAllLines(settingsFile, lines);
            MessageBox.Show("Настройки сохранены!");
            this.Close();
        }
    }
}