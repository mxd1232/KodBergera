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
      //  public string PortsPath { get; set; }

        public Server(int port)
        {

            Port = port;
            InitializeComponent();

            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker2.WorkerSupportsCancellation = true;

            IPLabel.Text = "Ip: " + Addresses.IpAddress;
            PortLabel.Text = "Port: " + port;

            foreach (var connection in Addresses.GetConnections(Port))
            {
                Connections.Items.Add(connection);
            }

            Console.WriteLine("Port:" + Port);
            



            StartListening();


        }

        private string GetPathToString(List<int> path)
        {
            string paths = "[";

            foreach (var i in path)
            {
                paths += i;
                paths += ',';
            }

            paths = paths.Remove(paths.Length - 1);
            paths += ']';

            return paths;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private async void StartListening()
        {
            try
            {
             //   lblStatus.Text = "starting"; 
                listener = new TcpListener(IPAddress.Parse(Addresses.IpAddress), Port);
                listener.Start();
                client = await listener.AcceptTcpClientAsync();
                STR = new StreamReader(client.GetStream());
                STW = new StreamWriter(client.GetStream());
                STW.AutoFlush = true;

                backgroundWorker1.RunWorkerAsync();
             //   lblStatus.Text = "";
             //   txtLogs.Text += "";
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error";
                txtLogs.Text += "Server could not connect>>>"+ Environment.NewLine + ex.Message.ToString() + Environment.NewLine;
            }
        }

        private async void ReListen()
        {
            try
            {
               //     listener = new TcpListener(IPAddress.Parse(Addresses.IpAddress), Port);
            //    listener.Start();
                client = await listener.AcceptTcpClientAsync();
                STR = new StreamReader(client.GetStream());
                STW = new StreamWriter(client.GetStream());
                STW.AutoFlush = true;

                if (backgroundWorker1.IsBusy)
                {
                    backgroundWorker1.CancelAsync();
                }
                backgroundWorker1.RunWorkerAsync();

            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error";
                txtLogs.Text += "Server could not connect>>>" + Environment.NewLine + ex.Message.ToString() + Environment.NewLine;
            }
        }

        private void ConnectForSending(int port)
        {
            client = new TcpClient();
            IPEndPoint IpEnd = new IPEndPoint(IPAddress.Parse(Addresses.IpAddress), port);
         //   PortsPath = GetPathToString(Addresses.FindShortestPath(Port, port));

            try
            {
                client.Connect(IpEnd);

                if (client.Connected)
                {
                    STW = new StreamWriter(client.GetStream());
                    STR = new StreamReader(client.GetStream());
                    STW.AutoFlush = true;
                    
                }
                else
                {
                 //   txtLogs.Text += "Client did not connect" + Environment.NewLine;
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
                listener.Stop();
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error";
                txtLogs.Text += "Server could not disconnect>>>" + Environment.NewLine + ex.Message.ToString() + Environment.NewLine;

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           // backgroundWorker2.RunWorkerAsync();
            //backgroundWorker2.WorkerSupportsCancellation = true;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {

            if (txtMSG.Text != "" && txtPort.Text != "")
            {
                int destinationPort = Convert.ToInt32(txtPort.Text);
                if (destinationPort <= 0|| destinationPort >= 9)
                {
                    return;
                }

                string portsPath = GetPathToString(Addresses.FindShortestPath(Port, destinationPort));

                int nextPort = GetFirstPort(portsPath);

                if (nextPort <= 0 || nextPort >= 9)
                {
                    return;
                }
                ConnectForSending(nextPort);

                SendMessage(portsPath+txtMSG.Text);
            }
            txtMSG.Text = "";
        }

        private void SendMessage( string message)
        {
            //ConnectForSending(port);

            TextToSend = message;

            backgroundWorker2.RunWorkerAsync();
            backgroundWorker2.CancelAsync();
        }

        //send
        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            if (client.Connected)
            {
                string message =  TextToSend;

                STW.WriteLine(message);
                this.txtLogs.Invoke(new MethodInvoker(delegate ()
                {
                    txtLogs.AppendText(message + Environment.NewLine);
                    lblStatus.Text = "connected - sent";
                }));
            }

      //    StopConnection();

            ReListen();
        }

        //recieve
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (client.Connected)
            {
                try
                {
                    recieve = STR.ReadLine();

                    string path = GetFullPathFromMessage(recieve);
                    string nextPath = GetDestinationPath(path);
                    //   PortsPath = nextPath;

                    string message = recieve.Substring(path.Length, (recieve.Length - path.Length));

                    int[] bytes = BergerHelper.ConvertStringToBinary(message);

                    if (BergerHelper.CheckBergersCode(bytes) == false)
                    {
                        this.txtLogs.Invoke(new MethodInvoker(delegate()
                        {
                            txtLogs.AppendText("wrong number of ones - berger code not correct");
                        }));
                        return;
                    }

                    this.txtLogs.Invoke(new MethodInvoker(delegate()
                    {
                        txtLogs.AppendText("Recieved: [path]: " + nextPath + "[message]: " + message +
                                           Environment.NewLine);
                        lblStatus.Text = "connected";
                    }));
                    recieve = "";

                    int nextPort = GetFirstPort(nextPath);

                    if (nextPort != -1)
                    {
                        ConnectForSending(nextPort);
                        SendMessage(nextPath + message);
                    }
                    ReListen();
                    return;
                }
                catch (Exception ex)
                {
                    lblStatus.Text = "Error";
                    txtLogs.Text += "Server could not connect>>>" + Environment.NewLine + ex.Message.ToString() +
                                    Environment.NewLine;
                }
            }
        }

        private string GetFullPathFromMessage(string message)
        {
            int iStart = message.IndexOf('[');
            int iEnd = message.IndexOf(']');
            string path = message.Substring(iStart, iEnd + 1);

            return path;
        }
        private string GetDestinationPath(string path)
        {
            string nextPath;

            if (path.Length != 3)
            {
                nextPath = path.Remove(1, 2);
            }
            else
            {
                nextPath = path.Remove(1, 1);
            }

            return nextPath;
        }

        private int GetDestinationPort(string path)
        {
            if (path.Length <3)
            {
                return -1;
            }
            else return int.Parse(path[path.Length-2].ToString());
        }

        private int GetFirstPort(string path)
        {
            if (path.Length < 3)
            {
                return -1;
            }
            else return int.Parse(path[1].ToString());
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
