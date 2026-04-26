using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Lab_15
{
    public partial class Form1 : Form
    {
        private string host, user, pass;

        public Form1()
        {
            InitializeComponent();
        }

        private bool LoadSettings()
        {
            if (File.Exists("settings.txt"))
            {
                string[] lines = File.ReadAllLines("settings.txt");
                if (lines.Length >= 3)
                {
                    host = lines[0]; user = lines[1]; pass = lines[2];
                    if (!host.EndsWith("/")) host += "/";
                    return true;
                }
            }
            MessageBox.Show("Спочатку збережіть налаштування!", "Увага");
            return false;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            SettingsForm settings = new SettingsForm();
            settings.ShowDialog(); 
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (!LoadSettings()) return;

            treeViewFTP.Nodes.Clear();
            TreeNode root = new TreeNode("FTP Server");
            root.Tag = host; 
            treeViewFTP.Nodes.Add(root);

            LoadFtpDirectory(host, root);
            root.Expand();
        }

        private void LoadFtpDirectory(string url, TreeNode parentNode)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url);
                request.Credentials = new NetworkCredential(user, pass);
                request.Method = WebRequestMethods.Ftp.ListDirectoryDetails; 

                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {

                        string[] tokens = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        string name = tokens[tokens.Length - 1];
                        if (name == "." || name == "..") continue;

                        bool isDir = line.StartsWith("d") || line.Contains("<DIR>");

                        TreeNode node = new TreeNode(name);
                        node.Tag = url + name + (isDir ? "/" : "");

                        if (isDir) node.Nodes.Add("..."); 

                        parentNode.Nodes.Add(node);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Помилка: " + ex.Message); }
        }


        private void treeViewFTP_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes.Count == 1 && e.Node.Nodes[0].Text == "...")
            {
                e.Node.Nodes.Clear();
                LoadFtpDirectory(e.Node.Tag.ToString(), e.Node);
            }
        }


        private void treeViewFTP_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right) treeViewFTP.SelectedNode = e.Node;
        }



        private void створитиПапкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeViewFTP.SelectedNode == null || string.IsNullOrWhiteSpace(txtInput.Text)) return;
            string targetUrl = treeViewFTP.SelectedNode.Tag.ToString() + txtInput.Text;
            ExecuteFtpCommand(targetUrl, WebRequestMethods.Ftp.MakeDirectory); 
            MessageBox.Show("Папку створено. Оновіть гілку.");
        }

        private void видалитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeViewFTP.SelectedNode == null) return;
            string targetUrl = treeViewFTP.SelectedNode.Tag.ToString();
            string method = targetUrl.EndsWith("/") ? WebRequestMethods.Ftp.RemoveDirectory : WebRequestMethods.Ftp.DeleteFile; 
            ExecuteFtpCommand(targetUrl, method);
            treeViewFTP.SelectedNode.Remove();
        }

        private void перейменуватиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeViewFTP.SelectedNode == null || string.IsNullOrWhiteSpace(txtInput.Text)) return;
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(treeViewFTP.SelectedNode.Tag.ToString());
                request.Credentials = new NetworkCredential(user, pass);
                request.Method = WebRequestMethods.Ftp.Rename; 
                request.RenameTo = txtInput.Text;
                request.GetResponse().Close();
                MessageBox.Show("Перейменовано. Оновіть підключення.");
            }
            catch (Exception ex) { MessageBox.Show("Помилка: " + ex.Message); }
        }

        private void завантажитиФайлНаСерверUploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeViewFTP.SelectedNode == null || !treeViewFTP.SelectedNode.Tag.ToString().EndsWith("/")) { MessageBox.Show("Виберіть папку!"); return; }
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string targetUrl = treeViewFTP.SelectedNode.Tag.ToString() + Path.GetFileName(openFileDialog1.FileName);
                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(targetUrl);
                    request.Credentials = new NetworkCredential(user, pass);
                    request.Method = WebRequestMethods.Ftp.UploadFile; 

                    byte[] fileContents = File.ReadAllBytes(openFileDialog1.FileName);
                    using (Stream requestStream = request.GetRequestStream())
                    {
                        requestStream.Write(fileContents, 0, fileContents.Length);
                    }
                    MessageBox.Show("Завантажено успішно!");
                }
                catch (Exception ex) { MessageBox.Show("Помилка: " + ex.Message); }
            }
        }

        private void скачатиФайлDownloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeViewFTP.SelectedNode == null || treeViewFTP.SelectedNode.Tag.ToString().EndsWith("/")) { MessageBox.Show("Виберіть файл!"); return; }
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.FileName = treeViewFTP.SelectedNode.Text;
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(treeViewFTP.SelectedNode.Tag.ToString());
                    request.Credentials = new NetworkCredential(user, pass);
                    request.Method = WebRequestMethods.Ftp.DownloadFile; 

                    using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                    using (Stream responseStream = response.GetResponseStream())
                    using (FileStream fileStream = new FileStream(saveDialog.FileName, FileMode.Create))
                    {
                        responseStream.CopyTo(fileStream);
                    }
                    MessageBox.Show("Скачано успішно!");
                }
                catch (Exception ex) { MessageBox.Show("Помилка: " + ex.Message); }
            }
        }


        private void ExecuteFtpCommand(string url, string method)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url);
                request.Credentials = new NetworkCredential(user, pass);
                request.Method = method;
                request.GetResponse().Close();
            }
            catch (Exception ex) { MessageBox.Show("Помилка: " + ex.Message); }
        }
    }
}