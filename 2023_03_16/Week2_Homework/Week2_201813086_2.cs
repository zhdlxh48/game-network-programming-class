using System;
using System.Net;

namespace Homework
{
    class Week2_201813086_2
    {
        public static void Run()
        {
            // 현재 로컬 네트워크 상에서 내 기기의 IP (Subnet IP) 를 Parse해 IPAddress 객체로 변환
            IPAddress ipAddrLocal = IPAddress.Parse("192.168.30.236");
            IPAddress ipAddrLoopback = IPAddress.Loopback;
            IPAddress ipAddrBroadcast = IPAddress.Broadcast;
            IPAddress ipAddrAny = IPAddress.Any;
            IPAddress ipAddrNone = IPAddress.None;

            // 로컬 컴퓨터의 호스트 이름을 반환
            // 참고: https://learn.microsoft.com/ko-kr/dotnet/api/system.net.dns.gethostname?view=net-7.0
            string localHostName = Dns.GetHostName();
            // DNS 서버에서 호스트 이름 또는 IP 주소에 관한 IP 주소를 쿼리 (IP 주소는 여러개 관련되어 있을 수 있음)
            // 빈 string 객체가 들어갈 경우 로컬주소를 반환
            // 참고1: https://learn.microsoft.com/ko-kr/dotnet/api/system.net.dns.gethostentry?view=net-7.0#system-net-dns-gethostentry(system-string)
            // 참고2: https://afsdzvcx123.tistory.com/entry/C-TCPIP-C-TCPIP-%ED%98%B8%EC%8A%A4%ED%8A%B8-%EB%AA%85%EA%B3%BC-IP-%EC%A3%BC%EC%86%8C-%EC%B6%9C%EB%A0%A5%ED%95%98%EB%8A%94-%EB%B0%A9%EB%B2%95IPAddress-IPHostEntry
            IPHostEntry ihe = Dns.GetHostEntry(localHostName);
            // 로컬 컴퓨터의 호스트 이름으로 IP 주소를 DNS 서버에 쿼리해, 이 경우에는 로컬 주소를 반환
            IPAddress ipAddrMySelf = ihe.AddressList[0];

            if (IPAddress.IsLoopback(ipAddrLoopback))
            {
                Console.WriteLine("The Loop-back address is: {0}", ipAddrLoopback.ToString());
            }
            else
            {
                Console.WriteLine("Error obtaining the Loop-back address");
            }

            Console.WriteLine("The Local IP address is: {0}\n", ipAddrMySelf.ToString());

            if (ipAddrMySelf == ipAddrLoopback)
            {
                Console.WriteLine("The Loop-back address is the same as local address.\n");
            }
            else
            {
                Console.WriteLine("The Loop-back address is not the local address.\n");
            }

            Console.WriteLine("The test address is: {0}", ipAddrLocal.ToString());
            Console.WriteLine("Broadcast address: {0}", ipAddrBroadcast.ToString());
            Console.WriteLine("The ANY address is: {0}", ipAddrAny.ToString());
            Console.WriteLine("The NONE address is: {0}", ipAddrNone.ToString());
        }
    }
}