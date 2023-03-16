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

            IPAddress ipAddrLocal = null;
            IPAddress ipAddrRemote = null;
            IPAddress ipAddrLoopback = null;

            // Create socket with catch exception
            try
            {
                ipAddrLocal = IPAddress.Parse("192.168.30.236");
                ipAddrRemote = IPAddress.Parse("192.168.30.46");
                ipAddrLoopback = IPAddress.Loopback;
                Console.WriteLine("Local: {0}\nRemote: {1}\nLoopback: {2}", ipAddrLocal, ipAddrRemote, ipAddrLoopback);

                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                Console.WriteLine("Successfully creation socket");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("FormatException occoured: " + ex.Message);
                Environment.Exit(-1);
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
