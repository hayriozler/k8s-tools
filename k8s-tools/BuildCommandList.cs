namespace k8s_tools;
public static class BuildCommandList
{
    private readonly static Dictionary<string, Command> commandList = new();
    public static Dictionary<string, Command> InitializeCommandList()
    {
        commandList.Clear();
        BuildCtxCommandList();
        BuildNsCommandList();
        return commandList;
    }
    private static void BuildCtxCommandList()
    {
        var command = new Command("k8s-ctx");
        command.AddParameters(new Param("h"));
        command.AddParameters(new Param("help"));
        commandList.Add(command.Name, command);
    }

    private static void BuildNsCommandList()
    {
        var command = new Command("k8s-na");
        command.AddParameters(new Param("h"));
        command.AddParameters(new Param("help"));
    }
}