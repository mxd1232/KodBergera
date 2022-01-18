using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Server
{
    public partial class Server : Form
    {
        private TcpListener listener;
        private TcpClient client;
        public StreamReader STR;
        public StreamWriter STW;
        public string recieve;
        public String TextToSend;
        public int Port { get; set; }

        public Server(int port)
        {
            Port = port;
            InitializeComponent();

            IPLabel.Text = "Ip: " + Addresses.IpAddress;
            PortLabel.Text = "Port: " + port;

            foreach (var connection in Addresses.GetConnections(Port))
            {
                Connections.Items.Add(connection);
            }

            List<List<int>> AllPaths = Addresses.FindAllPaths(Port, 8);
            List<int> shortestPath = Addresses.FindShortestPath(Port, 8);

            StartListening();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private async void StartListening()
        {
            try
            {
                lblStatus.Text = "starting"; 
                listener = new TcpListener(IPAddress.Parse(Addresses.IpAddress), Port);
                listener.Start();
                client = await listener.AcceptTcpClientAsync();
                STR = new StreamReader(client.GetStream());
                STW = new StreamWriter(client.GetStream());
                STW.AutoFlush = true;

                backgroundWorker1.RunWorkerAsync();
                backgroundWorker2.WorkerSupportsCancellation = true;
                lblStatus.Text = "";
                txtLogs.Text += "";
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error";
                txtLogs.Text += "Server could not connect\n>>>" + ex.Message.ToString() + "\n";
            }
        }

        private void SendMessage(int port)
        {
            client = new TcpClient();
            IPEndPoint IpEnd = new IPEndPoint(IPAddress.Parse(Addresses.IpAddress), port);

            try
            {
                client.Connect(IpEnd);

                if (client.Connected)
                {
                    txtLogs.AppendText("" + "\n");
                    STW = new StreamWriter(client.GetStream());
                    STR = new StreamReader(client.GetStream());
                    STW.AutoFlush = true;
                    backgroundWorker1.RunWorkerAsync();
                    backgroundWorker2.WorkerSupportsCancellation = true;
                    txtLogs.Text += "";
                    lblStatus.Text = "";

                }
                else
                {
                    txtLogs.Text += "Client did not connect\n";
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error";
                txtLogs.Text += "Client could not connect\n>>>" + ex.Message.ToString() + "\n";
            }
        }

        private void StopConnection()
        {
            try
            {
               // TcpListener listener = new TcpListener(IPAddress.Parse(Addresses.IpAddress), Port);
                listener.Stop();
                client = listener.AcceptTcpClient();
                STR = new StreamReader(client.GetStream());
                STW = new StreamWriter(client.GetStream());
                STW.AutoFlush = false;

                backgroundWorker1.CancelAsync();
                backgroundWorker2.WorkerSupportsCancellation = false;
                txtLogs.Text += "";
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error";
                txtLogs.Text += "Server could not disconnect\n>>>" + ex.Message.ToString() + "\n";

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            backgroundWorker2.RunWorkerAsync();
            //backgroundWorker2.WorkerSupportsCancellation = true;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtMSG.Text != "" && txtPort.Text != "")
            {
                int destinationPort = Convert.ToInt32(txtPort.Text);
                if (destinationPort > 0 && destinationPort < 9)
                {
                    SendMessage(destinationPort);
                    TextToSend = txtMSG.Text;
                    backgroundWorker2.RunWorkerAsync();

                    backgroundWorker2.CancelAsync();
                }

            }
            txtMSG.Text = "";
        }


        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            if (client.Connected)
            {
                STW.WriteLine(TextToSend);
                this.txtLogs.Invoke(new MethodInvoker(delegate ()
                {
                    txtLogs.AppendText(TextToSend + "\n");
                    lblStatus.Text = "connected - sent";
                }));
            }
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (client.Connected)
            {
                try
                {
                    recieve = STR.ReadLine();
                    this.txtLogs.Invoke(new MethodInvoker(delegate ()
                    {
                        txtLogs.AppendText(recieve + "\n");
                        lblStatus.Text = "connected";
                    }));
                    recieve = "";
                }
                catch (Exception ex)
                {
                    lblStatus.Text = "Error";
                    txtLogs.Text += "Server could not connect\n>>>" + ex.Message.ToString() + "\n";
                }
            }
        }
    }
}
