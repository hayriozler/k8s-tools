namespace k8s_tools;
    
public class NsExecutor : Executor
{
    public NsExecutor(string name, string parameterName, ICommand operation)
        :base(name, parameterName)
    {
        Name = name;
        Operation = operation;
    }
    public ICommand Operation {get; private set;}
    public override void Exec(string value)
    {
        ParameterValue = value;
        Operation.Execute(this);
    }
}
