using System.Text;

namespace k8s_tools;

public class CtxHelpCommand : BaseCommand
{
    public override void Execute(Executor cmd, Parameter[] _)
    {
        if (!Validate(_))
        {
            ConsoleWriter.WriteWarningToConsole("Too many arguments");
            return;
        }
        StringBuilder text= new();
        text.AppendLine($"-----HELP-Command Name:{cmd.Name}-----");
        text.AppendLine($"{cmd.Name} -h or --help will show help");
        text.AppendLine($"{cmd.Name} -l --list shows list of contexts");
        text.AppendLine($"{cmd.Name} - or --prev you can switch previous context");
        text.AppendLine($"{cmd.Name} + or --next you can switch next context");
        text.AppendLine($"{cmd.Name} -u or --unset you can current context to empty");
        text.AppendLine("usage of this command line interface");
        text.AppendLine("------END-HELP------");
        ConsoleWriter.WriteConsole(text.ToString(), ConsoleColor.Green);
    }
    public override bool Validate(Parameter[] parameters)
    {
        if (parameters.Any()) return false;
        return true;
    }
}
