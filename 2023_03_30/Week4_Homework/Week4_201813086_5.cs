using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Homework
{
    // 스레드 동기화 프로그램 연습 - 1
    public class Week4_201813086_5
    {
        private static int sum = 0;

        public static void Run()
        {
            var num = 100;

            var hThread = new Thread(MyThread);

            var beforeVal = sum;

            hThread.Start(num);
            hThread.Join();

            var afterVal = sum;

            Console.WriteLine("Before Sum - {0} / After Sum - {1}", beforeVal, afterVal);
        }

        private static void MyThread(object arg)
        {
            var num = (int)arg;
            for (int i = 1; i <= num; i++)
            {
                sum += i;
            }
        }
    }
}
