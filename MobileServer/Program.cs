using System;

namespace MobileServer
{
    public class Program
    {
        public static int Main(String[] args)
        {
            Server.StartListening();
            return 0;
        }
    }
}
