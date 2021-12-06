namespace k8s_tools;
public class CtxPrevSelectCommand : BaseCommand
{
    public override void Execute(Executor cmd, Parameter[] parameters)
    {
        if (!Validate(parameters))
        {
            ConsoleWriter.WriteWarningToConsole("Too many arguments");
            return;
        }
        var kubeConfig = KubeConfigHelper.GetKubeContext();
        var currentContext = kubeConfig.CurrentContext.Value;
        int i = kubeConfig.Contexts.Count;
        foreach (var ctx in kubeConfig.Contexts)
        {
            if (currentContext == ctx.Item.Value)
            {
                i--;
                if (i <= 0)
                    i = 0;
                break;
            }
            i--;
        }
        SwitchContext(kubeConfig, kubeConfig.Contexts[i]);
    }

    public override bool Validate(Parameter[] parameters)
    {
        if (parameters.Any()) return false;
        return true;
    }
}
