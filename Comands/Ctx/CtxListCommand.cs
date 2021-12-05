namespace k8s_tools;
public class CtxListCommand : ICommand
{
    public bool IsParameterValueRequired => false;
    public void Execute(Executor cmd)
    {
        ConsoleWriter.WriteConsole($"Command: {cmd.Name} ", ConsoleColor.Green);//0
        var kubeConfig = KubeConfigHelper.GetKubeContext();
        int optionsCount = kubeConfig.Contexts.Count;
        int selected = 0;
        DrawContext(selected, kubeConfig);
        bool done = false;
        while (!done)
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.UpArrow:
                    selected = Math.Max(0, selected - 1);
                    DrawContext(selected, kubeConfig);
                    break;
                case ConsoleKey.DownArrow:
                    selected = Math.Min(optionsCount - 1, selected + 1);
                    DrawContext(selected, kubeConfig);
                    break;
                case ConsoleKey.Enter:
                    done = true;
                    break;
            }
        }
    }
    private static void DrawContext(int selected,KubeConfig kubeConfig)
    {
        Console.Clear();
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
}

