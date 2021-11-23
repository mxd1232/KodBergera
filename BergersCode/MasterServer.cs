using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BergersCode
{
    public class MasterServer :Server, IMasterServer
    {
        private List<TcpListener> tcpLsn;
        private List<Socket> socket;

        public void CodeTheMessageBerger(string message)
        {
            throw new NotImplementedException();
        }

        public void FindThePath()
        {
            throw new NotImplementedException();
        }
    }
}
