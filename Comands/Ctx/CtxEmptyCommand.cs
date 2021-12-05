namespace k8s_tools;

public class CtxEmptyCommand : BaseCommand
{
    public override void Execute(Executor _)
    {
        ConsoleWriter.WriteWarningToConsole("Could not find any command");
    }
}

