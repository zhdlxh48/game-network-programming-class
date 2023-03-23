using System;
using System.Text;
using System.Net.Sockets;

namespace Practice
{
    // 2주차 6번 과제 (TCP Client)

    public class TcpClientPractice
    {
        public static void Run()
        {
            string hostIp = "192.168.30.73"; // Loopback
            int serverPort = 9000;

            try
            {
                using (var client = new TcpClient(hostIp, serverPort))
                {
                    Console.WriteLine("Accepted connect request to server");

                    using (var stream = client.GetStream())
                    {
                        int receivedBytes = 0;
                        int totalReceivedBytes = 0;

                        Console.WriteLine("Enter message");
                        var str = Console.ReadLine();

                        var encoding = Encoding.Default;

                        // ASCII 형식으로 인코딩한 문자열을 바이트 배열로 반환
                        //byte[] buffer = encoding.GetBytes("TCP Client Connect Test");
                        byte[] buffer = encoding.GetBytes(str);
                        //byte[] buffer = encoding.GetBytes("Message 테스트");

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

                        //Console.WriteLine("Received {0} bytes from server: {1}", totalReceivedBytes, Encoding.ASCII.GetString(buffer, 0, totalReceivedBytes));
                        Console.WriteLine("Received {0} bytes from server: {1}", totalReceivedBytes, encoding.GetString(buffer, 0, totalReceivedBytes));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
