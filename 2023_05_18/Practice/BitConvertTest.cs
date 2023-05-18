using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class BitConvertTest
    {
        public static void Run()
        {
            byte[] boolBytes = BitConverter.GetBytes(true);
            byte[] shortBytes = BitConverter.GetBytes((short)32000);
            byte[] intBytes = BitConverter.GetBytes(1652300);

            Console.WriteLine("Bit Encoded");
            Console.WriteLine(BitConverter.ToString(boolBytes));
            Console.WriteLine(BitConverter.ToString(shortBytes));
            Console.WriteLine(BitConverter.ToString(intBytes));

            bool boolResult = BitConverter.ToBoolean(boolBytes, 0);
            short shortResult = BitConverter.ToInt16(shortBytes, 0);
            int intResult = BitConverter.ToInt32(intBytes, 0);

            Console.WriteLine("Bit Decoded");
            Console.WriteLine(boolResult);
            Console.WriteLine(shortResult);
            Console.WriteLine(intResult);
        }
    }
}
