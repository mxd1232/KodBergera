using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BergersCode
{
    public interface IServer
    {
        void Serve();
        bool Connect(string ipAddresss, int port);
        void Send(string address, string message);
        string Recieve();
        void CheckForErrors(string message);
        void NotifyError(string address);
        void ReadTheMessage(string message);
        void IsRecipient(string address);
    }
}
