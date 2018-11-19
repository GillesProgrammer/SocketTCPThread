using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocketTCPThread
{
    class Server
    {
        int nbclients;
        public Server()
        {
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse("127.0.0.1"),9999);
            s.Bind(iep);
            s.Listen(1);

            while(true)
            {
                Console.WriteLine("Serveur en ateente de client...");
                Socket c = s.Accept();                                  //Traiter le client
                nbclients++;
                ClientCommunication cc = new ClientCommunication(c, nbclients);
                Thread th = new Thread(Communication);
                th.Start(cc);
                while (true)
                {
                    //lire message client

                }

            }
        }

        public void Communication(Object o)
        {
            ClientCommunication cc = o as ClientCommunication;

        }

        class ClientCommunication
        {
            public Socket socket { get; set; }
            public int number { get; set; }
            public ClientCommunication(Socket socket, int number){
                this.socket = socket;
                this.number = number;
            }

        static void Main(string[] args)
        {
        }
    }
}
