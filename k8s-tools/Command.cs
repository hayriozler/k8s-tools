namespace k8s_tools;
public class Command
{
    public Command(string name)
    :this(name, new EmptyOperation())
    {
        Name = name;
    }
    public Command(string name, IOperation op)
    :this(name, op, new EmptyParam(""))
    {
        Name = name;
    }
    public Command(string name,IOperation op,  Param p)
    {
        Name = name;
        AddParameters(p);
        Operation=op;
    }
    public IOperation Operation { get;}
    public string Name { get; private set; }
    public List<Param> Params { get; } =new List<Param>();
    public void AddParameters(Param p)
    {
        Params.Add(p);
    }
}
