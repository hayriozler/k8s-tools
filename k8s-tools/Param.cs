namespace k8s_tools;
public class Param
{
    public Param(string value)
    {
        Value = value;
    }
    public string Value { get; private set; }
}