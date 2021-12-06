using k8s_tools;

var commandList = BuildExecutorList.InitializeCommandList();
if(args.Length < 0)
{
    ConsoleWriter.WriteErrorToConsole("No args defined");
    return;
}

var arg = args[0]; // main command such as k8s-ctx
if(!commandList.ContainsKey(arg)){
    ConsoleWriter.WriteErrorToConsole($"{arg} main command not found.");
    return;
}
List<string> arguments = new(); 
var executionList = commandList[arg];
if(!executionList.Any())
{
    ConsoleWriter.WriteErrorToConsole($"{arg} main command not found.");
    return;
}
Executor executor = null;
List<Parameter> parameters = new();
if (args.Length > 1) // k8s_tools --change value
{
    executor = executionList.FirstOrDefault(p => p.Name == args[1]);
    for (var i = 2; i < args.Length; i++)
    {
        parameters.Add(new Parameter { Value = args[i] });
    }
}
else
{
    executor = executionList.First(p => p.Name == "-l");//default behavour if no parameters deefined;
}
try
{
    executor?.Exec(parameters.ToArray());
}
catch(Exception ex)
{
    ConsoleWriter.WriteErrorToConsole(ex.Message);
}