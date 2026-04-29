using System;
using System.Management; // Обов'язково для роботи з WMI
using System.Windows.Forms;

namespace Lab_19
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Вибираємо перший елемент у списку за замовчуванням при запуску
            if (cmbHardwareType.Items.Count > 0)
                cmbHardwareType.SelectedIndex = 0;
        }

        // Головна кнопка "Отримати інформацію"
        private void btnGetInfo_Click(object sender, EventArgs e)
        {
            txtInfo.Clear();
            string choice = cmbHardwareType.SelectedItem?.ToString();

            if (choice == null) return;

            // Залежно від вибору в ComboBox, звертаємося до різних класів WMI
            switch (choice)
            {
                case "CPU":
                    FetchWmiInfo("Win32_Processor", new[] { "Name", "Manufacturer", "Description", "NumberOfCores", "NumberOfLogicalProcessors" });
                    break;
                case "GPU":
                    FetchWmiInfo("Win32_VideoController", new[] { "Name", "VideoProcessor", "DriverVersion", "AdapterRAM" });
                    break;
                case "HDD/SSD":
                    FetchWmiInfo("Win32_DiskDrive", new[] { "Caption", "Size", "InterfaceType", "Partitions" });
                    break;
                case "Motherboard":
                    FetchWmiInfo("Win32_BaseBoard", new[] { "Manufacturer", "Product", "SerialNumber" });
                    break;
                case "BIOS":
                    FetchWmiInfo("Win32_BIOS", new[] { "Manufacturer", "Name", "Version", "ReleaseDate" });
                    break;
                case "Network adapters":
                    FetchWmiInfo("Win32_NetworkAdapter", new[] { "Name", "MACAddress", "AdapterType", "NetConnectionStatus" });
                    break;
            }
        }

        // Універсальний метод для зчитування даних
        private void FetchWmiInfo(string wmiClass, string[] properties)
        {
            try
            {
                // Створюємо запит до WMI
                ManagementObjectSearcher searcher = new ManagementObjectSearcher($"SELECT * FROM {wmiClass}");
                int count = 1;

                foreach (ManagementObject obj in searcher.Get())
                {
                    // Пропускаємо порожні мережеві адаптери (віртуальні або вимкнені)
                    if (wmiClass == "Win32_NetworkAdapter" && obj["MACAddress"] == null)
                        continue;

                    txtInfo.AppendText($"=== Пристрій {count} ===\r\n");

                    foreach (string prop in properties)
                    {
                        try
                        {
                            object val = obj[prop];
                            string displayVal = val != null ? val.ToString().Trim() : "Немає даних";

                            // Якщо це об'єм пам'яті (в байтах), переводимо в Гігабайти для краси
                            if ((prop == "Size" || prop == "AdapterRAM") && val != null)
                            {
                                if (long.TryParse(val.ToString(), out long bytes))
                                {
                                    double gb = bytes / (1024.0 * 1024.0 * 1024.0);
                                    displayVal = $"{displayVal} байт ({Math.Round(gb, 2)} ГБ)";
                                }
                            }

                            txtInfo.AppendText($"{prop}: {displayVal}\r\n");
                        }
                        catch
                        {
                            // Якщо якась властивість не підтримується конкретним залізом, просто ігноруємо
                        }
                    }
                    txtInfo.AppendText("\r\n");
                    count++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка доступу до WMI:\n" + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}