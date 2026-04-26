using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Lab_17_Client
{
    public partial class Form1 : Form
    {
        string userName;
        int port = 8888; 
        TcpClient client;
        NetworkStream stream;
        Thread receiveThread;

        public Form1()
        {
            InitializeComponent();
        }


        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserName.Text) || string.IsNullOrWhiteSpace(txtIP.Text))
            {
                MessageBox.Show("Enter IP-address and Name of user to connect");
                return;
            }

            userName = txtUserName.Text;
            string host = txtIP.Text;

            client = new TcpClient();
            try
            {
                client.Connect(host, port); 
                stream = client.GetStream(); 

                
                string message = userName;
                byte[] data = Encoding.Unicode.GetBytes(message);
                stream.Write(data, 0, data.Length);

                
                receiveThread = new Thread(new ThreadStart(ReceiveMessage));
                receiveThread.IsBackground = true; 
                receiveThread.Start();

                
                txtChat.AppendText($"You successfully connect as {userName}\r\n");
                btnConnect.Enabled = false;
                btnDisconnect.Enabled = true;
                btnSend.Enabled = true;
                txtIP.ReadOnly = true;
                txtUserName.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connect error " + ex.Message);
            }
        }


        private void btnSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMessage.Text)) return;

            try
            {
                string message = txtMessage.Text;
                byte[] data = Encoding.Unicode.GetBytes(message);
                stream.Write(data, 0, data.Length);
                txtChat.AppendText("You: " + message + "\r\n");
                txtMessage.Clear(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Send error: " + ex.Message);
            }
        }


        private void ReceiveMessage()
        {
            while (true)
            {
                try
                {
                    byte[] data = new byte[64]; 
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;

                    do
                    {
                        bytes = stream.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (stream.DataAvailable);

                    string message = builder.ToString();

                    Invoke(new Action(() => {
                        txtChat.AppendText(message + "\r\n");
                    }));
                }
                catch
                {
                    Invoke(new Action(() => {
                        txtChat.AppendText("The connection to the server has been lost!\r\n");
                        Disconnect();
                    }));
                    break;
                }
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            Disconnect();
        }

        private void Disconnect()
        {
            if (stream != null) stream.Close(); 
            if (client != null) client.Close(); 


            btnConnect.Enabled = true;
            btnDisconnect.Enabled = false;
            btnSend.Enabled = false;
            txtIP.ReadOnly = false;
            txtUserName.ReadOnly = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Disconnect();
        }
    }
}