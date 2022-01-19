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
using BergerBackend;

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
                txtLogs.Text += "Server could not connect>>>"+ Environment.NewLine + ex.Message.ToString() + Environment.NewLine;
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
                    txtLogs.AppendText("" + Environment.NewLine );
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
                    txtLogs.Text += "Client did not connect" + Environment.NewLine;
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error";
                txtLogs.Text += "Client could not connect>>>"+ Environment.NewLine + ex.Message.ToString() + Environment.NewLine;
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
                txtLogs.Text += "Server could not disconnect>>>" + Environment.NewLine + ex.Message.ToString() + Environment.NewLine;

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
                    txtLogs.AppendText(TextToSend + Environment.NewLine);
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
                        txtLogs.AppendText(recieve + Environment.NewLine);
                        lblStatus.Text = "connected";
                    }));
                    recieve = "";
                }
                catch (Exception ex)
                {
                    lblStatus.Text = "Error";
                    txtLogs.Text += "Server could not connect>>>" + Environment.NewLine + ex.Message.ToString() + Environment.NewLine;
                }
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            Int16.TryParse(convertableNumberBox.Text, out short result);

            if (result != null)
            {
               // int[] binary = BergerHelper.ConvertShortToBinary(result);

                int[] berger = BergerHelper.CodeBerger(result);

                string bergerText = BergerHelper.GetBergerString(berger);

                txtMSG.Text = bergerText;

            }

        }

        private void btnNegateOneBit_Click(object sender, EventArgs e)
        {
            string bits = txtMSG.Text;
            if (IsProperBinaryNumber(bits) == false)
            {
                txtLogs.Text += "not a proper message" + Environment.NewLine;
                return;
            }
            
            txtMSG.Text = NegateBit(bits,FindRandomBitPlace());

        }

        private string NegateBit(string bits,int bitPlace)
        {

            char bitToNegate = bits[bitPlace];

            StringBuilder bitsModifiable = new StringBuilder(bits);

            if (bitToNegate == '0')
            {

                bitsModifiable[bitPlace] = '1';
            }
            else if(bitToNegate =='1')
            {

                bitsModifiable[bitPlace] = '0';
            }
            else
            {
                throw new ArgumentException();
            }

            return bitsModifiable.ToString();
        }

        private bool IsProperBinaryNumber(string bits)
        {
            if (bits.Length != 20)
            {
                return false;
            }

            foreach (var bit in bits)
            {
                if (bit != '0' && bit != '1')
                {
                    return false;
                }
            }

            return true;
        }

        private void btnSwapBits_Click(object sender, EventArgs e)
        {
            string bits = txtMSG.Text;
            if (IsProperBinaryNumber(bits) == false)
            {
                txtLogs.Text += "not a proper message" + Environment.NewLine;
                return;
            }
            string message = swapBits(bits);
            if (message != String.Empty)
            {
                txtMSG.Text = message;
            }
        }

        private string swapBits(string bits)
        {
            int zeroBitPlace;
            int oneBitPlace;
            try
            {
                zeroBitPlace = FindRandomSpecificBitPlace(bits, '0');
                oneBitPlace = FindRandomSpecificBitPlace(bits, '1');

            }
            catch (ArgumentNullException exception)
            {
                txtLogs.Text += exception.Message + Environment.NewLine;
                return String.Empty;
            }

            return SwapCharsInString(bits, zeroBitPlace, oneBitPlace);
        }

        private string SwapCharsInString(string bits,int zeroBitPlace, int oneBitPlace)
        {
            char zeroBit = bits[zeroBitPlace];
            char oneBit = bits[oneBitPlace];

            StringBuilder bitsModifiable = new StringBuilder(bits);
            bitsModifiable[zeroBitPlace] = oneBit;
            bitsModifiable[oneBitPlace] = zeroBit;

            return bitsModifiable.ToString();
        }

        private int FindRandomSpecificBitPlace(string bits, char wantedBit)
        {
            Random rnd = new Random();

            if (bits.Contains(wantedBit))
            {
                while (true)
                {
                    int bitPlace = rnd.Next(0, 20);
                    char properBit = bits[bitPlace];
                    if (properBit == wantedBit)
                    {
                        return bitPlace;
                    }
                }

            }

            throw new ArgumentNullException("not able to properly swap bits because there is only one bit type");
        }

        private int FindRandomBitPlace()
        {
            Random rnd = new Random();
            return rnd.Next(0, 20);
        }
    }
}
