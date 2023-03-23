using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    public class Week2_201813086_4
    {
        public static void Run(string[] args)
        {
            var localHostName = Dns.GetHostName();
            Console.WriteLine("Local Host: " + localHostName);
            PrintHostInfo(localHostName);

            if (args.Length > 0) 
            {
                foreach (var item in args)
                {
                    Console.WriteLine(item + ": ");
                    PrintHostInfo(item);
                }
            }
        }

        public static void PrintHostInfo(string host)
        {
            try
            {
                // DNS 호스트나 IP 주소를 IPHostEntry 인스턴스로 변환
                // 공식 문서에서 Deprecated로 표기되어 GetHostEntry를 사용하는 것을 권장됨
                IPHostEntry hostInfo = Dns.Resolve(host);

                Console.WriteLine("Canonical Name: " + hostInfo.HostName);

                var addrStr = "";
                foreach (var item in hostInfo.AddressList)
                {
                    addrStr += (item.ToString() + " ");
                }
                Console.WriteLine("IP Addresses: " + addrStr);

                var aliasStr = "";
                foreach (var item in hostInfo.Aliases)
                {
                    aliasStr += (item.ToString() + " ");
                }
                Console.WriteLine("Aliases: " + aliasStr);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to resolve host");
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
