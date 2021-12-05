using k8s_tools;

var commandList = BuildExecutorList.InitializeCommandList();
if(args.Length < 0)
{
    ConsoleWriter.WriteErrorToConsole("No args defined");
    return;
}
if (args.Length > 2)
{
    ConsoleWriter.WriteErrorToConsole("Multiple arguments defined");
    return;
}

var mainExecutorText = args[0]; // main command such as k8s-ctx
if(!commandList.ContainsKey(mainExecutorText)){
    ConsoleWriter.WriteErrorToConsole($"{mainExecutorText} main command not found.");
    return;
}
if(args.Length == 1) //Default help method execute;
{
    ConsoleWriter.WriteErrorToConsole("Parameter could not find, to see avaiable list of commands please use -h");
    return;
}
var mainExecutor = commandList[mainExecutorText];
var executor = mainExecutor.FirstOrDefault(p => p.ParameterName == args[1]);
if(executor is null)
{
    ConsoleWriter.WriteErrorToConsole("Parameter could not find, to see avaiable list of commands please use -h");
    return;
}
try
{
    executor.Exec(args[1]);
}
catch(Exception ex)
{
    ConsoleWriter.WriteErrorToConsole(ex.Message);
}