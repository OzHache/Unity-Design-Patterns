using UnityEngine;
using System.Collections.Generic;
public class BuilderExample : MonoBehaviour
{
    public abstract class Builder
    {
        public abstract void BuildPartA();
        public abstract void BuildPartB();
        public abstract Product GetResult();
    }

    public class ConcreteBuilder : Builder
    {
        private Product _product = new Product();

        public override void BuildPartA()
        {
            _product.Add("PartA");
        }

        public override void BuildPartB()
        {
            _product.Add("PartB");
        }

        public override Product GetResult()
        {
            return _product;
        }
    }

    public class Product
    {
        private List<string> _parts = new List<string>();

        public void Add(string part)
        {
            _parts.Add(part);
        }

        public void Show()
        {
            Debug.Log("Product Parts -------");
            foreach (string part in _parts)
                Debug.Log(part);
        }
    }

    public class Director
    {
        public void Construct(Builder builder)
        {
            builder.BuildPartA();
            builder.BuildPartB();
        }
    }

    void Start()
    {
        Director director = new Director();
        Builder b1 = new ConcreteBuilder();
        director.Construct(b1);
        Product p1 = b1.GetResult();
        p1.Show();
    }
}