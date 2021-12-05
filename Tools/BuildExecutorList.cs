namespace k8s_tools;
public static class BuildExecutorList
{
    private readonly static Dictionary<string, List<Executor>> executorList = new();
    private const string k8s_ctx = "k8s-ctx";
    private const string k8s_ns = "k8s-ns";
    public static Dictionary<string, List<Executor>> InitializeCommandList()
    {
        executorList.Clear();
        BuildCtxExecutoreList();
        BuildNsExecutorList();
        return executorList;
    }
    private static void BuildCtxExecutoreList()
    {
        executorList.Add(k8s_ctx, new List<Executor> {
        new CtxExecutor(k8s_ctx, "-h", new CtxHelpCommand()),
        new CtxExecutor(k8s_ctx, "--help", new CtxHelpCommand()),
        new CtxExecutor(k8s_ctx, "-l", new CtxListCommand()),
        new CtxExecutor(k8s_ctx, "-list", new CtxListCommand()),
        new CtxExecutor(k8s_ctx, "-c", new CtxChangeContextCommand()),
        new CtxExecutor(k8s_ctx, "--change", new CtxChangeContextCommand()),
        new CtxExecutor(k8s_ctx, "-", new CtxPrevSelectCommand()),
        new CtxExecutor(k8s_ctx, "-p", new CtxPrevSelectCommand()),
        new CtxExecutor(k8s_ctx, "--prev", new CtxPrevSelectCommand()),
        new CtxExecutor(k8s_ctx, "+", new CtxNextSelectCommand()),
        new CtxExecutor(k8s_ctx, "-n", new CtxNextSelectCommand()),
        new CtxExecutor(k8s_ctx, "--next", new CtxNextSelectCommand()),
        new CtxExecutor(k8s_ctx, "-u", new CtxUnsetCommand()),
        new CtxExecutor(k8s_ctx, "--unset", new CtxUnsetCommand()),
        new CtxExecutor(k8s_ctx, "-d", new CtxDeleteCommand()),
        new CtxExecutor(k8s_ctx, "--delete", new CtxDeleteCommand()) });
     }

    private static void BuildNsExecutorList()
    {
        executorList.Add(k8s_ns, new List<Executor> { 
        new NsExecutor(k8s_ns, "-h", new NsHelpCommand()),
        new NsExecutor(k8s_ns, "--help", new NsHelpCommand())});
    }
}