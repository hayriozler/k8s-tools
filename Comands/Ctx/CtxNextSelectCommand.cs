namespace k8s_tools;

public class CtxNextSelectCommand : ICommand
{
    public bool IsParameterValueRequired => false;
    public void Execute(Executor cmd)
    {
        var kubeConfig = KubeConfigHelper.GetKubeContext();
        var currentContext = kubeConfig.CurrentContext.Value;
        int i = 0;
        foreach (var ctx in kubeConfig.Contexts)
        {
            if (currentContext == ctx.Item.Value)
            {
                i++;
                if (i >= kubeConfig.Contexts.Count)
                    i = 0;
                break;
            }
            i++;
        }
        SwitchContext(kubeConfig, kubeConfig.Contexts[i]);
    }
    private static void SwitchContext(KubeConfig kubeConfig, Context ctx)
    {
        try
        {
            if (kubeConfig.CurrentContext.Value != ctx.Item.Value)
            {
                KubeConfigHelper.WriteKubeConfig($"current-context: {ctx.Item.Value}", kubeConfig.CurrentContext.BeginOffset, kubeConfig.CurrentContext.FullText.Length);
            }
        }
        catch (Exception e)
        {
            ConsoleWriter.WriteErrorToConsole(e.Message);
        }
    }
}