namespace k8s_tools;
public class CtxListCommand : ICommand
{
    public bool IsParameterValueRequired => false;
    public void Execute(Executor cmd)
    {
        ConsoleWriter.WriteConsole($"Command: {cmd.Name} ", ConsoleColor.Green);
        ConsoleWriter.WriteConsole("----Result---", ConsoleColor.Green);
        var kubeConfig = KubeConfigHelper.GetKubeContext();
        foreach(var k in kubeConfig.Contexts)
        {
            ConsoleWriter.WriteConsole(k.Item.Value);
        }
        ConsoleWriter.WriteConsole("----End---", ConsoleColor.Green);
        Console.ReadKey();
    }
}
