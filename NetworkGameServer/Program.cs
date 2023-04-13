using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;

namespace NetworkGameServer
{
    class Program
    {
        public static void Main(string[] args)
        {
            var serverThread = new Thread(ServerFunc);
            serverThread.IsBackground = true;
            serverThread.Start();

            Thread.Sleep(500);

            Console.WriteLine("** Server Started **");
            Console.WriteLine("[press any key to shutdown server]");

            Console.ReadLine();

            serverThread.Abort();

            Console.WriteLine("** Server Shutdown **");
        }

        private static void ServerFunc(object obj)
        {
            using (var srvSock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
            {
                var ipEP = new IPEndPoint(IPAddress.Any, 10200);

                srvSock.Bind(ipEP);

                var rcvBuf = new byte[1024];
                EndPoint clientEP = new IPEndPoint(IPAddress.None, 0);

                while (true)
                {
                    int rcvLen = srvSock.ReceiveFrom(rcvBuf, ref clientEP);
                    string text = Encoding.Default.GetString(rcvBuf, 0, rcvLen);
                    Console.WriteLine("Client: " + text);

                    var sendBuf = Encoding.Default.GetBytes("Echo: " + text);
                    srvSock.SendTo(sendBuf, clientEP);
                }
            }
        }
    }
}
