using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaKlas
{
    class MessageParser
    {
        /// <summary>
        /// Przetwarza wiadomość którą otrzymał serwer od klienta
        /// </summary>
        /// <param name="message">Otrzymana wiadomość</param>
        /// <returns>Wiadomość jaką należy odesłać klientowi</returns>
        public static string Parse(string message)
        {
            try
            {
                char[] separator = { ' ' };
                string[] liczby = message.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                if (liczby.Length == 2)
                {
                    int x = int.Parse(liczby[0]);
                    int y = int.Parse(liczby[1]);
                    int wynik = x + y;
                    string wyniks = wynik.ToString();
                    return wyniks;
                }
                else
                {
                    return "error";
                }
            }
            catch (Exception ex)
            {
                return "error";
            }
        }
    }
}
