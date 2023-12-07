using UnityEngine;

public abstract class MyComponent
{
    public abstract void Operation();
}

public class ConcreteComponent : MyComponent
{
    public override void Operation()
    {
        Debug.Log("ConcreteComponent.Operation()");
    }
}

public abstract class Decorator : MyComponent
{
    protected MyComponent component;

    public void SetComponent(MyComponent component)
    {
        this.component = component;
    }

    public override void Operation()
    {
        if (component != null)
        {
            component.Operation();
        }
    }
}

public class ConcreteDecoratorA : Decorator
{
    public override void Operation()
    {
        base.Operation();
        Debug.Log("ConcreteDecoratorA.Operation()");
    }
}

public class ConcreteDecoratorB : Decorator
{
    public override void Operation()
    {
        base.Operation();
        Debug.Log("ConcreteDecoratorB.Operation()");
    }
}

public class DecoratorExample : MonoBehaviour
{
    void Start()
    {
        ConcreteComponent c = new ConcreteComponent();
        ConcreteDecoratorA d1 = new ConcreteDecoratorA();
        ConcreteDecoratorB d2 = new ConcreteDecoratorB();

        d1.SetComponent(c);
        d2.SetComponent(d1);

        d2.Operation();
    }
}