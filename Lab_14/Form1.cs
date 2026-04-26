using System;
using System.IO;
using System.IO.Compression; 
using System.Drawing;
using System.Security.AccessControl; 
using System.Windows.Forms;

namespace Lab_14
{
    public partial class Form1 : Form
    {
        private string currentPath = "";
        private string selectedItemPath = "";
        private bool isSelectedFile = false;

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
                if (drive.IsReady) comboBoxDrives.Items.Add(drive.Name);
            }
            if (comboBoxDrives.Items.Count > 0) comboBoxDrives.SelectedIndex = 0;
        }

        private void comboBoxDrives_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentPath = comboBoxDrives.SelectedItem.ToString();
            LoadDirectory(currentPath);
        }

        private void LoadDirectory(string path, string filter = "*")
        {
            try
            {
                listBoxFolders.Items.Clear();
                listBoxFiles.Items.Clear();
                if (path.Length > 3) listBoxFolders.Items.Add(".. [НАЗАД]");

                DirectoryInfo dir = new DirectoryInfo(path);

                foreach (DirectoryInfo d in dir.GetDirectories(filter)) listBoxFolders.Items.Add(d.Name);
                foreach (FileInfo f in dir.GetFiles(filter)) listBoxFiles.Items.Add(f.Name);

                selectedItemPath = "";
            }
            catch (Exception ex) { MessageBox.Show("Помилка: " + ex.Message); }
        }

        private void listBoxFolders_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxFolders.SelectedItem == null) return;
            string selected = listBoxFolders.SelectedItem.ToString();
            currentPath = (selected == ".. [НАЗАД]") ? Directory.GetParent(currentPath).FullName : Path.Combine(currentPath, selected);
            LoadDirectory(currentPath);
        }

        private void listBoxFolders_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxFolders.SelectedItem == null || listBoxFolders.SelectedItem.ToString().Contains("[НАЗАД]")) return;
            selectedItemPath = Path.Combine(currentPath, listBoxFolders.SelectedItem.ToString());
            isSelectedFile = false;
            ReadAttributes(selectedItemPath);
        }

        private void listBoxFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxFiles.SelectedItem == null) return;
            selectedItemPath = Path.Combine(currentPath, listBoxFiles.SelectedItem.ToString());
            isSelectedFile = true;

            ReadAttributes(selectedItemPath);

            string ext = Path.GetExtension(selectedItemPath).ToLower();
            if (ext == ".txt" || ext == ".log" || ext == ".cs")
                rtbProperties.Text = File.ReadAllText(selectedItemPath);
            else if (ext == ".jpg" || ext == ".png" || ext == ".bmp")
                pictureBox1.Image = Image.FromFile(selectedItemPath);
        }



        private void створитиПапкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtInput.Text)) { MessageBox.Show("Введіть назву в txtInput!"); return; }
            string newPath = Path.Combine(currentPath, txtInput.Text);
            if (!Directory.Exists(newPath)) Directory.CreateDirectory(newPath); //
            LoadDirectory(currentPath);
        }

        private void створитиФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtInput.Text)) { MessageBox.Show("Введіть назву в txtInput!"); return; }
            string newPath = Path.Combine(currentPath, txtInput.Text);
            if (!File.Exists(newPath)) File.Create(newPath).Close(); //
            LoadDirectory(currentPath);
        }

        private void копіюватиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedItemPath) || string.IsNullOrWhiteSpace(txtInput.Text)) { MessageBox.Show("Виберіть файл та введіть нове ім'я в txtInput!"); return; }
            string targetPath = Path.Combine(currentPath, txtInput.Text);
            if (isSelectedFile) File.Copy(selectedItemPath, targetPath, true); //
            LoadDirectory(currentPath);
        }

        private void переміститиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PerformMoveOrRename(); 
        }

        private void перейменуватиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PerformMoveOrRename();
        }

        private void PerformMoveOrRename()
        {
            if (string.IsNullOrEmpty(selectedItemPath) || string.IsNullOrWhiteSpace(txtInput.Text)) { MessageBox.Show("Виберіть файл/папку та введіть нову назву в txtInput!"); return; }
            string targetPath = Path.Combine(currentPath, txtInput.Text);

            if (isSelectedFile) File.Move(selectedItemPath, targetPath); 
            else Directory.Move(selectedItemPath, targetPath); 

            LoadDirectory(currentPath);
        }

        private void видалитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedItemPath)) return;
            if (MessageBox.Show("Видалити об'єкт?", "Підтвердження", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (isSelectedFile) File.Delete(selectedItemPath); 
                else Directory.Delete(selectedItemPath, true); 
                LoadDirectory(currentPath);
            }
        }

        private void вАрхівZIPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isSelectedFile && !string.IsNullOrEmpty(selectedItemPath))
            {
                ZipFile.CreateFromDirectory(selectedItemPath, selectedItemPath + ".zip"); 
                MessageBox.Show("Архів створено!");
                LoadDirectory(currentPath);
            }
            else { MessageBox.Show("Виберіть ПАПКУ для архівації."); }
        }

        private void розпакуватиZIPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isSelectedFile && selectedItemPath.EndsWith(".zip"))
            {
                ZipFile.ExtractToDirectory(selectedItemPath, selectedItemPath.Replace(".zip", "_extracted")); 
                MessageBox.Show("Архів розпаковано!");
                LoadDirectory(currentPath);
            }
            else { MessageBox.Show("Виберіть ZIP-файл для розпакування."); }
        }



        private void ReadAttributes(string path)
        {
            FileAttributes attr = File.GetAttributes(path);
            chkReadOnly.Checked = (attr & FileAttributes.ReadOnly) == FileAttributes.ReadOnly;
            chkHidden.Checked = (attr & FileAttributes.Hidden) == FileAttributes.Hidden;
        }

        private void btnApplyAttributes_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedItemPath)) return;
            FileAttributes attr = File.GetAttributes(selectedItemPath);
            if (chkReadOnly.Checked) attr |= FileAttributes.ReadOnly; else attr &= ~FileAttributes.ReadOnly;
            if (chkHidden.Checked) attr |= FileAttributes.Hidden; else attr &= ~FileAttributes.Hidden;
            File.SetAttributes(selectedItemPath, attr); 
            MessageBox.Show("Атрибути оновлено");
        }

        private void btnSaveText_Click(object sender, EventArgs e)
        {
            if (isSelectedFile)
            {
                File.WriteAllText(selectedItemPath, rtbProperties.Text); 
                MessageBox.Show("Текст збережено!");
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            LoadDirectory(currentPath, string.IsNullOrWhiteSpace(txtFilter.Text) ? "*" : txtFilter.Text);
        }
    }
}