using System.Collections.Generic;
using UnityEngine;

// Define an interface for all observers
public interface IObserver
{
    void OnNotify();
}

// Define a class for the subject that will send notifications
public class Subject : MonoBehaviour
{
    private List<IObserver> observers = new List<IObserver>();

    public void RegisterObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void UnregisterObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.OnNotify();
        }
    }
}

// Define a class for an observer
public class ConcreteObserver : MonoBehaviour, IObserver
{
    [SerializeField] protected Subject subject;

    private void Start()
    {
        subject.RegisterObserver(this);
    }

    public void OnNotify()
    {
        Debug.Log("Observer notified!");
    }

    private void OnDestroy()
    {
        subject.UnregisterObserver(this);
    }
}
// Dispite the odd naming. This is the Subject class from the Observer pattern
public class ObserverExample : Subject
{
    private void Start()
    {
        //Self initialization and registration
        GameObject observer = new GameObject("Observer");
        observer.AddComponent<MyObserver>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            NotifyObservers();
        }
    }
}
 public class MyObserver : ConcreteObserver{
    //Self initialization and registration
    private void Start(){
        subject = GameObject.FindObjectOfType<ObserverExample>();
        subject.RegisterObserver(this);
    }

 }

