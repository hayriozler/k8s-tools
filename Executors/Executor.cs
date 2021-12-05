namespace k8s_tools;
public abstract class Executor
{
    public Executor(string name, string parameterName)
    {
        Name = name;
        ParameterName = parameterName;
    }
    public string Name { get; internal set; }
    public string ParameterName { get; internal set; }
    public string ParameterValue { get; internal set; } = string.Empty;
    public abstract void Exec(string value);
}