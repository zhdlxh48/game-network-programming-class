using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Homework
{
    // C# 에서의 스레드 프로그램
    public class Week4_201813086_1
    {
        public static void Run()
        {
            _ = new Week4_201813086_1();
        }

        public Week4_201813086_1 ()
        {
            var counter1 = new Thread(new ThreadStart(Counter1));
            var counter2 = new Thread(new ThreadStart(Counter2));

            counter1.Start();
            counter2.Start();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Main: " + i);
                Thread.Sleep(1000);
            }
        }

        private void Counter1()
        {
            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine("Thread1: " + i);
                Thread.Sleep(2000);
            }
        }

        private void Counter2()
        {
            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine("Thread2: " + i);
                Thread.Sleep(3000);
            }
        }
    }
}
