using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chat
{
    class Program
    {
        const int PORT = 4444;

        static void Main(string[] args)
        {
            Console.WriteLine("Run server? Y\\N");
            if (Console.ReadLine().Trim().ToUpper() == "Y")
            {
                // Получение имени компьютера.
                string host = System.Net.Dns.GetHostName();
                // Получение ip-адреса.
                System.Net.IPAddress ip = System.Net.Dns.GetHostByName(host).AddressList[0];
                Console.WriteLine("IP adress " + ip.ToString());

                Server server = new Server(PORT, Console.Out);
                server.Work();
            }
        }
    }
}