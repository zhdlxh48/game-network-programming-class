using System.Net.Sockets;
using System.Text;

namespace Homework
{
    // TCP 클라이언트
    public static class Week2_201813086_6
    {
        public static void Run()
        {
            string hostIp = "127.0.0.1"; // Loopback
            int serverPort = 9000;

            try
            {
                using var client = new TcpClient(hostIp, serverPort);
                using var stream = client.GetStream();

                Console.WriteLine("Accepted connect request to server");

                int receivedBytes = 0;
                int totalReceivedBytes = 0;
                // ASCII 형식으로 인코딩한 문자열을 바이트 배열로 반환
                byte[] buffer = Encoding.ASCII.GetBytes("TCP Client Connect Test");

                stream.Write(buffer, 0, buffer.Length);
                Console.WriteLine("Sent {0} bytes to server", buffer.Length);

                while (totalReceivedBytes < buffer.Length)
                {
                    receivedBytes = stream.Read(buffer, totalReceivedBytes, buffer.Length - totalReceivedBytes);

                    if (receivedBytes == 0)
                    {
                        Console.WriteLine("Connection closed prematurely.");
                        break;
                    }
                    else
                    {
                        totalReceivedBytes += receivedBytes;
                    }

                }

                Console.WriteLine("Received {0} bytes from server: {1}", totalReceivedBytes, Encoding.ASCII.GetString(buffer, 0, totalReceivedBytes));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
