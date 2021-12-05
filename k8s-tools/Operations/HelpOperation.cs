namespace k8s_tools;

public class HelpOperation : IOperation
{
    public Command command => throw new NotImplementedException();

    public void Execute()
    {
        Console.WriteLine("Help ---");
    }
}
