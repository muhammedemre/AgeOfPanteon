using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IObserver
{
    // Receive update from subject
    void Update(ISubject subject, string secretData);
}

public interface ISubject
{
    // Attach an observer to the subject.
    void Attach(IObserver observer);

    // Detach an observer from the subject.
    void Detach(IObserver observer);

    // Notify all observers about an event.
    void Notify();
}

public class Army : ISubject
{
    private string secretData = "password";

    public string SecretData
    {
        get { return null; }
        set 
        { 
            secretData = value;
            Notify();
        }
    }

    private List<IObserver> _observers = new List<IObserver>();

    // The subscription management methods.
    public void Attach(IObserver observer)
    {
        Console.WriteLine("Subject: Attached an observer.");
        this._observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        this._observers.Remove(observer);
        Console.WriteLine("Subject: Detached an observer.");
    }

    // Trigger an update in each subscriber.
    public void Notify()
    {
        Console.WriteLine("Subject: Notifying observers...");

        foreach (var observer in _observers)
        {
            observer.Update(this, secretData);
        }
    }

}

public class Soldier : IObserver
{
    public SoldierActor soldierActor;

    public Soldier(SoldierActor _soldierActor) 
    {
        soldierActor = _soldierActor;
    }
    public void Update(ISubject subject, string secretData)
    {
        Debug.Log("Soldier is informed " + secretData);
        soldierActor.pocketForPassword = secretData;
    }
}
