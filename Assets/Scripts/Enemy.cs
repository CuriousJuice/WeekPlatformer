using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character {

	// Use this for initialization
	public new void Start () {
        base.Start();

	}
	
	// Update is called once per frame
	public new void Update () {
        base.Update();
	}

    private void OnCollisionEnter(Collision collision)
    {
            
    }
}
