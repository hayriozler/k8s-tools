namespace k8s_tools;

public class CtxExecutor : Executor
{
    public CtxExecutor(string name, ICommand operation)
        :base(name)
    {
        Operation = operation;
    }
    public ICommand Operation { get; private set; }

    public override void Exec(Parameter[] arguments)
    {
        Operation.Execute(this, arguments);
    }
}
