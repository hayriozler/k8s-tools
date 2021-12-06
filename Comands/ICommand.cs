namespace k8s_tools;
public interface ICommand
{
    void Execute(Executor cmd, Parameter[] parameters);

}
