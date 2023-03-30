using System;
using System.Net;

namespace Homework
{
    public class Week3_201813086_4
    {
        public static void Run()
        {
            short x1 = 0x1234;
            int y1 = 0x12345678;
            short x2;
            int y2;

            // Host to Network (Little Endian)
            // Little Endian: 낮은 주소에 낮은 크기의 바이트 부터 저장
            // Big Endian: 낮은 주소에 높은 크기의 바이트 부터 저장
            Console.WriteLine("Host -> Network");
            x2 = IPAddress.HostToNetworkOrder(x1);
            Console.WriteLine("0x{0:x} -> 0x{1:x}", x1, x2);
            y2 = IPAddress.HostToNetworkOrder(y1);
            Console.WriteLine("0x{0:x} -> 0x{1:x}", y1, y2);

            // Network to Host
            Console.WriteLine("\nNetwork -> Host");
            Console.WriteLine("0x{0:x} -> 0x{1:x}", x2,
            IPAddress.NetworkToHostOrder(x2));
            Console.WriteLine("0x{0:x} -> 0x{1:x}", y2,
            IPAddress.NetworkToHostOrder(y2));

            // Wrong way
            Console.WriteLine("\nWrong");
            Console.WriteLine("0x{0:x} -> 0x{1:x}", x1,
            IPAddress.NetworkToHostOrder((int)x1));
        }
    }
}