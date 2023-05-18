namespace Practice;

public class StreamWriteTest
{
    public static void Run()
    {
        var ms = new MemoryStream();
        var sw = new StreamWriter(ms, Encoding.UTF8);
        
        sw.WriteLine("Hello, World!");
        sw.WriteLine("MSH");
        sw.WriteLine(32000);
        
        sw.Flush();
        
        ms.Position = 0;
        
        var sr = new StreamReader();
        
        // TODO: Study StreamWriter, StreamReader
    }
}