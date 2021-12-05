namespace k8s_tools;
public class CtxDeleteCommand : BaseCommand
{
    public override void Execute(Executor cmd)
    {
        var kubeConfig = KubeConfigHelper.GetKubeContext();
        Context? context = null;
        foreach (var ctx in kubeConfig.Contexts)
        {
            if (ctx.Item.Value == cmd.ParameterValue)
            {
                context = ctx;
                break;
            }
        }
        if (context is not null)
            KubeConfigHelper.WriteKubeConfig($"- context: {context.Item.Value}", context.Item.BeginOffset, context.Item.FullText.Length);
        else
            ConsoleWriter.WriteWarningToConsole("Requested Context could not found");
    }
}
