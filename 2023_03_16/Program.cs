using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace _2023_03_16
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket socket = null;

            // Create socket with catch exception
            try
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                Console.WriteLine("Successfully creation socket");
            }
            catch (SocketException ex)
            {
                Console.WriteLine("SocketException occoured: (" + ex.ErrorCode + ") " + ex.Message);
                Environment.Exit(ex.ErrorCode);
            }

            //Close socket
            // TODO: What diffrence between Close() and Shutdown()
            socket.Close();
        }
    }
}
