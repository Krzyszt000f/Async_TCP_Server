using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace BibliotekaKlas
{
    public class AsyncSummingServer
    {
        IPAddress adres;
        int port;
        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="adres">Adres IP serwera</param>
        /// <param name="port">Port na którym nasłuchuje serwer</param>
        public AsyncSummingServer(IPAddress adres, int port)
        {
            this.adres = adres;
            this.port = port;
        }

        private void HandleClient(object obj)
        {
            try
            {
                TcpClient client = (TcpClient)obj;
                Console.WriteLine("Połączył się nowy klient");
                byte[] buffer = new byte[1024];
                client.GetStream().Read(buffer, 0, 1024);
                string result = System.Text.Encoding.UTF8.GetString(buffer);
                Console.WriteLine("Otrzymałem od klienta " + result);
                string wynik = MessageParser.Parse(result);
                Thread.Sleep(10000);
                Console.WriteLine("Wysyłam do klienta " + wynik);
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(wynik);
                client.GetStream().Write(bytes, 0, bytes.Length);
                Console.WriteLine("Rozłączam klienta");
                client.Close();
            }
            catch (Exception ex)
            {
                Console.Write("Zlapano wyjatek: " + ex.Message);
            }
        }

        /// <summary>
        /// Startuje serwer
        /// </summary>
        /// 
        public void Start()
        {
            TcpListener server = new TcpListener(adres, port);
            server.Start();
            while (true)
            {
                try
                {
                    TcpClient client = server.AcceptTcpClient();
                    Thread t = new Thread(new ParameterizedThreadStart(HandleClient));
                    t.Start(client);
                }
                catch (Exception ex)
                {
                    Console.Write("Zlapano wyjatek: " + ex.Message);
                }
            }
        }
    }
}
