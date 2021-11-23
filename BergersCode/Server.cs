using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BergersCode
{
    public class Server : IServer
    {
        private TcpListener TcpListener;
        private List<Socket> Sockets;

        public Server()
        {
            Serve();
        }

        public void CheckForErrors(string message)
        {
            throw new NotImplementedException();
        }

        public bool Connect(string ipAddresss, int port)
        {
            Socket sckt = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress hostadd = IPAddress.Parse(ipAddresss);
            // int port = 2222;
            IPEndPoint EPhost = new IPEndPoint(hostadd, port);

            try
            {
                sckt.Connect(EPhost);

            }
            catch (SocketException e)
            {
                return false;
            }


            if (sckt.Connected)
            {
                Console.WriteLine("Connection set with IP: {0}, port: {1}", ipAddresss, port);
                Sockets.Add(sckt);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void IsRecipient(string address)
        {
            throw new NotImplementedException();
        }

        public void NotifyError(string address)
        {
            throw new NotImplementedException();
        }

        public void ReadTheMessage(string message)
        {
            throw new NotImplementedException();
        }

        public string Recieve()
        {
            throw new NotImplementedException();
        }

        public void Send(string address, string message)
        {
            throw new NotImplementedException();
        }

        public void Serve()
        {
            string serverIp = "127.0.0.1";
            int port = 2222;

            while (true)
            {

                try
                {
                    TcpListener = new TcpListener(IPAddress.Parse(serverIp), port);

                    TcpListener.Start();
                    Console.WriteLine("Waiting on IP: {0}, port: {1}", serverIp, port);
                    TcpClient client = TcpListener.AcceptTcpClient();
                    break;
                }
                catch (Exception e)
                {
                    //Console.WriteLine(e.Message);

                    port++;
                    Console.WriteLine("Port taken. Trying port: " + port);
                }
            }
        }
    }
}
