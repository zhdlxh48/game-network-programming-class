using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Homework
{
    public class Week3_201813086_2
    {
        public static void Run()
        {
            IPAddress hostAddr = IPAddress.Parse("192.168.1.81");
            IPEndPoint hostIpEP = new IPEndPoint(hostAddr, 8000);

            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                sock.Connect(hostIpEP);
            }
            catch (SocketException ex)
            {
                Console.WriteLine("Problem connecting to host");
                Console.WriteLine(ex.ToString());
                sock.Close();
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine("unexpected error");
                Console.WriteLine(ex.ToString());
                sock.Close();
                return;
            }

            try
            {
                sock.Send(Encoding.ASCII.GetBytes("testing"));
            }
            catch (SocketException ex)
            {
                Console.WriteLine("Problem sending data");
                Console.WriteLine(ex.ToString());
                sock.Close();
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine("unexpected error");
                Console.WriteLine(ex.ToString());
                sock.Close();
                return;
            }

            sock.Close();
        }
    }
}