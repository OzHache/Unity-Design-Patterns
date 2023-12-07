using UnityEngine;

public abstract class Product
{
    public abstract void Operation();
}

public class ConcreteProductA : Product
{
    public override void Operation()
    {
        Debug.Log("ConcreteProductA Operation");
    }
}

public class ConcreteProductB : Product
{
    public override void Operation()
    {
        Debug.Log("ConcreteProductB Operation");
    }
}

public abstract class Creator
{
    public abstract Product FactoryMethod();
}

public class ConcreteCreatorA : Creator
{
    public override Product FactoryMethod()
    {
        return new ConcreteProductA();
    }
}

public class ConcreteCreatorB : Creator
{
    public override Product FactoryMethod()
    {
        return new ConcreteProductB();
    }
}

public class FactoryMethodExample : MonoBehaviour
{
    void Start()
    {
        Creator[] creators = new Creator[2];
        creators[0] = new ConcreteCreatorA();
        creators[1] = new ConcreteCreatorB();

        foreach (Creator creator in creators)
        {
            Product product = creator.FactoryMethod();
            product.Operation();
        }
    }
}