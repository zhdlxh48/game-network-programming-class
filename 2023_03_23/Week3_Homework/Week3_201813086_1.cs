using System;
using System.Net;

namespace Homework
{
    public class Week3_201813086_1
    {
        public static void Run()
        {
            IPAddress testIPAddr = IPAddress.Parse("192.168.1.81");
            IPEndPoint ipEP = new IPEndPoint(testIPAddr, 8000);

            Console.WriteLine("The IPEndPoint is: {0}", ipEP.ToString());
            Console.WriteLine("The AddressFamily is: {0}", ipEP.AddressFamily);
            Console.WriteLine("The address is: {0}, and the port is: {1}\n", ipEP.Address, ipEP.Port);
            Console.WriteLine("The min port number is: {0}", IPEndPoint.MinPort);
            Console.WriteLine("The max port number is: {0}\n", IPEndPoint.MaxPort);

            ipEP.Port = 80;
            Console.WriteLine("The changed IPEndPoint value is: {0}", ipEP.ToString());

            SocketAddress sa = ipEP.Serialize();
            Console.WriteLine("The SocketAddress is: {0}", sa.ToString());
        }
    }
}