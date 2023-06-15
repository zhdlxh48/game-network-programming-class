using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class FileStreamTest
    {
        public static void Run() 
        {
            var path = @"C:\windows\system32\drivers\etc\HOSTS";

            ReadAwaitable(path);

            Console.ReadLine();
        }

        private static async void ReadAwaitable(string path)
        {
            using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                var buffer = new byte[fileStream.Length];
                // fileStream.Read(buffer, 0, buffer.Length);
                await fileStream.ReadAsync(buffer, 0, buffer.Length);

                var text = Encoding.UTF8.GetString(buffer);
                Console.WriteLine(text);
            }
        }
    }
}
