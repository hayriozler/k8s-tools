namespace k8s_tools;
public abstract class Executor
{
    public Executor(string name)
    {
        Name = name;
    }
    public string Name { get; private set; }
    public abstract void Exec(Parameter[] args);
}
