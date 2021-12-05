namespace k8s_tools;

public class HelpOperation : IOperation
{
    public void Execute(Command _)
    {
        Console.WriteLine("Help ---");
    }
}
