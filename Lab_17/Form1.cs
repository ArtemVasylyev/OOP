using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Lab_17
{

    public partial class Form1 : Form
    {
        ServerObject server;
        Thread listenThread;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                server = new ServerObject(this); 
                listenThread = new Thread(new ThreadStart(server.Listen));
                listenThread.IsBackground = true; 
                listenThread.Start();

                btnStart.Enabled = false;
                btnStop.Enabled = true;
                if (lblStatus != null) lblStatus.Text = "Статус: Сервер працює (Порт 8888)";
            }
            catch (Exception ex)
            {
                server.Disconnect();
                LogMessage("Помилка запуску: " + ex.Message);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (server != null)
            {
                server.Disconnect();
            }
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            if (lblStatus != null) lblStatus.Text = "Статус: Сервер зупинено";
            LogMessage("Сервер зупинено.");
        }


        public void LogMessage(string message)
        {
            if (txtLog.InvokeRequired)
            {
                txtLog.Invoke(new Action<string>(LogMessage), message);
            }
            else
            {
                string time = DateTime.Now.ToShortTimeString();
                txtLog.AppendText($"{time}: {message}\r\n");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (server != null)
                server.Disconnect();
        }
    }


    public class ServerObject
    {
        static TcpListener tcpListener; 
        List<ClientObject> clients = new List<ClientObject>(); 
        Form1 mainForm;

        public ServerObject(Form1 form)
        {
            mainForm = form;
        }

        protected internal void AddConnection(ClientObject clientObject)
        {
            clients.Add(clientObject);
        }

        protected internal void RemoveConnection(string id)
        {
            ClientObject client = clients.FirstOrDefault(c => c.Id == id);
            if (client != null)
                clients.Remove(client);
        }


        protected internal void Listen()
        {
            try
            {
                tcpListener = new TcpListener(IPAddress.Any, 8888);
                tcpListener.Start();
                mainForm.LogMessage("The server is running. Waiting for connections...");

                while (true)
                {
                    TcpClient tcpClient = tcpListener.AcceptTcpClient();
                    ClientObject clientObject = new ClientObject(tcpClient, this, mainForm);
                    Thread clientThread = new Thread(new ThreadStart(clientObject.Process));
                    clientThread.IsBackground = true;
                    clientThread.Start();
                }
            }
            catch (Exception ex)
            {
                mainForm.LogMessage(ex.Message);
                Disconnect();
            }
        }


        protected internal void BroadcastMessage(string message, string id)
        {
            byte[] data = Encoding.Unicode.GetBytes(message);
            for (int i = 0; i < clients.Count; i++)
            {
                if (clients[i].Id != id) 
                {
                    clients[i].Stream.Write(data, 0, data.Length);
                }
            }
        }

        protected internal void Disconnect()
        {
            tcpListener?.Stop();
            for (int i = 0; i < clients.Count; i++)
            {
                clients[i].Close();
            }
        }
    }

    public class ClientObject
    {
        protected internal string Id { get; private set; }
        protected internal NetworkStream Stream { get; private set; }
        string userName;
        TcpClient client;
        ServerObject server;
        Form1 mainForm;

        public ClientObject(TcpClient tcpClient, ServerObject serverObject, Form1 form)
        {
            Id = Guid.NewGuid().ToString();
            client = tcpClient;
            server = serverObject;
            mainForm = form;
            serverObject.AddConnection(this);
        }

        public void Process()
        {
            try
            {
                Stream = client.GetStream();
                string message = GetMessage();
                userName = message;

                message = userName + " add to chat";
                server.BroadcastMessage(message, this.Id);
                mainForm.LogMessage(message); 

                while (true)
                {
                    try
                    {
                        message = GetMessage();
                        message = String.Format("{0}: {1}", userName, message);
                        mainForm.LogMessage(message);
                        server.BroadcastMessage(message, this.Id);
                    }
                    catch
                    {
                        message = String.Format("{0}: leave chat", userName);
                        mainForm.LogMessage(message);
                        server.BroadcastMessage(message, this.Id);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                mainForm.LogMessage(e.Message);
            }
            finally
            {
                server.RemoveConnection(this.Id);
                Close();
            }
        }


        private string GetMessage()
        {
            byte[] data = new byte[64];
            StringBuilder builder = new StringBuilder();
            int bytes = 0;
            do
            {
                bytes = Stream.Read(data, 0, data.Length);
                if (bytes == 0)
                {
                    throw new Exception("Disconect");
                }
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            }
            while (Stream.DataAvailable);

            return builder.ToString();
        }

        protected internal void Close()
        {
            if (Stream != null) Stream.Close();
            if (client != null) client.Close();
        }
    }
}