namespace k8s_tools;

public class NsHelpCommand : ICommand
{
    public bool IsParameterValueRequired => false;

    public void Execute(Executor _)
    {
        Console.WriteLine("Help ---");
    }
}
