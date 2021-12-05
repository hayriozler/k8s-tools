namespace k8s_tools;

public class CtxExecutor : Executor
{
    public CtxExecutor(string name, string parameterName, ICommand operation)
        :base(name, parameterName)
    {
        Name = name;
        ParameterName = parameterName;
        Operation = operation;
    }
    public ICommand Operation { get; private set; }

    public override void Exec(string value)
    {
        ParameterValue = value;
        Operation.Execute(this);
    }
}
