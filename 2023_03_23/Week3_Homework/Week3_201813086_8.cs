using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Homework
{
    // Multicast Sender
    public class Week3_201813086_8
    {
        private static string MULTICAST_IP = "235.7.8.9";
        private const int REMOTE_PORT = 9000;

        private const int BUFFER_SIZE = 512;

        public static void Run()
        {
            int returnValue;
            
            Socket socket = null;

            try
            {
                // 소켓 생성
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

                // 멀티캐스트 TTL 설정
                int ttl = 2;
                socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.MulticastTimeToLive, ttl);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(1);
            }

            // 소켓 주소 객체 초기화
            IPEndPoint serverAddr = new IPEndPoint(IPAddress.Parse(MULTICAST_IP), REMOTE_PORT);

            // 데이터 통신에 사용할 변수
            //byte[] buffer = new byte[BUFFER_SIZE];
            
            // 멀티캐스트 데이터 보내기
            while (true)
            {
                // 데이터 입력
                Console.Write("\n[보낼 데이터] ");
                string data = Console.ReadLine();

                if (data.Length == 0) break;

                try
                {
                    // 데이터 보내기 (최대 길이를 BUFSIZE로 제한)
                    byte[] sendData = Encoding.Default.GetBytes(data);
                    int sendLength = sendData.Length;
                    if (sendLength > BUFFER_SIZE) sendLength = BUFFER_SIZE;

                    returnValue = socket.SendTo(sendData, 0, sendLength, SocketFlags.None, serverAddr);
                    Console.WriteLine("[UDP] {0}바이트를 보냈습니다.", returnValue);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    break;
                }
            }
            // 소켓 닫기
            socket.Close();
        }
    }
}