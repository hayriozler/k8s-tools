namespace k8s_tools;
public class CtxDeleteCommand : BaseCommand
{
    public override void Execute(Executor cmd, Parameter[] parameters)
    {
        ConsoleWriter.WriteWarningToConsole("not support yet");
    }

    public override bool Validate(Parameter[] parameters)
    {
        throw new NotImplementedException();
    }
}
