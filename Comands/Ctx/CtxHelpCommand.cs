using System.Text;

namespace k8s_tools;

public class CtxHelpCommand : ICommand
{
    public bool IsParameterValueRequired => false;

    public void Execute(Executor cmd)
    {
        StringBuilder text= new();
        text.AppendLine($"-----HELP-Command Name:{cmd.Name}-----");
        text.AppendLine($"{cmd.Name} -h");
        text.AppendLine($"{cmd.Name} --help");
        text.AppendLine("usage of this command line interface");
        text.AppendLine("------END-HELP------");
        ConsoleWriter.WriteConsole(text.ToString(), ConsoleColor.Green);
    }
}
