using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Homework
{
    // Broadcast Sender
    public class Week3_201813086_6
    {
        private static IPAddress REMOTE_IP = IPAddress.Broadcast;
        private const int REMOTE_PORT = 9000;

        private const int BUFFER_SIZE = 512;

        public static void Run(string[] args = default)
        {
            int returnValue;

            Socket socket = null;
            try
            {
                // 소켓 생성
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                // 브로드캐스팅 활성화
                socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(1);
            }

            // 소켓 주소 객체 초기화
            IPEndPoint serverAddr = new IPEndPoint(REMOTE_IP, REMOTE_PORT);
            // 데이터 통신에 사용할 변수
            byte[] buffer = new byte[BUFFER_SIZE];

            // 브로드캐스트 데이터 보내기
            while (true)
            {
                // 데이터 입력
                Console.Write("\n[보낼 데이터] ");
                string data = Console.ReadLine();

                if (data.Length == 0) break;

                try
                {
                    // 데이터 보내기 (최대 길이를 BUFSIZE로 제한)
                    byte[] senddata = Encoding.Default.GetBytes(data);
                    int size = senddata.Length;
                    if (size > BUFFER_SIZE) size = BUFFER_SIZE;

                    returnValue = socket.SendTo(senddata, 0, size, SocketFlags.None, serverAddr);
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