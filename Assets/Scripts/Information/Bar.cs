using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bar : MonoBehaviour, IObservable {
    List<IObserver> observers;
    event EventHandler MainHandler;    


	// Use this for initialization
	void Start () {
        observers = new List<IObserver>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddObserver(IObserver o)
    {
        if (!observers.Contains(o))
        {
            observers.Add(o);
            MainHandler += o.HandleEvent;
        }
    }

    public void DeleteObserver(IObserver o)
    {
        if (observers.Contains(o))
        {
            observers.Remove(o);
        }
    }

    public void NotifyObservers(EventArgs args)
    {
        EventHandler thisHandler = MainHandler;
        if (thisHandler != null)
        {
            thisHandler(this, args);
        }
    }
}
