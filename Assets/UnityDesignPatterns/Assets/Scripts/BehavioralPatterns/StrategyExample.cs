using UnityEngine;
public class StrategyExample : MonoBehaviour
{
    private void Start()
    {
        Context context;

        // Three contexts following different strategies
        GameObject concreteStrategyA = new GameObject("ConcreteStrategyA");
        StrategyExamplePattern a = concreteStrategyA.AddComponent<ConcreteStrategyA>();
        context = new Context(a);
        context.ContextInterface();

        GameObject concreteStrategyB = new GameObject("ConcreteStrategyB");
        StrategyExamplePattern b = concreteStrategyB.AddComponent<ConcreteStrategyB>();
        context = new Context(b);
        context.ContextInterface();

        GameObject concreteStrategyC = new GameObject("ConcreteStrategyC");
        StrategyExamplePattern c = concreteStrategyC.AddComponent<ConcreteStrategyC>();
        context = new Context(c);
        context.ContextInterface();
    }
}
public abstract class StrategyExamplePattern : MonoBehaviour
{
    public abstract void AlgorithmInterface();
}

public class ConcreteStrategyA : StrategyExamplePattern
{
    public override void AlgorithmInterface()
    {
        Debug.Log("ConcreteStrategyA.AlgorithmInterface()");
    }
}

public class ConcreteStrategyB : StrategyExamplePattern
{
    public override void AlgorithmInterface()
    {
        Debug.Log("ConcreteStrategyB.AlgorithmInterface()");
    }
}

public class ConcreteStrategyC : StrategyExamplePattern
{
    public override void AlgorithmInterface()
    {
        Debug.Log("ConcreteStrategyC.AlgorithmInterface()");
    }
}

public class Context
{
    private StrategyExamplePattern strategy;

    public Context(StrategyExamplePattern strategy)
    {
        this.strategy = strategy;
    }

    public void ContextInterface()
    {
        strategy.AlgorithmInterface();
    }
}