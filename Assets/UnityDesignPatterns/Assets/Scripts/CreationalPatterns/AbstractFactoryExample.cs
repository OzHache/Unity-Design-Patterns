using UnityEngine;
public class AbstractFactoryExample : MonoBehaviour
{
    private void Start()
    {
        AbstractFactory factory = new ConcreteFactory1();
        AbstractProductA productA = factory.CreateProductA();
        AbstractProductB productB = factory.CreateProductB();

        productA.OperationA();
        productB.OperationB();
    }
}
  abstract class AbstractProductA
    {
        public abstract void OperationA();
    }

    abstract class AbstractProductB
    {
        public abstract void OperationB();
    }

    abstract class AbstractFactory
    {
        public abstract AbstractProductA CreateProductA();
        public abstract AbstractProductB CreateProductB();
    }

    class ConcreteProductA1 : AbstractProductA
    {
        public override void OperationA()
        {
            Debug.Log("ConcreteProductA1: OperationA");
        }
    }

    class ConcreteProductB1 : AbstractProductB
    {
        public override void OperationB()
        {
            Debug.Log("ConcreteProductB1: OperationB");
        }
    }

    class ConcreteFactory1 : AbstractFactory
    {
        public override AbstractProductA CreateProductA()
        {
            return new ConcreteProductA1();
        }

        public override AbstractProductB CreateProductB()
        {
            return new ConcreteProductB1();
        }
    }