namespace k8s_tools;

public class NsEmptyCommand : ICommand
{
    public bool IsParameterValueRequired => false;

    public void Execute(Executor _)
    {
        Console.WriteLine("Help ---");
    }
}
