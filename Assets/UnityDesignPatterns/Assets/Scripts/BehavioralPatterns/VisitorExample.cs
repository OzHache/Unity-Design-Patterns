using UnityEngine;
using System.Collections.Generic;
public class VisitorExample : MonoBehaviour
{
    private void Start()
    {
        ObjectStructure objectStructure = new ObjectStructure();
        objectStructure.Attach(new ConcreteElementA());
        objectStructure.Attach(new ConcreteElementB());

        ConcreteVisitor1 concreteVisitor1 = new ConcreteVisitor1();
        objectStructure.Accept(concreteVisitor1);

        ConcreteVisitor2 concreteVisitor2 = new ConcreteVisitor2();
        objectStructure.Accept(concreteVisitor2);
    }
}
public abstract class Visitor
{
    public abstract void VisitConcreteElementA(ConcreteElementA concreteElementA);
    public abstract void VisitConcreteElementB(ConcreteElementB concreteElementB);
}

public class ConcreteVisitor1 : Visitor
{
    public override void VisitConcreteElementA(ConcreteElementA concreteElementA)
    {
        Debug.Log("ConcreteVisitor1 visited ConcreteElementA");
    }

    public override void VisitConcreteElementB(ConcreteElementB concreteElementB)
    {
        Debug.Log("ConcreteVisitor1 visited ConcreteElementB");
    }
}

public class ConcreteVisitor2 : Visitor
{
    public override void VisitConcreteElementA(ConcreteElementA concreteElementA)
    {
        Debug.Log("ConcreteVisitor2 visited ConcreteElementA");
    }

    public override void VisitConcreteElementB(ConcreteElementB concreteElementB)
    {
        Debug.Log("ConcreteVisitor2 visited ConcreteElementB");
    }
}

public abstract class Element
{
    public abstract void Accept(Visitor visitor);
}

public class ConcreteElementA : Element
{
    public override void Accept(Visitor visitor)
    {
        visitor.VisitConcreteElementA(this);
    }
}

public class ConcreteElementB : Element
{
    public override void Accept(Visitor visitor)
    {
        visitor.VisitConcreteElementB(this);
    }
}

public class ObjectStructure
{
    private List<Element> _elements = new List<Element>();

    public void Attach(Element element)
    {
        _elements.Add(element);
    }

    public void Detach(Element element)
    {
        _elements.Remove(element);
    }

    public void Accept(Visitor visitor)
    {
        foreach (var element in _elements)
        {
            element.Accept(visitor);
        }
    }
}