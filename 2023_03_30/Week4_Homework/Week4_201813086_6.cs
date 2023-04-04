using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Homework
{
    // 스레드 동기화 프로그램 연습 - 2
    public class Week4_201813086_6
    {
        private int num = 0;

        public static void Run()
        {
            var program = new Week4_201813086_6();

            var t1 = new Thread(ThreadFunc);
            var t2 = new Thread(ThreadFunc);

            t1.Start(program);
            t2.Start(program);

            t1.Join();
            t2.Join();

            Console.WriteLine(program.num);
        }

        private static void ThreadFunc(object instance)
        {
            var program = instance as Week4_201813086_6;

            for (var i = 0; i < 10000; i++)
            {
                program.num++;
            }
        }
    }
}
