namespace k8s_tools;
public class Command
{
    public Command(string name)
    {
        Name = name;
    }
    public Command(string name, Param p)
    {
        Name = name;
        AddParameters(p);
    }
    public string Name { get; private set; }
    public List<Param> Params { get; } =new List<Param>();
    public void AddParameters(Param p)
    {
        Params.Add(p);
    }
}
