using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Homework
{
    // 스레드 실행과 완료 연습
    public class Week4_201813086_2
    {
        public static void Run()
        {
            var t = new Thread(ThreadFunc);

            //t.IsBackground = true;

            t.Start();
            //t.Join();

            Console.WriteLine("주 스레드 종료");
        }

        private static void ThreadFunc()
        {
            var exitSecond = 10;
            Console.WriteLine(exitSecond + "초 후 프로그램 종료");
            Thread.Sleep(1000 * exitSecond);

            Console.WriteLine("스레드 종료");
        }
    }
}
