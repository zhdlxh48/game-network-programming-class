using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Homework
{
    // 스레드 동기화 프로그램 연습 - 4
    public class Week4_201813086_8
    {
        private const int MAX_COUNT = 100000000;

        private static int count = 0;

        public static void Run()
        {
            var obj = new object(); // For Sync

            var threadArr = new Thread[2];

            threadArr[0] = new Thread(MyThread1);
            threadArr[1] = new Thread(MyThread2);
            
            threadArr[0].Start(obj);
            threadArr[1].Start(obj);

            threadArr[0].Join();
            threadArr[1].Join();

            Console.WriteLine(count);
        }

        private static void MyThread1(object arg)
        {
            for (var i = 0; i < MAX_COUNT; i++)
            {
                Monitor.Enter(arg);
                count += 2;
                Monitor.Exit(arg);
            }
        }

        private static void MyThread2(object arg)
        {
            for (var i = 0; i < MAX_COUNT; i++)
            {
                Monitor.Enter(arg);
                count -= 2;
                Monitor.Exit(arg);
            }
        }
    }
}
