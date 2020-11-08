using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Klient_TCP
{
    class Program
    {
        /// <summary>
        /// Główna funkcja aplikacji klienta
        /// </summary>
        /// <param name="args">Lista argumentów ignorowana</param>
        static void Main(string[] args)
        {
            Console.WriteLine("Podaj wiadomosc dla serwera:");
            string liczby = Console.ReadLine();
            TcpClient client = new TcpClient();
            client.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 2048));
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(liczby);
            client.GetStream().Write(bytes, 0, bytes.Length);
            byte[] buffer = new byte[1024];
            client.GetStream().Read(buffer, 0, 1024);
            string result = System.Text.Encoding.UTF8.GetString(buffer);
            Console.WriteLine(result);
            client.Close();
            Console.ReadLine();
        }
    }
}
