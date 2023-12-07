using UnityEngine;

public abstract class Handler : MonoBehaviour
{
    protected Handler successor;

    public void SetSuccessor(Handler successor)
    {
        this.successor = successor;
    }

    public abstract void HandleRequest(int request);
}

public class ConcreteHandler1 : Handler
{
    public override void HandleRequest(int request)
    {
        if (request >= 0 && request < 10)
        {
            Debug.Log($"{this.GetType().Name} handled request {request}");
        }
        else if (successor != null)
        {
            successor.HandleRequest(request);
        }
    }
}

public class ConcreteHandler2 : Handler
{
    public override void HandleRequest(int request)
    {
        if (request >= 10 && request < 20)
        {
            Debug.Log($"{this.GetType().Name} handled request {request}");
        }
        else if (successor != null)
        {
            successor.HandleRequest(request);
        }
    }
}

public class ConcreteHandler3 : Handler
{
    public override void HandleRequest(int request)
    {
        if (request >= 20 && request < 30)
        {
            Debug.Log($"{this.GetType().Name} handled request {request}");
        }
        else if (successor != null)
        {
            successor.HandleRequest(request);
        }
    }
}

public class ChainOfResponsibilityExample : MonoBehaviour
{
    public GameObject prefab;
    private Handler h1;
    private Handler h2;
    private Handler h3;
    void Start()
    {   
        CreateInstances();

        h1.SetSuccessor(h2);
        h2.SetSuccessor(h3);

        int[] requests = { 2, 5, 14, 22, 18, 3, 27, 20 };

        foreach (int request in requests)
        {
            h1.HandleRequest(request);
        }
    }

    void CreateInstances()
    {
        h1 = Instantiate(prefab).AddComponent<ConcreteHandler1>();
        h2 = Instantiate(prefab).AddComponent<ConcreteHandler2>();
        h3 = Instantiate(prefab).AddComponent<ConcreteHandler3>();

        PositionHandler(h1, 5);
        PositionHandler(h2, 10);
        PositionHandler(h3, 15);
    }

    void PositionHandler(Handler handler, float x)
    {
        //position handler
        handler.transform.position = new Vector3(x, 0, 0);
    }
}