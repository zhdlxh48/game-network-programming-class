using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Homework
{
    // Broadcast Reciever
    public class Week3_201813086_5
    {
        private const int LOCAL_PORT = 9000;
        private const int BUFFER_SIZE = 512;

        public static void Run()
        {
            int retval;
            Socket sock = null;
            try
            {
                sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

                sock.Bind(new IPEndPoint(IPAddress.Any, LOCAL_PORT));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(1);
            }

            // 데이터 통신에 사용할 변수
            byte[] buffer = new byte[BUFFER_SIZE];

            // 브로드캐스트 데이터 받기
            while (true)
            {
                try
                {
                    // 데이터 받기
                    var anyAddr = new IPEndPoint(IPAddress.Any, 0);
                    var peerAddr = (EndPoint)anyAddr;

                    retval = sock.ReceiveFrom(buffer, BUFFER_SIZE, SocketFlags.None, ref peerAddr);

                    // 받은 데이터 출력
                    var ipEP = (IPEndPoint)peerAddr;
                    Console.WriteLine("[UDP/{0}:{1}] {2}", ipEP.Address, ipEP.Port, Encoding.Default.GetString(buffer, 0, retval));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    break;
                }
            }

            // 소켓 닫기
            sock.Close();
        }
    }
}