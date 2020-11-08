using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace BibliotekaKlas
{
    public class SummingServer
    {
        IPAddress adres;
        int port;
        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="adres">Adres IP serwera</param>
        /// <param name="port">Port na którym nasłuchuje serwer</param>
        public SummingServer(IPAddress adres, int port)
        {
            this.adres = adres;
            this.port = port;
        }
        /// <summary>
        /// Startuje serwer
        /// </summary>
        public void Start()
        {
            TcpListener server = new TcpListener(adres, port);
            server.Start();
            while (true)
            {
                try
                {
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Połączył się nowy klient");
                    byte[] buffer = new byte[1024];
                    client.GetStream().Read(buffer, 0, 1024);
                    string result = System.Text.Encoding.UTF8.GetString(buffer);
                    Console.WriteLine("Otrzymałem od klienta " + result);
                    string wynik = MessageParser.Parse(result);
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
        }
    }
}
