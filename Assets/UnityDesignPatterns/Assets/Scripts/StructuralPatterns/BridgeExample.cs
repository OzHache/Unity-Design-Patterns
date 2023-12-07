using UnityEngine;
public class BridgeExample : MonoBehaviour
{
    private void Start()
    {
        Shape redCircle = new Circle(new Vector3(10, 10, 0), 10, new DrawAPI1());
        Shape greenCircle = new Circle(new Vector3(-10, 10, 0), 10, new DrawAPI2());

        redCircle.Draw();
        greenCircle.Draw();
    }
}
// The 'Abstraction' class
public abstract class Shape
{
    protected IDrawAPI drawAPI;
    protected Shape(IDrawAPI drawAPI)
    {
        this.drawAPI = drawAPI;
    }
    public abstract void Draw();
}

// The 'RefinedAbstraction' class
public class Circle : Shape
{
    private Vector3 position;
    private float radius;

    public Circle(Vector3 position, float radius, IDrawAPI drawAPI) : base(drawAPI)
    {
        this.position = position;
        this.radius = radius;
    }

    public override void Draw()
    {
        drawAPI.DrawCircle(position, radius);
    }
}

// The 'Implementor' interface
public interface IDrawAPI
{
    void DrawCircle(Vector3 position, float radius);
}

// The 'ConcreteImplementorA' class
public class DrawAPI1 : IDrawAPI
{
    public void DrawCircle(Vector3 position, float radius)
    {
        Debug.Log("Drawing Circle[ color: red, position: " + position + ", radius: " + radius + "]");
    }
}

// The 'ConcreteImplementorB' class
public class DrawAPI2 : IDrawAPI
{
    public void DrawCircle(Vector3 position, float radius)
    {
        Debug.Log("Drawing Circle[ color: green, position: " + position + ", radius: " + radius + "]");
    }
}