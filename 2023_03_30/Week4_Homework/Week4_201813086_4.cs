using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Homework
{
    // C# 기반 스레드 프로그램에서의 인자 전달
    public class Week4_201813086_4
    {
        public class ThreadParam
        {
            public int Value1;
            public int Value2;
        }

        public static void Run()
        {
            var t = new Thread(ThreadFunc);

            var param = new ThreadParam
            {
                Value1 = 10,
                Value2 = 20
            };

            t.Start(param);
        }

        private static void ThreadFunc(object paramObj)
        {
            var value = paramObj as ThreadParam;

            Console.WriteLine("{0}, {1}", value.Value1, value.Value2);
        }
    }
}
