using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocketUDPThread
{
    class Client
    {
        private TextReader tr;
        private TextWriter tw;
        private String pseudo;
        
        public Client()
        {
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
            s.Connect(iep);

            NetworkStream ns = new NetworkStream(s);        //permet l'envoie sous forme de string dans le réseau
            tr = new StreamReader(ns);
            tw = new StreamWriter(ns);
            Console.WriteLine("Choose a pseudo:");
            pseudo = Console.ReadLine();

            Thread th = new Thread(EcouterReponse);
            th.Start();
            while (true)
            {
                String message = pseudo + ": " + Console.ReadLine();
                tw.WriteLine(message );
                Console.Clear();
                ClearCurrentConsoleLine();
                Console.WriteLine(message);
                tw.Flush();
            }


        }

        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        private void EcouterReponse()
        {
            while (true)
            {
                Console.WriteLine(tr.ReadLine());
            }
        }

        static void Main(string[] args)
        {
            new Client();
        }
    }
}
