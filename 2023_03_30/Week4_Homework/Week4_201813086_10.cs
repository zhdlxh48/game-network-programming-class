using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Homework
{
    // C# 기반의 TCP 멀티스레드 서버 프로그램
    public class Week4_201813086_10
    {
        private const int SERVER_PORT = 9000;

        private const int LISTEN_MAX = 1000;
        private const int BUFFER_SIZE = 512;

        public static void Run(string[] args)
        {
            Socket listenSocket = null;
            try
            {
                listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                listenSocket.Bind(new IPEndPoint(IPAddress.Any, SERVER_PORT));
                listenSocket.Listen(LISTEN_MAX);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(-1);
            }

            Socket clientSocket = null;
            Thread hThread = null;

            while (true)
            {
                try
                {
                    clientSocket = listenSocket.Accept();

                    var clientEP = clientSocket.RemoteEndPoint as IPEndPoint;
                    Console.WriteLine("{0}:{1} - 클라이언트 연결 허용", clientEP.Address, clientEP.Port);

                    hThread = new Thread(ProcessClient);
                    hThread.Start(clientSocket);
                }
                catch (SocketException ex)
                {
                    Console.WriteLine($"[Network Socket Error] {ex.Message}");
                    break;
                }
                catch (ThreadStateException ex)
                {
                    Console.WriteLine($"[Threading Error] {ex.Message}");
                    break;
                }
            }

            listenSocket.Close();
            listenSocket.Dispose();
        }

        private static void ProcessClient(object arg)
        {
            var returnVal = 0;
            var buffer = new byte[BUFFER_SIZE];
            
            using (var clientSocket = arg as Socket)
            {
                var clientEP = clientSocket.RemoteEndPoint as IPEndPoint;

                while (true)
                {
                    try
                    {
                        returnVal = clientSocket.Receive(buffer, BUFFER_SIZE, SocketFlags.None);
                        if (returnVal == 0) break;

                        Console.WriteLine("{0}:{1} - {2}", clientEP.Address, clientEP.Port, Encoding.Default.GetString(buffer, 0, returnVal));

                        clientSocket.Send(buffer, returnVal, SocketFlags.None);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        break;
                    }
                }

                Console.WriteLine("{0}:{1} - 클라이언트 종료", clientEP.Address, clientEP.Port);

                clientSocket.Close();
                clientSocket.Dispose();
            }
        }
    }
}
