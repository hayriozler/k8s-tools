using System.Collections;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace k8s_tools;
public static class CtxHelper
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
    public static KubeConfig GetKubeContext()
    {
        //TODO investigate better yaml deseializer,
        //existing package look like does not deserialize partilly
        var deserializer = new DeserializerBuilder().WithNamingConvention(PascalCaseNamingConvention.Instance).Build();
        using var reader = IOHelper.Read(GetKubeConfigFile());
        var obj = (Dictionary<object, object>)deserializer.Deserialize(reader);
        
        return new KubeConfig
        {
            ApiVersion = obj["apiVersion"].ToString(),
            CurrentContext = obj["current-context"].ToString(),
            Contexts = ToContexts(obj)
        };
    }
    private static List<Context> ToContexts(Dictionary<object, object> obj)
    {
        List<Context> contexts = new();
        foreach (var listItem in (List<object>)obj["contexts"])
        {
            var item =(Dictionary<object, object>)listItem;
            contexts.Add(new Context
            {
                Name = item["name"].ToString(),
            });
        }
        return contexts;
    }
    public static void WriteKubeConfig(KubeConfig kubeConfig)
    {
        var serializer = new SerializerBuilder().WithNamingConvention(CamelCaseNamingConvention.Instance).Build();
        using var fs = new FileStream(GetKubeConfigFile(), FileMode.Open, FileAccess.ReadWrite);
        var content = serializer.Serialize(kubeConfig);
    }

}
