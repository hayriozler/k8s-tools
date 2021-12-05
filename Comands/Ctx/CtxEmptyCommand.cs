namespace k8s_tools;

public class CtxEmptyCommand : ICommand
{
    public CtxEmptyCommand()
    {
    }

    public bool IsParameterValueRequired => false;

    public void Execute(Executor _)
    {
        ConsoleWriter.WriteWarningToConsole("Could not find any command");
    }
}

