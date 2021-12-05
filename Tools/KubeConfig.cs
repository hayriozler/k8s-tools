namespace k8s_tools;

public class KubeConfig
{
    public List<Context> Contexts { get; set; } = new List<Context>();
    public YamlNodeInformation CurrentContext { get; set; }
}

public class Context
{
    public YamlNodeInformation Item { get; set; }
}
public class YamlNodeInformation
{
    public string Value { get; set; }
    public string FullText { get; set; }
    public int BeginOffset { get; set; } 
}