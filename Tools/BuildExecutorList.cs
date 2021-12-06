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
        executorList.Add(k8s_ctx, 
        new List<Executor> 
        {
            new CtxExecutor("-h", new CtxHelpCommand()),
            new CtxExecutor("--help", new CtxHelpCommand()),
            new CtxExecutor("-l", new CtxListCommand()),
            new CtxExecutor("-list", new CtxListCommand()),
            new CtxExecutor("-c", new CtxChangeContextCommand()),
            new CtxExecutor("--change", new CtxChangeContextCommand()),
            new CtxExecutor("-", new CtxPrevSelectCommand()),
            new CtxExecutor("-p", new CtxPrevSelectCommand()),
            new CtxExecutor("--prev", new CtxPrevSelectCommand()),
            new CtxExecutor("+", new CtxNextSelectCommand()),
            new CtxExecutor("-n", new CtxNextSelectCommand()),
            new CtxExecutor("--next", new CtxNextSelectCommand()),
            new CtxExecutor("-u", new CtxUnsetCommand()),
            new CtxExecutor("--unset", new CtxUnsetCommand()),
            new CtxExecutor("-r", new CtxRenameCommand()),
            new CtxExecutor("--rename", new CtxRenameCommand()),
            new CtxExecutor("-d", new CtxDeleteCommand()),
            new CtxExecutor("--delete", new CtxDeleteCommand()) 
        });
     }

    private static void BuildNsExecutorList()
    {
        executorList.Add(k8s_ns, new List<Executor> { 
        new NsExecutor("-h", new NsHelpCommand()),
        new NsExecutor("--help", new NsHelpCommand())});
    }
}
