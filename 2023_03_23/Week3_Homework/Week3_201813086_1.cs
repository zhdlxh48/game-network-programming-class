using System;
using System.Net;

namespace Homework
{
    public class Week3_201813086_1
    {
        public static void Run()
        {
            var localIp = IPAddress.Parse("192.168.1.81");
            var ipEP = new IPEndPoint(localIp, 8080);
            
            Console.WriteLine("The IPEndPoint is: " + ipEP.ToString());
            Console.WriteLine("The AddressFamily is: " + ipEP.AddressFamily);
            Console.WriteLine("The address is: {0}, and the port is: {1}\n", ipEP.Address, ipEP.Port);
            Console.WriteLine("The min port number is: " + IPEndPoint.MinPort);
            Console.WriteLine("The max port number is: " + IPEndPoint.MaxPort); // PORT에 할당되는 최대 수는 2^16
            
            ipEP.Port = 80;
            
            Console.WriteLine("\nThe changed IPEndPoint value is: " + ipEP.ToString());
            SocketAddress sa = ipEP.Serialize();
            Console.WriteLine("\nThe SocketAddress is: " + sa.ToString());
        }
    }
}
