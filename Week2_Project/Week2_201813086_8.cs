using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Week2_Project
{
    // UDP 클라이언트
    public static class Week2_201813086_8
    {
        public static void Run()
        {
            string host = "127.0.0.1";
            int serverPort = 9100;

            byte[] buffer = Encoding.ASCII.GetBytes("UDP Client Test");

            try
            {
                using var client = new UdpClient();
                client.Send(buffer, buffer.Length, host, serverPort);

                Console.WriteLine("Sent {0} bytes to the server", buffer.Length);

                var remoteIPEndPoint = new IPEndPoint(IPAddress.Any, 0);
                byte[] rcvPacket = client.Receive(ref remoteIPEndPoint);

                Console.WriteLine("Received {0} bytes from {1}: {2}", rcvPacket.Length, remoteIPEndPoint, Encoding.ASCII.GetString(rcvPacket, 0, rcvPacket.Length));
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
