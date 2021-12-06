namespace k8s_tools;

public class CtxEmptyCommand : BaseCommand
{
    public override void Execute(Executor _, Parameter[] __)
    {
        ConsoleWriter.WriteWarningToConsole("Could not find any command");
    }

    public override bool Validate(Parameter[] _)
    {
        throw new NotImplementedException();
    }
}

