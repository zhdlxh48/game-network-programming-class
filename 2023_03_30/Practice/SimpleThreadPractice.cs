using System;
using System.Threading;

namespace Practice
{
    public class SimpleThreadPractice
    {
        public SimpleThreadPractice()
        {
            var newCounter = new Thread(new ThreadStart(RunCounter));
            var newCounter2 = new Thread(new ThreadStart(RunCounter2));

            newCounter.Start();
            newCounter2.Start();

            for (var i = 0; i < 10; i++)
            {
                Console.Write("Thread 3 - ({0})\n", i);
                Thread.Sleep(1000);
            }
        }

        public void RunCounter()
        {
            for (var i = 0; i < 10; i++)
            {
                Console.Write("Thread 1 - ({0})\n", i);
                Thread.Sleep(1000);
            }
        }

        public void RunCounter2()
        {
            for (var i = 0; i < 10; i++)
            {
                Console.Write("Thread 2 - ({0})\n", i);
                Thread.Sleep(1000);
            }
        }
    }
}