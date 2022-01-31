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
        
        public bool IsToNegateBit { get; set; } = false;
        public bool IsConnectionClosed { get; set; } = false;

        public bool IncludeControlSum { get; set; } = false;
        public bool IsToSwapBits { get; set; } = false;
        public int Port { get; set; }
      //  public string PortsPath { get; set; }

        public Server(int port)
        {

            Port = port;
            InitializeComponent();

            recieverWorker.WorkerSupportsCancellation = true;
            senderWorker.WorkerSupportsCancellation = true;

            IPLabel.Text = "Ip: " + Addresses.IpAddress;
            PortLabel.Text = "Port: " + port;

            foreach (var connection in Addresses.GetConnections(Port))
            {
                Connections.Items.Add(connection);
            }

            Console.WriteLine("Port:" + Port);

            if (Port != Addresses.MainPort)
            {
                removeUnnecesseryButtons();
            }

            StartListening();
        }

        private void removeUnnecesseryButtons()
        {
            btnSend.Enabled = false;
            btnSend.Size = new Size(new Point(0, 0));

            btnConvert.Enabled = false;
            btnConvert.Size = new Size(new Point(0, 0));

           // btnNegateOneBit.Enabled = false;
           // btnNegateOneBit.Size = new Size(new Point(0, 0));

         //   btnSwapBits.Enabled = false;
          //  btnSwapBits.Size = new Size(new Point(0, 0));

            txtMSG.Enabled = false;
            txtMSG.Size = new Size(new Point(0, 0));

            txtPort.Enabled = false;
            txtPort.Size = new Size(new Point(0, 0));

            convertableNumberBox.Enabled = false;
            convertableNumberBox.Size = new Size(new Point(0, 0));

            DestinationPort.Enabled = false;
            DestinationPort.Size = new Size(new Point(0, 0));
            DestinationPort.Text = "";

            numberLabel.Enabled = false;
            numberLabel.Size = new Size(new Point(0, 0));
            numberLabel.Text = "";

            bergerLabel.Enabled = false;
            bergerLabel.Size = new Size(new Point(0, 0));
            bergerLabel.Text = "";
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

                recieverWorker.RunWorkerAsync();
             //   lblStatus.Text = "";
             //   txtLogs.Text += "";
            }
            catch (Exception ex)
            {
                this.lblStatus.Invoke(new MethodInvoker(delegate ()
                {
                    lblStatus.Text = "Error";
                }));
                //this.txtLogs.Invoke(new MethodInvoker(delegate ()
                //{
                //    txtLogs.Text += "Server could not connect>>>" + Environment.NewLine;

                //}));
                listener.Stop();
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

                if (recieverWorker.IsBusy)
                {
                    recieverWorker.CancelAsync();
                }
                recieverWorker.RunWorkerAsync();

            }
            catch (Exception ex)
            {
                this.lblStatus.Invoke(new MethodInvoker(delegate ()
                {
                    lblStatus.Text = "Error";
                }));
                this.txtLogs.Invoke(new MethodInvoker(delegate ()
                {
                    txtLogs.Text += "Server could not connect>>>" + Environment.NewLine + ex.Message.ToString() + Environment.NewLine;

                }));
            }
        }

        private bool ConnectForSending(int port)
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
                
                // lblStatus.Text = "Error";
                this.txtLogs.Invoke(new MethodInvoker(delegate ()
                {
                    txtLogs.Text += "Server with port: [" + port + "] stoped working";
                }));
                return false;
                //txtLogs.Text += "Client could not connect>>>"+ Environment.NewLine + ex.Message.ToString() + Environment.NewLine;
            }

            return true;
        }

      

        private void timer1_Tick(object sender, EventArgs e)
        {
           // backgroundWorker2.RunWorkerAsync();
            //backgroundWorker2.WorkerSupportsCancellation = true;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            FullSendMessage(txtMSG.Text,txtPort.Text);
        }

        private void FullSendMessage(string txtMSGText,string txtPortText)
        {
            if (txtMSGText != "" && txtPortText != "")
            {
                int destinationPort = Convert.ToInt32(txtPortText);
                if (destinationPort <= 0 || destinationPort >= 9)
                {
                    this.txtLogs.Invoke(new MethodInvoker(delegate ()
                    {
                        txtLogs.Text += "Wrong destination" + Environment.NewLine;
                    }));
                    return;
                }

                string portsPath = GetPathToString(Addresses.FindShortestPath(Port, destinationPort));

                int nextPort = GetFirstPort(portsPath);

                if (nextPort <= 0 || nextPort >= 9)
                {
                    return;
                }

                if (ConnectForSending(nextPort) == false)
                {
                    if (Port == Addresses.MainPort)
                    {
                        this.txtLogs.Invoke(new MethodInvoker(delegate()
                        {
                            txtLogs.Text += "Connection Not working (socket not running)" + Environment.NewLine;
                        }));
                            return;
                    }
                    FullSendMessage(txtMSGText,Addresses.MainPort.ToString());
                }

                SendMessage(portsPath + txtMSGText);
            }
        }

        private void SendMessage( string message)
        {
            //ConnectForSending(port);

            TextToSend = message;

            senderWorker.RunWorkerAsync();
            senderWorker.CancelAsync();
        }

        //send
        private void senderWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (client.Connected)
            {
                string message =  TextToSend;

                STW.WriteLine(message);
                this.txtLogs.Invoke(new MethodInvoker(delegate ()
                {
                    txtLogs.AppendText(message + Environment.NewLine);
                   // lblStatus.Text = "connected - sent";
                }));
            }

            ReListen();
        }

        //recieve
        private void recieverWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (client.Connected)
            {
                try
                {
                    recieve = STR.ReadLine();
                    if (recieve.Contains("properMessage"))
                    {
                        FullSendMessage(recieve, Addresses.MainPort.ToString());
                        WriteToTextLog(recieve);
                        ReListen();
                        return;
                    }
                    if (recieve.Contains("wrong number of ones - berger code not correct:"))
                    {
                        FullSendMessage("wrong number of ones - berger code not correct:", Addresses.MainPort.ToString());
                        WriteToTextLog(recieve);
                        ReListen();
                        return;
                    }

                    string path = GetFullPathFromMessage(recieve);
                    string nextPath = GetDestinationPath(path);
                    string message = recieve.Substring(path.Length, (recieve.Length - path.Length));


                    if (message.Contains("errorSocket") == false)
                    {
                        if (IsToNegateBit)
                        {
                            message = NegateBit(message);
                        }

                        if (IsToSwapBits)
                        {
                            message = SwapBits(message);
                        }



                        int[] bytes = BergerHelper.ConvertStringToBinary(message);

                        if (BergerHelper.CheckBergersCode(bytes) == false)
                        {


                            WriteToTextLog("wrong number of ones - berger code not correct");

                            if (ConnectForSending(Addresses.MainPort) == false)
                            {
                                FullSendMessage(message, Addresses.MainPort.ToString());
                            }

                            SendMessage("wrong number of ones - berger code not correct: " + message);

                            ReListen();
                            return;
                        }
                    }
                    WriteToTextLog("Recieved: " + nextPath + message +
                                   Environment.NewLine);


                    this.lblStatus.Invoke(new MethodInvoker(delegate ()
                    {
                        lblStatus.Text = "connected";
                    }));

                    recieve = "";

                    int nextPort = GetFirstPort(nextPath);

                    if (nextPort != -1)
                    {
                        if (ConnectForSending(nextPort) == false)
                        {
                            FullSendMessage("errorSocket["+nextPort+"]" + message, Addresses.MainPort.ToString());
                        }
                        else
                        {
                            SendMessage(nextPath + message);
                        }
                    }
                    else
                    {
                        FullSendMessage("properMessage" + message, Addresses.MainPort.ToString());
                    }
                    ReListen();
                    return;
                }
                catch (Exception ex)
                {
                 //   WriteToTextLog("Server could not connect>>>" + Environment.NewLine + ex.Message.ToString() + Environment.NewLine);
                   
                    this.lblStatus.Invoke(new MethodInvoker(delegate ()
                    {
                        lblStatus.Text = "Error";
                    }));
                    ReListen();
                }
            }
        }



        private void WriteToTextLog(string message)
        {
            this.txtLogs.Invoke(new MethodInvoker(delegate ()
            {
                txtLogs.AppendText(message);
            }));
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
            if(Port!=Addresses.MainPort)
            {
                IsToNegateBit = !IsToNegateBit;
                isNegatedLabel.Text = IsToNegateBit.ToString();
                return;
            }


            string bits = txtMSG.Text;
            if (IsProperBinaryNumber(bits) == false)
            {
                txtLogs.Text += "not a proper message" + Environment.NewLine;
                return;
            }
            
            txtMSG.Text = NegateBit(bits);
        }

        private string NegateBit(string bits)
        {
            int bitPlace = FindRandomBitPlace();

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
            
            if (Port != Addresses.MainPort)
            {
                IsToSwapBits = !IsToSwapBits;
                isSwapedLabel.Text = IsToSwapBits.ToString();
                return;
            }

            string bits = txtMSG.Text;
            if (IsProperBinaryNumber(bits) == false)
            {
                txtLogs.Text += "not a proper message" + Environment.NewLine;
                return;
            }
            string message = SwapBits(bits);
            if (message != String.Empty)
            {
                txtMSG.Text = message;
            }
        }

        private string SwapBits(string bits)
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
            int maxValue;
            if (IncludeControlSum)
            {
                maxValue = 20;
            }
            else
            {
                maxValue = 16;
            }
            Random rnd = new Random();

            if (bits.Contains(wantedBit))
            {
                while (true)
                {
                    int bitPlace = rnd.Next(0, maxValue);
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

        private void btnCloseConnection_Click(object sender, EventArgs e)
        {
            IsConnectionClosed = !IsConnectionClosed;
            isConnectionClosedLabel.Text = isConnectionClosedLabel.ToString();
            StopConnection();
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
              //  txtLogs.Text += "Server could not disconnect>>>" + Environment.NewLine + ex.Message.ToString() + Environment.NewLine;

            }
        }

        private void btnControlSum_Click(object sender, EventArgs e)
        {
            IncludeControlSum = !IncludeControlSum;
            controlSumLabel.Text = IncludeControlSum.ToString();
        }
    }
}
