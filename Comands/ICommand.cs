namespace k8s_tools;
public interface ICommand
{
    public bool IsParameterValueRequired { get; }
    void Execute(Executor cmd);

}
