using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bar : MonoBehaviour, IObservable {
    List<IObserver> observers = new List<IObserver>();
    event EventHandler MainHandler;
    GameObject target;
    Vector2 targetDimensions;
    Vector2 objectDimensions;


	// Use this for initialization
	protected void Start () {
        objectDimensions = GetComponent<SpriteRenderer>().bounds.size;
	}
	
	// Update is called once per frame
	protected void Update () {
		if (target != null)
        {
            transform.position = new Vector2(target.transform.position.x,
            target.transform.position.y + targetDimensions.y/2 + objectDimensions.y / 3);
        }
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

    public void SetTarget(GameObject target)
    {
        this.target = target;
        targetDimensions = target.GetComponent<SpriteRenderer>().bounds.size;
    }
}
