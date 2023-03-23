using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    public class Week2_201813086_3
    {
        public static void Run()
        {
            var ia = IPAddress.Parse("127.0.0.1");
            var iep = new IPEndPoint(ia, 8000);

            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            Console.WriteLine("Address Family: {0}\nSocket Type: {1}\nProtocol Type: {2}", socket.AddressFamily, socket.SocketType, socket.ProtocolType);
            Console.WriteLine("Blocking: " + socket.Blocking);

            socket.Blocking = false;

            Console.WriteLine("New Blocking: " + socket.Blocking);
            Console.WriteLine("Connected: " + socket.Connected);

            socket.Bind(iep);

            var localIep = socket.LocalEndPoint as IPEndPoint;

            Console.WriteLine("Local EndPoint: {0}", localIep);

            socket.Close();
        }
    }
}
