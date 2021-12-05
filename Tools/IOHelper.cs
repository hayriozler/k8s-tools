namespace k8s_tools;

public static class IOHelper
{
    public static bool IsFileExists(string fileName)
    {
        return (File.Exists(fileName));
    }
    public static TextReader Read(string filePath)
    {
        var fs = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite);
        return new StreamReader(fs);

    }
}
