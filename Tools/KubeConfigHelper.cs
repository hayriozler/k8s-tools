using System.Text;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace k8s_tools;
public static class KubeConfigHelper
{
    private static string KubeConfigPath()
    {
        if (OsHelper.IsLinux() || OsHelper.IsMacOS())
        {
            return Environment.GetEnvironmentVariable("HOME") + OsHelper.FileSeperator + ".KUBECONFIG";
        }
        return Environment.GetEnvironmentVariable("HOMEPATH") + OsHelper.FileSeperator + ".kube" + OsHelper.FileSeperator + "config";
    }
    private static string GetKubeConfigFile()
    {
        var filePath = KubeConfigPath();
        if (!IOHelper.IsFileExists(filePath))
        {
            throw new Exception("KubeConfig file could not find");
        }
        return filePath;
    }
    private static List<Context> ToContexts(Dictionary<object, object> obj, string content)
    {
        List<Context> contexts = new();
        foreach (var listItem in (List<object>)obj["contexts"])
        {
            var item = (Dictionary<object, object>)listItem;
            var name = item["name"].ToString();
            var indexOf = content.ToString().IndexOf("contexts:");
            contexts.Add(new Context
            {
                Item = new YamlNodeInformation
                {
                    Value = name,
                    FullText = $"name: {name}",
                    BeginOffset = GetOffset(content, $"name: {name}", indexOf),
                }
            });
        }
        return contexts;
    }
    private static int GetOffset(string content, string value, int begin)
    {
        var indParentNode = content.ToString().IndexOf(value, begin);
        if (indParentNode > 0)
        {
            var beginOffSet = begin == 0 ? indParentNode : content.ToString().IndexOf(value, indParentNode);
            return beginOffSet;
        }
        return 0;
    }
    public static KubeConfig GetKubeContext()
    {
        //TODO investigate better yaml deserializer,
        //existing package look like does not support partly deserialization
        var deserializer = new DeserializerBuilder().WithNamingConvention(PascalCaseNamingConvention.Instance).Build();
        using var reader = IOHelper.Read(GetKubeConfigFile());
        var obj = (Dictionary<object, object>)deserializer.Deserialize(reader.Reader);
        return new KubeConfig
        {
            CurrentContext = new YamlNodeInformation
            {
                Value = obj["current-context"].ToString(),
                FullText = $"current-context: {obj["current-context"]}",
                BeginOffset = GetOffset(reader.Content, $"current-context: {obj["current-context"]}", 0),//this must be start from beging of the file,
            },
            Contexts = ToContexts(obj, reader.Content)
        };
    }

    public static void WriteKubeConfig(string value, int begin, int len)
    {
        var configFilePath = GetKubeConfigFile();
        var readFile = IOHelper.Read(configFilePath);
        var content = readFile.Content;
        readFile.Dispose();
        content = content.Remove(begin, len);
        content = content.Insert(begin, value);
        IOHelper.Write(configFilePath, content);
    }
}
