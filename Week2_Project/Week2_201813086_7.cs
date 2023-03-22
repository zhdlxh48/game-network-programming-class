using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Week2_Project
{
    // UDP 서버
    public static class Week2_201813086_7
    {
        public static void Run()
        {
            int serverPort = 9100;
            // TCP와 달리 Listener가 따로 필요하지 않고 UdpClient 객체 하나에서 처리함 (왜?)
            UdpClient client = null;

            try
            {
                client = new UdpClient(serverPort);
                Console.WriteLine("Server is running");
            }
            catch (SocketException ex)
            {
                Console.WriteLine("Error on starting server: " + ex.Message);
                Environment.Exit(ex.ErrorCode);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Error on arguments for create TcpListener: " + ex.Message);
                Environment.Exit(-1);
            }

            // Create an IPEndPoint instance that will be passed as a reference
            // to the Receive() call and be populated with the remote client info
            var remoteEP = new IPEndPoint(IPAddress.Any, 0);

            using (client)
            {
                while (true)
                {
                    try
                    {
                        // Tcp와 달리 버퍼에 범위를 지정해 저장하지 않고, Udp 데이터그램 패킷을 바로 반환받음
                        byte[] buffer = client.Receive(ref remoteEP);
                        Console.WriteLine("Handling client: " + remoteEP);

                        // 받은 데이터그램 패킷을 Echo함
                        client.Send(buffer, buffer.Length, remoteEP);
                        Console.WriteLine("Echoed {0} bytes", buffer.Length);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            }
        }
    }
}
