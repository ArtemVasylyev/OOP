using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.IO;

namespace Lab_16
{
    public partial class Form1 : Form
    {
        bool alive = false; 
        UdpClient client;

        
        int localPort = 8001;
        int remotePort = 8001;
        const int TTL = 20;
        string hostIp = "235.5.5.1";
        IPAddress groupAddress;
        string userName;

        public Form1()
        {
            InitializeComponent();
            loginButton.Enabled = true;
            logoutButton.Enabled = false;
            sendButton.Enabled = false;
            chatTextBox.ReadOnly = true;
        }

        
        private void LoadNetworkSettings()
        {
            if (File.Exists("chat_settings.txt"))
            {
                string[] lines = File.ReadAllLines("chat_settings.txt");
                if (lines.Length >= 2)
                {
                    hostIp = lines[0];
                    if (int.TryParse(lines[1], out int port))
                    {
                        localPort = port;
                        remotePort = port;
                    }
                }
            }
            groupAddress = IPAddress.Parse(hostIp);
        }

        
        private void loginButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(userNameTextBox.Text)) return;
            userName = userNameTextBox.Text;
            userNameTextBox.ReadOnly = true;

            try
            {
                LoadNetworkSettings(); 

                client = new UdpClient();
                client.ExclusiveAddressUse = false; 
                client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true); 
                client.Client.Bind(new IPEndPoint(IPAddress.Any, localPort));
                client.JoinMulticastGroup(groupAddress, TTL);

                
                Task receiveTask = new Task(ReceiveMessages);
                receiveTask.Start();

                
                string message = userName + " add to chat";
                byte[] data = Encoding.Unicode.GetBytes(message);
                client.Send(data, data.Length, hostIp, remotePort);

                loginButton.Enabled = false;
                logoutButton.Enabled = true;
                sendButton.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
        private void ReceiveMessages()
        {
            alive = true;
            try
            {
                while (alive)
                {
                    IPEndPoint remoteIp = null;
                    byte[] data = client.Receive(ref remoteIp);
                    string message = Encoding.Unicode.GetString(data);

                    this.Invoke(new MethodInvoker(() =>
                    {
                        string time = DateTime.Now.ToShortTimeString();
                        chatTextBox.Text = time + " " + message + "\r\n" + chatTextBox.Text;
                    }));
                }
            }
            catch (ObjectDisposedException) { if (!alive) return; throw; }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        
        private void sendButton_Click(object sender, EventArgs e)
        {
            try
            {
                string message = String.Format("{0}: {1}", userName, messageTextBox.Text);
                byte[] data = Encoding.Unicode.GetBytes(message);
                client.Send(data, data.Length, hostIp, remotePort);
                messageTextBox.Clear();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        
        private void logoutButton_Click(object sender, EventArgs e)
        {
            ExitChat();
        }

        private void ExitChat()
        {
            if (!alive) return;
            string message = userName + " leav chat";
            byte[] data = Encoding.Unicode.GetBytes(message);
            client.Send(data, data.Length, hostIp, remotePort);
            client.DropMulticastGroup(groupAddress);
            alive = false;
            client.Close();

            loginButton.Enabled = true;
            logoutButton.Enabled = false;
            sendButton.Enabled = false;
            userNameTextBox.ReadOnly = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (alive) ExitChat();
        }

        
        private void btnSettings_Click(object sender, EventArgs e)
        {
            SettingsForm settings = new SettingsForm();
            settings.ShowDialog();
        }

        
        private void btnFont_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                chatTextBox.Font = fontDialog1.Font;
                messageTextBox.Font = fontDialog1.Font;
            }
        }

        
        private void btnSaveLog_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text files (*.txt)|*.txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, chatTextBox.Text);
                MessageBox.Show("Chat history successfully saved!");
            }
        }
    }
}