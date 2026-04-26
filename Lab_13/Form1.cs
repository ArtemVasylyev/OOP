using System;
using System.IO;
using System.Security.AccessControl;
using System.Drawing;
using System.Windows.Forms;

namespace Lab_13
{
    public partial class Form1 : Form
    {
        private string currentPath = "";

        public Form1()
        {
            InitializeComponent();
            LoadDrives();
        }

        private void LoadDrives()
        {
            comboBoxDrives.Items.Clear();
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady)
                {
                    comboBoxDrives.Items.Add(drive.Name);
                }
            }
            if (comboBoxDrives.Items.Count > 0)
            {
                comboBoxDrives.SelectedIndex = 0;
            }
        }

        private void comboBoxDrives_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentPath = comboBoxDrives.SelectedItem.ToString();
            LoadDirectory(currentPath);
            ShowDriveProperties(currentPath);
        }

        private void LoadDirectory(string path, string filter = "*")
        {
            try
            {
                listBoxFolders.Items.Clear();
                listBoxFiles.Items.Clear();

                if (path.Length > 3)
                {
                    listBoxFolders.Items.Add(".. [НАЗАД]");
                }

                DirectoryInfo dir = new DirectoryInfo(path);

                foreach (DirectoryInfo d in dir.GetDirectories(filter))
                {
                    listBoxFolders.Items.Add(d.Name);
                }

                foreach (FileInfo f in dir.GetFiles(filter))
                {
                    listBoxFiles.Items.Add(f.Name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка доступу: " + ex.Message);
            }
        }

        private void listBoxFolders_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxFolders.SelectedItem == null) return;

            string selected = listBoxFolders.SelectedItem.ToString();

            if (selected == ".. [НАЗАД]")
            {
                currentPath = Directory.GetParent(currentPath).FullName;
            }
            else
            {
                currentPath = Path.Combine(currentPath, selected);
            }

            LoadDirectory(currentPath);
        }

        private void listBoxFolders_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxFolders.SelectedItem == null || listBoxFolders.SelectedItem.ToString() == ".. [НАЗАД]") return;

            string folderPath = Path.Combine(currentPath, listBoxFolders.SelectedItem.ToString());
            DirectoryInfo dirInfo = new DirectoryInfo(folderPath);

            rtbProperties.Text = "=== ВЛАСТИВОСТІ КАТАЛОГУ ===\n";
            rtbProperties.Text += $"Назва: {dirInfo.Name}\n";
            rtbProperties.Text += $"Шлях: {dirInfo.FullName}\n";
            rtbProperties.Text += $"Створено: {dirInfo.CreationTime}\n";

            ShowSecurityAttributes(folderPath, false);
        }

        private void listBoxFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxFiles.SelectedItem == null) return;

            string filePath = Path.Combine(currentPath, listBoxFiles.SelectedItem.ToString());
            FileInfo fileInfo = new FileInfo(filePath);

            rtbProperties.Text = "=== ВЛАСТИВОСТІ ФАЙЛУ ===\n";
            rtbProperties.Text += $"Назва: {fileInfo.Name}\n";
            rtbProperties.Text += $"Розмір: {fileInfo.Length} байт\n";
            rtbProperties.Text += $"Створено: {fileInfo.CreationTime}\n";

            ShowSecurityAttributes(filePath, true);

            pictureBox1.Image = null;
            string ext = fileInfo.Extension.ToLower();

            try
            {
                if (ext == ".txt" || ext == ".log" || ext == ".cs")
                {
                    rtbProperties.Text += "\n=== ВМІСТ ===\n" + File.ReadAllText(filePath);
                }
                else if (ext == ".jpg" || ext == ".png" || ext == ".bmp")
                {
                    pictureBox1.Image = Image.FromFile(filePath);
                }
            }
            catch { }
        }

        private void ShowDriveProperties(string driveName)
        {
            DriveInfo drive = new DriveInfo(driveName);
            rtbProperties.Text = "=== ВЛАСТИВОСТІ ДИСКА ===\n";
            rtbProperties.Text += $"Назва: {drive.Name}\n";
            rtbProperties.Text += $"Тип: {drive.DriveType}\n";
            rtbProperties.Text += $"Формат: {drive.DriveFormat}\n";
            rtbProperties.Text += $"Вільний простір: {drive.TotalFreeSpace / (1024 * 1024 * 1024)} ГБ\n";
        }

        private void ShowSecurityAttributes(string path, bool isFile)
        {
            try
            {
                rtbProperties.Text += "\n=== ДОСТУП ===\n";
                AuthorizationRuleCollection rules;

                if (isFile)
                {
                    rules = File.GetAccessControl(path).GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount));
                }
                else
                {
                    rules = Directory.GetAccessControl(path).GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount));
                }

                foreach (FileSystemAccessRule rule in rules)
                {
                    rtbProperties.Text += $"{rule.IdentityReference}: {rule.FileSystemRights}\n";
                }
            }
            catch { }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string filter = string.IsNullOrWhiteSpace(txtFilter.Text) ? "*" : txtFilter.Text;
            LoadDirectory(currentPath, filter);
        }
    }
}