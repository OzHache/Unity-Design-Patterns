using System.Collections.Generic;
using UnityEngine;

public abstract class ComponentClass
{
    protected string name;

    public ComponentClass(string name)
    {
        this.name = name;
    }

    public abstract void Add(ComponentClass c);
    public abstract void Remove(ComponentClass c);
    public abstract void Display(int depth);
}

public class Composite : ComponentClass
{
    private List<ComponentClass> _children = new List<ComponentClass>();

    public Composite(string name)
        : base(name)
    {
    }

    public override void Add(ComponentClass component)
    {
        _children.Add(component);
    }

    public override void Remove(ComponentClass component)
    {
        _children.Remove(component);
    }

    public override void Display(int depth)
    {
        Debug.Log(new string('-', depth) + name);

        foreach (ComponentClass component in _children)
        {
            component.Display(depth + 2);
        }
    }
}

public class Leaf : ComponentClass
{
    public Leaf(string name)
        : base(name)
    {
    }

    public override void Add(ComponentClass c)
    {
        Debug.Log("Cannot add to a leaf");
    }

    public override void Remove(ComponentClass c)
    {
        Debug.Log("Cannot remove from a leaf");
    }

    public override void Display(int depth)
    {
        Debug.Log(new string('-', depth) + name);
    }
}

public class CompositeExample : MonoBehaviour
{
    void Start()
    {
        Composite root = new Composite("root");
        root.Add(new Leaf("Leaf A"));
        root.Add(new Leaf("Leaf B"));

        Composite comp = new Composite("Composite X");
        comp.Add(new Leaf("Leaf XA"));
        comp.Add(new Leaf("Leaf XB"));

        root.Add(comp);
        root.Add(new Leaf("Leaf C"));

        Leaf leaf = new Leaf("Leaf D");
        root.Add(leaf);
        root.Remove(leaf);

        root.Display(1);
    }
}