using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using NetworkGameServer.Services;

namespace NetworkGameServer
{
    class Program
    {
        public static void Main(string[] args)
        {
            var server = new Server(9948);
            
            server.Start();

            Thread.Sleep(500);

            Console.WriteLine("** Server Started **");
            Console.WriteLine("[press any key to shutdown server]");

            Console.ReadLine();
            
            server.Stop();

            Console.WriteLine("** Server Shutdown **");
        }
    }
}
