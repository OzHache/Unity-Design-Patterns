using UnityEngine;
public class MediatorExample : MonoBehaviour{
    //This class is just for the example and not part of the pattern
  private void Start()
    {
        // Instantiate the mediator
        GameObject mediatorObject = new GameObject("Mediator");

        ConcreteMediator mediator = mediatorObject.AddComponent<ConcreteMediator>();

        // Instantiate the colleagues
        ConcreteColleague1 colleague1 = new ConcreteColleague1(mediator);
        ConcreteColleague2 colleague2 = new ConcreteColleague2(mediator);

        // Assign the colleagues to the mediator
        mediator.Colleague1 = colleague1;
        mediator.Colleague2 = colleague2;
    }
}
public abstract class Mediator : MonoBehaviour
{
    public abstract void Send(string message, Colleague colleague);
}

public abstract class Colleague
{
    protected Mediator mediator;

    public Colleague(Mediator mediator)
    {
        this.mediator = mediator;
    }
}

public class ConcreteMediator : Mediator
{
    private ConcreteColleague1 colleague1;
    private ConcreteColleague2 colleague2;

    public ConcreteColleague1 Colleague1
    {
        set { colleague1 = value; }
    }

    public ConcreteColleague2 Colleague2
    {
        set { colleague2 = value; }
    }

    public override void Send(string message, Colleague colleague)
    {
        if (colleague == colleague1)
        {
            colleague2.Notify(message);
        }
        else
        {
            colleague1.Notify(message);
        }
    }
    void Start(){
        //send message to colleague 1
        Send("Hi Colleague 1", colleague1);
        //send message to colleague 2
        Send("Hi Colleague 2", colleague2);
    }
}

public class ConcreteColleague1 : Colleague
{
    public ConcreteColleague1(Mediator mediator) : base(mediator) { }

    public void Send(string message)
    {
        mediator.Send(message, this);
    }

    public void Notify(string message)
    {
        Debug.Log("Colleague1 gets message: " + message);
        //If the message contains Bye then say until next time
        if (message.Contains("Bye"))
        {
            Send("Until next time");
        }
    }
}

public class ConcreteColleague2 : Colleague
{
    public ConcreteColleague2(Mediator mediator) : base(mediator) { }

    public void Send(string message)
    {
        mediator.Send(message, this);
    }

    public void Notify(string message)
    {
        Debug.Log("Colleague2 gets message: " + message);
        //If the message contains Hi then say bye
        if (message.Contains("Hi"))
        {
            Send("Bye");
        }
    }
}