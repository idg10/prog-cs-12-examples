using (FileStream fs = File.Create("foo.bar"))
{
}

// Equivalent code without using File class
using (var fs = new FileStream("foo.bar", FileMode.Create,
                                FileAccess.ReadWrite, FileShare.None))
{
}
