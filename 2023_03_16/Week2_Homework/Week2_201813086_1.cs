using System;
using System.Net.Sockets;

namespace Homework
{
    class Week2_201813086_1
    {
        public static void Run()
        {
            Socket socket; // Socket은 null을 허용하지 않으므로 '= null'은 제거함

            try
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                Console.WriteLine("소켓 생성 성공");

                socket.Close();
            }
            catch (SocketException ex) // Socket을 동적 생성하는 과정에서 발생하는 Exception은 SocketException뿐이므로 명시하여 적음
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(1);
            }
        }
    }
}