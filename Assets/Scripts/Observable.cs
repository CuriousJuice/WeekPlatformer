using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IObservable {
    /// <summary>
    /// Add an observer
    /// </summary>
    /// <param name="o"> The observer to add </param>
    void AddObserver(IObserver o);
    /// <summary>
    /// Delete an observer
    /// </summary>
    /// <param name="o"> The observer to delete </param>
    void DeleteObserver(IObserver o);
    /// <summary>
    /// Notify observers about a change
    /// </summary>
    void NotifyObservers(EventArgs args);
    
}
