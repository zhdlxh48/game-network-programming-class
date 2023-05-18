using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class MemoryStreamTest
    {
        public static void Run()
        {
            // Serialize to MemoryStream (직렬화)
            var shortBytes = BitConverter.GetBytes((short)32000);
            var intBytes = BitConverter.GetBytes(1652300);

            var memoryStream = new MemoryStream();

            memoryStream.Write(shortBytes, 0, shortBytes.Length);
            memoryStream.Write(intBytes, 0, intBytes.Length);

            // Deserialize to Buffer (역직렬화)
            memoryStream.Position = 0;

            var buffer = new byte[sizeof(short)];
            memoryStream.Read(buffer, 0, sizeof(short));
            Console.WriteLine("Buffer Size: {0} / Result: {1}", buffer.Length, BitConverter.ToInt16(buffer, 0));
            buffer = new byte[sizeof(int)];
            memoryStream.Read(buffer, 0, sizeof(int));
            Console.WriteLine("Buffer Size: {0} / Result: {1}", buffer.Length, BitConverter.ToInt32(buffer, 0));
        }
    }
}
