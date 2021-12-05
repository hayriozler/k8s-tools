namespace k8s_tools;

public class KubeConfig
{
    public string ApiVersion { get; set; }
    public List<Context> Contexts { get; set; } = new List<Context>();
    public string CurrentContext { get; set; }
}

public class Context
{
    public string Name { get; set; }
}
