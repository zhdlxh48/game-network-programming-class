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
        private const int BufferSize = 1024;
        private const int ListenMax = 1000;

        private readonly int _port;
        
        private readonly Socket _udpSocket;
        private readonly Database _db;
        
        private Thread _udpThread;

        public Server(int port)
        {
            _port = port;
            
            _udpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            _db = new Database("localhost", "ckgame", "root", "root");
            
            _udpThread = new Thread(ProcessClient);
        }

        public void Start()
        {
            _udpThread.IsBackground = true;
            _udpThread.Start(_udpSocket);
        }

        public void Stop()
        {
            _udpThread.Abort();
            _udpSocket.Close();
        }

        private void ProcessClient(object sock)
        {
            try
            {
                var udpSock = sock as Socket;

                var rcvBuf = new byte[BufferSize];
                EndPoint clientEp = new IPEndPoint(IPAddress.None, 0);
                
                var serverEp = new IPEndPoint(IPAddress.Any, _port);

                try
                {
                    udpSock.Bind(serverEp);

                    while (true)
                    {
                        udpSock.ReceiveFrom(rcvBuf, ref clientEp);

                        var score = Score.FromBuffer(rcvBuf);
                        Console.WriteLine(rcvBuf.Length);
                        Console.WriteLine("Time: " + score.Time + ", Distance: " + score.Distance);

                        var sendBuf = Encoding.UTF8.GetBytes("success");
                        udpSock.SendTo(sendBuf, clientEp);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);

                    var sendBuf = Encoding.UTF8.GetBytes("failed");
                    udpSock.SendTo(sendBuf, clientEp);

                    Stop();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                
                Stop();
            }
        }
    }
}