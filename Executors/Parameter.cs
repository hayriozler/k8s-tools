﻿namespace k8s_tools;
public class Parameter
{
    public Parameter(string name, string value)
    {
        Name = name;
        Value = value;
    }
    public string Name { get; private set; }
    public string Value { get; private set; }
}
