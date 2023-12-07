using UnityEngine;
public class TemplateMethodExample : MonoBehaviour
{
    private void Start()
    {
        TemplateMethodClass concreteClassA = new GameObject("ConcreteClassA").AddComponent<ConcreteClassA>();
        concreteClassA.TemplateMethod();

        TemplateMethodClass concreteClassB = new GameObject("ConcreteClassB").AddComponent<ConcreteClassB>();
        concreteClassB.TemplateMethod();
    }
}
public abstract class TemplateMethodClass : MonoBehaviour
{
    // Template method
    public void TemplateMethod()
    {
        BaseOperation();
        StepOne();
        StepTwo();
        Hook();
    }

    // Base operation (common for all subclasses)
    void BaseOperation()
    {
        Debug.Log("Base operation");
    }

    // Abstract methods (must be implemented by subclasses)
    protected abstract void StepOne();
    protected abstract void StepTwo();

    // Hook (can be overridden by subclasses, but it's not mandatory)
    protected virtual void Hook() { }
}

public class ConcreteClassA : TemplateMethodClass
{
    protected override void StepOne()
    {
        Debug.Log("ConcreteClassA: Step One");
    }

    protected override void StepTwo()
    {
        Debug.Log("ConcreteClassA: Step Two");
    }

    protected override void Hook()
    {
        Debug.Log("ConcreteClassA: Hook");
    }
}

public class ConcreteClassB : TemplateMethodClass
{
    protected override void StepOne()
    {
        Debug.Log("ConcreteClassB: Step One");
    }

    protected override void StepTwo()
    {
        Debug.Log("ConcreteClassB: Step Two");
    }
}