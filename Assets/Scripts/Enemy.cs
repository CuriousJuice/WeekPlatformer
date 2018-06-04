using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character {

	// Use this for initialization
	public new void Start () {
        base.Start();
        velocity = new Vector2(0.1F, 0);
	}
	
	// Update is called once per frame
	public new void Update () {
        base.Update();
	}

    private new void FixedUpdate()
    {
        base.FixedUpdate();
    }

}
