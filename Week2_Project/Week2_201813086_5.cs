using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Week2_Project
{
    // TCP 서버
    public static class Week2_201813086_5
    {
        private const int BUFFER_SIZE = 32;

        public static void Run()
        {
            var serverPort = 9000;
            TcpListener listener = null;

            try
            {
                listener = new TcpListener(IPAddress.Any, serverPort);
                // Tcp 연결 요청을 받기 시작함
                listener.Start();
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

            int receivedBytes = 0;
            int totalReceivedBytes = 0;
            byte[] buffer = new byte[BUFFER_SIZE];

            while (true)
            {

                try
                {
                    // using을 이용해 Close Method로 명시하지 않아도 사용이 끝나면 자동으로 Dispose를 진행함
                    // TcpListener 객체에서 연결 요청이 들어오면 Blocking 상태에서 돌아와 요청을 수락 및 클라이언트 객체을 받아옴
                    using var client = listener.AcceptTcpClient();
                    // 연결된 클라이언트 stream을 가져옴
                    using var stream = client.GetStream();

                    Console.WriteLine("Accept tcp client request");
                    while ((receivedBytes = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        stream.Write(buffer, 0, receivedBytes);
                        totalReceivedBytes += receivedBytes;
                    }

                    Console.WriteLine("Echoed {0} bytes", totalReceivedBytes);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    // using을 사용하여 client 객체를 받아온 경우, Exception이 발생해도 dispose가 자동으로 처리됨 (try-finally로 변역되어 dispose가 finally에서 발생)
                    // 참고: https://stackoverflow.com/questions/21533599/if-an-exception-occurs-inside-a-using-block-is-the-dispose-method-called
                }
            }
        }
    }
}
