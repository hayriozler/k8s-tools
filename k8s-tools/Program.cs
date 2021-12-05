using k8s_tools;

var commandList = BuildCommandList.InitializeCommandList();
if(args.Length == 0)
{
    ConsoleWriter.WriteErrorToConsole("No args defined");
    return;
}

var mainCommand = args[0]; // main command such as k8s-ctx

if(!commandList.ContainsKey(mainCommand)){
    ConsoleWriter.WriteErrorToConsole("Command not found");
    return;
}

var command = commandList[mainCommand];
var commandArg = args[1];
command.Operation.Execute()