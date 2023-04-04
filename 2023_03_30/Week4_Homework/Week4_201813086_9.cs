using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    // C# 기반의 TCP 클라이언트 프로그램
    public class Week4_201813086_9
    {
        private static string SERVER_IP = IPAddress.Loopback.ToString();
        private const int SERVER_PORT = 9000;

        private const int BUFFER_SIZE = 512;

        public static void Run(string[] args)
        {
            var returnVal = 0;

            //if (args.Length > 0) SERVER_IP = args[0];

            Socket socket = null;
            try
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(SERVER_IP, SERVER_PORT);
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(ex.ErrorCode);
            }

            var buffer = new byte[BUFFER_SIZE];

            // Data transfer to server
            while (true) 
            {
                Console.Write("보낼 데이터: ");
                var data = Console.ReadLine().Trim();

                if (data.Length < 0) break;

                try
                {
                    var sendData = Encoding.Default.GetBytes(data);

                    int size = sendData.Length > BUFFER_SIZE ? BUFFER_SIZE : sendData.Length;
                    returnVal = socket.Send(sendData, 0, size, SocketFlags.None);

                    Console.WriteLine(returnVal + " bytes / Send to server");

                    returnVal = ReceiveN(socket, ref buffer, returnVal, SocketFlags.None);
                    if (returnVal == 0) break;

                    Console.WriteLine(returnVal + " bytes / Receive from server");
                    Console.WriteLine("Server -> " + Encoding.Default.GetString(buffer, 0, returnVal));
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }

        private static int ReceiveN(Socket socket, ref byte[] buffer, int length, SocketFlags flags)
        {
            var received = 0;
            var offset = 0;
            var left = length;

            while (left > 0)
            {
                try
                {
                    received = socket.Receive(buffer, offset, left, flags);

                    if (received == 0) break;
                    left -= received;
                    offset += received;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }

            return length - left;
        }
    }
}
