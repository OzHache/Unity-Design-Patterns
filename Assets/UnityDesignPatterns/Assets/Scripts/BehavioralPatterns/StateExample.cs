using UnityEngine;

public class StateExample : MonoBehaviour
{
    private IState currentState;

    private void Start()
    {
        currentState = new ConcreteStateA(this);
    }

    private void Update()
    {
        currentState.Handle();
    }

    public void SetState(IState state)
    {
        currentState = state;
    }
}

public interface IState
{
    void Handle();
}

public class ConcreteStateA : IState
{
    private readonly StateExample context;

    public ConcreteStateA(StateExample context)
    {
        this.context = context;
    }

    public void Handle()
    {
        Debug.Log("Handling in State A");
        context.SetState(new ConcreteStateB(context));
    }
}

public class ConcreteStateB : IState
{
    private readonly StateExample context;

    public ConcreteStateB(StateExample context)
    {
        this.context = context;
    }

    public void Handle()
    {
        Debug.Log("Handling in State B");
        context.SetState(new ConcreteStateA(context));
    }
}