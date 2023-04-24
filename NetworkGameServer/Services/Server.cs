using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using PushCarLib;

namespace NetworkGameServer.Services
{
    public class Server
    {
        private readonly int _port;
        
        private const int BufferSize = 1024;
        private const int ListenMax = 256;
        
        private readonly Database _db;

        private readonly Socket _listenSocket;
        
        private Thread _listenThread;
        private CancellationTokenSource _cts;

        public Server(int port)
        {
            _port = port;

            _db = new Database("localhost", "ckgame", "root", "root");
            
            _listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            
            _listenThread = new Thread(ListenTcpClient);
            _cts = new CancellationTokenSource();
        }

        public void Start()
        {
            _listenThread.IsBackground = true;
            _listenThread.Start(_cts.Token);
        }

        public void Stop()
        {
            _cts.Cancel();
            
            _listenSocket.Close();
            _listenSocket.Dispose();
            
            _listenThread.Abort();
        }

        private void ListenTcpClient(object token)
        {
            var cancelToken = (CancellationToken)token;
            try
            {
                _listenSocket.Bind(new IPEndPoint(IPAddress.Any, _port));
                _listenSocket.Listen(ListenMax);

                Socket clientSock = null;
                Thread clientThread = null;

                while (!cancelToken.IsCancellationRequested)
                {
                    try
                    {
                        clientSock = _listenSocket.Accept();

                        var clientEP = clientSock.RemoteEndPoint as IPEndPoint;
                        Console.WriteLine("{0}:{1} - 클라이언트 연결 허용", clientEP.Address, clientEP.Port);

                        clientThread = new Thread(ProcessClient);
                        clientThread.Start(clientSock);
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
                    
                _listenSocket.Close();
                _listenSocket.Dispose();
            }
            catch (SocketException ex)
            {
                Console.WriteLine($"[Socket Initialize Error] {ex.Message}");
                
                Console.WriteLine(ex.ErrorCode);
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);

                Environment.Exit(-1);
            }
        }

        private static void ProcessClient(object sock)
        {
            var buf = new byte[BufferSize];

            var clientSock = sock as Socket;
            // For Logging
            var clientEp = clientSock.RemoteEndPoint as IPEndPoint;

            while (true)
            {
                try
                {
                    var rcvSize = clientSock.Receive(buf, BufferSize, SocketFlags.None);
                    if (rcvSize == 0) break;

                    Console.WriteLine("{0}:{1} - {2}", clientEp.Address, clientEp.Port,
                        Encoding.Default.GetString(buf, 0, rcvSize));

                    // 네트워크를 통해 받아온 Score 객체를 역직렬화 
                    var score = Score.FromBuffer(buf);
                    Console.WriteLine("Time: " + score.Time + ", Distance: " + score.Distance);

                    // var sendBuf = Encoding.UTF8.GetBytes("success");
                    // clientSock.Send(sendBuf, sendBuf.Length, SocketFlags.None);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                    // var sendBuf = Encoding.UTF8.GetBytes("failed");
                    // clientSock.Send(sendBuf, sendBuf.Length, SocketFlags.None);

                    clientSock.Close();
                    break;
                }
            }

            Console.WriteLine("{0}:{1} - 클라이언트 종료", clientEp.Address, clientEp.Port);

            clientSock.Close();
            clientSock.Dispose();
        }
    }
}