namespace k8s_tools;

public class NsEmptyCommand : ICommand
{
    public void Execute(Executor _, Parameter[] parameters)
    {
        Console.WriteLine("Help ---");
    }

    public void Validate(Parameter[] _)
    {
        throw new NotImplementedException();
    }
}
