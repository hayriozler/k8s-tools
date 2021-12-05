using k8s_tools;

var commandList = BuildExecutorList.InitializeCommandList();
if(args.Length < 0)
{
    ConsoleWriter.WriteErrorToConsole("No args defined");
    return;
}
if (args.Length > 3)
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
    //TODO find better way to handling arguments value;
    var arg = args.Length == 2 ? args[1] : args[2];
    executor.Exec(arg);
}
catch(Exception ex)
{
    ConsoleWriter.WriteErrorToConsole(ex.Message);
}