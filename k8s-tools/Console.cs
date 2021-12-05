namespace k8s_tools;
public static class ConsoleWriter{
    public static void WriteConsole(string txt, ConsoleColor color = ConsoleColor.Blue){
        Console.ForegroundColor = color;
        Console.WriteLine(txt+ Environment.NewLine);
        Console.ResetColor();
    }
    public static void WriteErrorToConsole(string txt){
        WriteConsole(txt, ConsoleColor.Red);
    }
    public static void WriteWarningToConsole(string txt){
        WriteConsole(txt, ConsoleColor.Yellow);
    }
}