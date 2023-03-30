using System;
using System.Threading;

namespace Practice
{
    public class ThreadTest
    {
        public static void Run()
        {
            Thread t = new Thread(ThreadFunc);
            //t.IsBackground = true;
            t.Start();
            t.Join(); // 메인 스레드가 생성된 스레드가 종료되기를 기다림
            Console.WriteLine("주 스레드 종료");
        }

        private static void ThreadFunc()
        {
            Console.WriteLine("10초 후 프로그램 종료");
            Thread.Sleep(1000 * 10);
            Console.WriteLine("종료됨");
        }
    }
}