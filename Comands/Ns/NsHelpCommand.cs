namespace k8s_tools;

public class NsHelpCommand : ICommand
{
    public void Execute(Executor _, Parameter[] parameters)
    {
        Console.WriteLine("Help ---");
    }

    public void Validate(Parameter[] parameters)
    {
        throw new NotImplementedException();
    }
}
