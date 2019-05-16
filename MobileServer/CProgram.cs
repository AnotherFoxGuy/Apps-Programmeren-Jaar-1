using System;
using System.Threading;
using Week3_Client;

namespace MobileServer
{
    public class Program
    {
        public static int Main(String[] args)
        {
            Console.WriteLine("Starting Client");
            var cli = new Client();
            cli.SetConnection("192.168.1.9", 11000);
            for (int i = 0; i < 100; i++)
            {
                cli.OpenConnection();
                Console.WriteLine(cli.ReciveData());
                cli.CloseConnection();
                //Thread.Sleep(1000);
            }
            Console.WriteLine("\nPress ENTER to continue...");
            //Console.Read();
            return 0;
        }
    }
}
