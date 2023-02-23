namespace FilesAndDirectories;

class Append
{
    class WithFileAppendAllText
    {
        static void Log(string message)
        {
            File.AppendAllText(@"c:\temp\log.txt", message);
        }
    }

    class WithFileAppendAllLines
    {
        static void Log(string message)
        {
            File.AppendAllLines(@"c:\temp\log.txt", new[] { message });
        }
    }
}
