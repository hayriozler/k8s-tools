namespace k8s_tools;

public static class IOHelper
{
    public static bool IsFileExists(string fileName)
    {
        return (File.Exists(fileName));
    }
    public static ReadResult Read(string filePath)
    {
        var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        var reader = new StreamReader(fs);
        fs.Position = 0;
        var readResult =  new ReadResult
        {
            Reader = reader,
            Content = reader.ReadToEnd()
        };
        fs.Position = 0;
        return readResult;
    }
    public static void Write(string filePath, string content)
    {
        File.WriteAllText(filePath, content);
    }
}
