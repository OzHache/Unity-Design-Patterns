using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IteratorExample : MonoBehaviour
{
    void Start()
    {
        ConcreteAggregate aggregate = new ConcreteAggregate();
        aggregate[0] = "Item A";
        aggregate[1] = "Item B";
        aggregate[2] = "Item C";
        aggregate[3] = "Item D";

        Iterator iterator = aggregate.CreateIterator();

        object item = iterator.First();
        StartCoroutine(Iterate(iterator));
    }
    IEnumerator Iterate(Iterator iterator)
    {
        object item = iterator.First();
        while (item != null)
        {
            Debug.Log(iterator.CurrentItem());
            item = iterator.Next();
            yield return null;
        }
    }
}

interface Aggregate
{
    Iterator CreateIterator();
}

class ConcreteAggregate : Aggregate
{
    private ArrayList items = new ArrayList();

    public Iterator CreateIterator()
    {
        return new ConcreteIterator(this);
    }

    public int Count
    {
        get { return items.Count; }
    }

    public object this[int index]
    {
        get { return items[index]; }
        set { items.Insert(index, value); }
    }
}

interface Iterator
{
    object First();
    object Next();
    bool IsDone();
    object CurrentItem();
}

class ConcreteIterator : Iterator
{
    private ConcreteAggregate aggregate;
    private int current = 0;

    public ConcreteIterator(ConcreteAggregate aggregate)
    {
        this.aggregate = aggregate;
    }

    public object First()
    {
        return aggregate[0];
    }

    public object Next()
    {
        object ret = null;
        if (current < aggregate.Count - 1)
        {
            ret = aggregate[++current];
        }

        return ret;
    }

    public object CurrentItem()
    {
        return aggregate[current];
    }

    public bool IsDone()
    {
        return current >= aggregate.Count;
    }
}