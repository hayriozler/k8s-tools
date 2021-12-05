namespace k8s_tools;
public class CtxNextSelectCommand : BaseCommand
{
    public override void Execute(Executor cmd)
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
    
}