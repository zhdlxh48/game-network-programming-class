using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Homework
{
    // Multicast Reciever
    public class Week3_201813086_7
    {
        private const string MULTICAST_IP = "235.7.8.9";
        private const int LOCAL_PORT = 9000;

        private const int BUFFER_SIZE = 512;

        public static void Run()
        {
            int returnValue;
            Socket socket = null;
            MulticastOption multiCastOpt = null;

            try
            {
                // 소켓 생성
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

                // SO_REUSEADDR 옵션 설정
                socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                
                socket.Bind(new IPEndPoint(IPAddress.Any, LOCAL_PORT));

                // 멀티캐스트 그룹 가입
                multiCastOpt = new MulticastOption(IPAddress.Parse(MULTICAST_IP), IPAddress.Any);
                socket.SetSocketOption(SocketOptionLevel.IP,
                SocketOptionName.AddMembership, multiCastOpt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(1);
            }
            
            // 데이터 통신에 사용할 변수
            byte[] buffer = new byte[BUFFER_SIZE];

            // 멀티캐스트 데이터 받기
            while (true)
            {
                try
                {
                    // 데이터 받기
                    var anyAddr = new IPEndPoint(IPAddress.Any, 0);
                    var peerAddr = (EndPoint)anyAddr;
                    returnValue = socket.ReceiveFrom(buffer, BUFFER_SIZE, SocketFlags.None, ref peerAddr);

                    // 받은 데이터 출력
                    var ipEP = (IPEndPoint)peerAddr;
                    Console.WriteLine("[UDP/{0}:{1}] {2}", ipEP.Address, ipEP.Port, Encoding.Default.GetString(buffer, 0, returnValue));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    break;
                }
            }

            // 멀티캐스트 그룹 탈퇴
            socket.SetSocketOption(SocketOptionLevel.IP,
            SocketOptionName.DropMembership, multiCastOpt);
            
            // 소켓 닫기
            socket.Close();
        }
    }
}