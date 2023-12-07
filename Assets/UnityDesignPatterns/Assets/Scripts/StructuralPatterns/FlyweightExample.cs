using System.Collections.Generic;
using UnityEngine;

public class FlyweightExample : MonoBehaviour
{
    public class Flyweight
    {
        private string _intrinsicState;

        public Flyweight(string intrinsicState)
        {
            this._intrinsicState = intrinsicState;
        }

        public void Operation(string extrinsicState)
        {
            Debug.Log("Intrinsic State = " + this._intrinsicState + ", Extrinsic State = " + extrinsicState);
        }
    }

    public class FlyweightFactory
    {
        private Dictionary<string, Flyweight> _flyweights = new Dictionary<string, Flyweight>();

        public Flyweight GetFlyweight(string key)
        {
            if (!_flyweights.ContainsKey(key))
            {
                _flyweights.Add(key, new Flyweight(key));
            }

            return _flyweights[key];
        }
       public int GetFlyweightsCount() { return _flyweights.Count; }
    }

    void Start()
    {
        FlyweightFactory factory = new FlyweightFactory();

        Flyweight flyweight1 = factory.GetFlyweight("A");
        flyweight1.Operation("1");

        Flyweight flyweight2 = factory.GetFlyweight("A");
        flyweight2.Operation("2");

        Flyweight flyweight3 = factory.GetFlyweight("B");
        flyweight3.Operation("3");

        Debug.Log("Flyweight instances created: " + factory.GetFlyweightsCount());
    }
}