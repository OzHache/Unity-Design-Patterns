using UnityEngine;
//This is the client class
public class PrototypeExample : MonoBehaviour
{
    void Start()
    {
        GameObject prototype1Object = new GameObject("Prototype1");
        ConcretePrototype1 prototype1 = prototype1Object.AddComponent<ConcretePrototype1>();
        ConcretePrototype1 clone1 = prototype1.Clone() as ConcretePrototype1;

        GameObject prototype2Object = new GameObject("Prototype2");
        ConcretePrototype2 prototype2 = prototype2Object.AddComponent<ConcretePrototype2>();
        ConcretePrototype2 clone2 = prototype2.Clone() as ConcretePrototype2;
    }
}
public abstract class PrototypeExampleClass : MonoBehaviour
{
    public abstract PrototypeExampleClass Clone();
}

public class ConcretePrototype1 : PrototypeExampleClass
{
    public override PrototypeExampleClass Clone()
    {
        Debug.Log("ConcretePrototype1: Clone");
        return Instantiate(this);
    }
}

public class ConcretePrototype2 : PrototypeExampleClass
{
    public override PrototypeExampleClass Clone()
    {
        Debug.Log("ConcretePrototype2: Clone");
        return Instantiate(this);
    }
}
