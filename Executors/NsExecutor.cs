namespace k8s_tools;
    
public class NsExecutor : Executor
{
    public NsExecutor(string name, ICommand operation)
        :base(name)
    {
        Operation = operation;
    }
    public ICommand Operation {get; private set;}
    public override void Exec(Parameter[] parameters)
    {
        Operation.Execute(this, parameters);
    }
}
