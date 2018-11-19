using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketUDPThread
{
    class Client
    {
        private TextReader tr;
        private TextWriter tw;
        
        public Client()
        {
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
            s.Connect(iep);

            NetworkStream ns = new NetworkStream(s);        //permet l'envoie sous forme de string dans le réseau
            tr = new StreamReader(ns);
            tw = new StreamWriter(ns);

        }
    }
}
