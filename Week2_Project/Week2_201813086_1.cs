using System;
using System.Net;
using System.Net.Sockets;

namespace Week2_Project
{
    class Week2_201813086_1
    {
        static void Main(string[] args)
        {
            IPAddress ipAddrLocal = IPAddress.Parse("192.168.30.236");
            IPAddress ipAddrLoopback = IPAddress.Loopback;
            IPAddress ipAddrBroadcast = IPAddress.Broadcast;
            IPAddress ipAddrAny = IPAddress.Any;
            IPAddress ipAddrNone = IPAddress.None;

            IPHostEntry ihe = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddrMySelf = ihe.AddressList[0];

            if (IPAddress.IsLoopback(ipAddrLoopback))
            {
                Console.WriteLine("The Loopback address is: {0}", ipAddrLoopback.ToString());
            }
            else
            {
                Console.WriteLine("Error obtaining the loopback address");
            }
            
            Console.WriteLine("The Local IP address is: {0}\n", myself.ToString());
            
            if (ipAddrMySelf == ipAddrLoopback)
            {
                Console.WriteLine("The loopback address is the same as local address.\n");
            }
            else
            {
                Console.WriteLine("The loopback address is not the local address.\n");
            }
            
            Console.WriteLine("The test address is: {0}", ipAddrLocal.ToString());
            Console.WriteLine("Broadcast address: {0}", ipAddrBroadcast.ToString());
            Console.WriteLine("The ANY address is: {0}", ipAddrAny.ToString());
            Console.WriteLine("The NONE address is: {0}", ipAddrNone.ToString());
        }
    }
}