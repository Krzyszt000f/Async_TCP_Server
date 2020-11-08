using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Async_TCP_Server
{
    class AsyncTCPServer
    {
        static void Main(string[] args)
        {
            BibliotekaKlas.AsyncSummingServer s = new BibliotekaKlas.AsyncSummingServer(IPAddress.Any, 2048);
            s.Start();
        }
    }
}
