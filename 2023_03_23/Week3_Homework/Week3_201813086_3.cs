using System;
using System.Net;

namespace Homework
{
    public class Week3_201813086_3
    {
        public static void Run()
        {
            var hostName = Dns.GetHostName();
            Console.WriteLine("Local hostname: {0}", hostName);

            var selfEntry = Dns.GetHostEntry(hostName); // GetHostByName is deprecated
            foreach (var address in selfEntry.AddressList)
            {
                Console.WriteLine("IP Address: {0}", address.ToString());
            }
        }
    }
}