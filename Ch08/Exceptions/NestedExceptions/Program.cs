namespace NestedExceptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            ShowFirstLineLength(@"C:\Temp\File.txt");
        }
        catch (NullReferenceException)
        {
            Console.WriteLine("NullReferenceException");
        }
    }

    static void ShowFirstLineLength(string fileName)
    {
        try
        {
            using (var r = new StreamReader(fileName))
            {
                try
                {
                    Console.WriteLine(r.ReadLine()!.Length);
                }
                catch (IOException ex)
                {
                    Console.WriteLine("Error while reading file: {0}",
                        ex.Message);
                }
            }
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine("Couldn't find the file '{0}'", ex.FileName);
        }
    }
}