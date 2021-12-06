namespace k8s_tools;
public class CtxListCommand : BaseCommand
{
    public override void Execute(Executor cmd, Parameter[] parameters)
    {
        if (!Validate(parameters))
        {
            ConsoleWriter.WriteWarningToConsole("Too many arguments");
            return;
        }
        var name = cmd.Name;
        var kubeConfig = KubeConfigHelper.GetKubeContext();
        int selected = 0;
        DrawContext(selected, kubeConfig, name);
        bool done = false;
        while (!done)
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.UpArrow:
                    selected = Math.Max(0, selected - 1);
                    DrawContext(selected, kubeConfig, name);
                    break;
                case ConsoleKey.DownArrow:
                    selected = Math.Min(kubeConfig.Contexts.Count - 1, selected + 1);
                    DrawContext(selected, kubeConfig, name);
                    break;
                case ConsoleKey.Enter:
                    SwitchContext(kubeConfig, kubeConfig.Contexts[selected]);
                    done = true;
                    break;
            }
        }
    }
    private static void DrawContext(int selected, KubeConfig kubeConfig, string cmdName)
    {
        Console.Clear();
        ConsoleWriter.WriteConsole($"Command: {cmdName} ", ConsoleColor.Green);//0
        ConsoleWriter.WriteConsole("----Result---", ConsoleColor.Green);//1
        for (int i = 0; i < kubeConfig.Contexts.Count; i++)
        {
            if (selected == i)
            {
                ConsoleWriter.WriteConsole($"=>  {kubeConfig.Contexts[i].Item.Value}", ConsoleColor.Cyan);
            }
            else
            {
                ConsoleWriter.WriteConsole(kubeConfig.Contexts[i].Item.Value, ConsoleColor.Blue);
            }
        }
        ConsoleWriter.WriteConsole("----End---", ConsoleColor.Green);
        ConsoleWriter.ResetColor();
    }

    public override bool Validate(Parameter[] parameters)
    {
        if (parameters.Any()) return false;
        return true;
    }
}

