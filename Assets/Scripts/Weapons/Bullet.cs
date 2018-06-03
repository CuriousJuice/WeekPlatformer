﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    private readonly float VELOCITY_MAGNITUDE = 1;
    private Vector2 velocity = new Vector2(0, 0);

	// Use this for initialization
	void Start () {
    
    }
	
	// Update is called once per frame
	void Update () {
        Vector2 currentPosition = transform.position;
        transform.position = currentPosition + VELOCITY_MAGNITUDE * velocity;
	}



    public Vector2 Velocity
    {
        get { return velocity; }
        set { velocity = value; }
    }

}
