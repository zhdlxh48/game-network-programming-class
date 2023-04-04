using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Homework
{
    // 스레드의 우선 순위 변경
    public class Week4_201813086_3
    {
        public static void Run()
        {
            Console.WriteLine("Thread 우선순위 값: Low({0}) - High({1})", (int)ThreadPriority.Lowest, (int)ThreadPriority.Highest);

            var processorCount = Environment.ProcessorCount;

            for (var i = 0; i < processorCount; i++)
            {
                var hThread = new Thread(MyThread)
                {
                    Name = "Created Thread", 
                    // 개체 초기화 사용
                    IsBackground = true,
                    Priority = ThreadPriority.AboveNormal
                };

                hThread.Start();
            }

            //Console.WriteLine("현재 실행중인 Thread Name: " + Thread.CurrentThread.Name);
            Thread.CurrentThread.Priority = ThreadPriority.BelowNormal;
            Thread.Sleep(1000);
            Console.WriteLine("주 스레드 실행");
        }

        private static void MyThread()
        {
            while (true) { }
        }
    }
}
