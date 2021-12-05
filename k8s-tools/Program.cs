using System.Linq;
using k8s_tools;

var commandList = BuildCommandList.InitializeCommandList();
if(args.Length == 0)
{
    ConsoleWriter.WriteConsole("No args defined will be execute default behavour");
}
var mainCommand = args[0]; // main command such as k8s-ctx
if(!commandList.ContainsKey(mainCommand)){
    ConsoleWriter.WriteErrorToConsole("Command not found");
    return;
}
else{
    var command = commandList[mainCommand];
    ConsoleWriter.WriteConsole($"Command found Name: {command.Name}");
    var commandArg = args[1];
    ConsoleWriter.WriteConsole(commandArg);
}