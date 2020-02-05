using System;
using System.Threading;

namespace TombolaServer
{
    class Program
    {
        static void Main(string[] args)
        {

            Thread t = new Thread( () =>
            {
                // replace the IP with your system IP Address...
                Server server = new Server("127.0.0.1", 3333);
            });
            t.Start();

            Console.WriteLine("Server avviato");

        }
    }
}
