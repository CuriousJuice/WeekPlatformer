using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    protected bool airborne;
    protected Vector2 velocity;
    protected Vector2 maxVelocity;
    protected Vector2 accelerationX;
    protected Vector2 accelerationY;
    protected Vector2 gravity;
    protected Vector2 movementThisFrame;


    // Use this for initialization
    public void Start () {
        airborne = true;
        velocity = new Vector2(0, 0);
        maxVelocity = new Vector2(500, 500);
        accelerationX = new Vector2(0, 0);
        accelerationY = new Vector2(0, 0);
        gravity = new Vector2(0, -0.1F);
        movementThisFrame = new Vector2(0, 0);
	}
	
	// Update is called once per frame
	public void Update () {
       //Check if gravity should be applied
        if (airborne)
        {
            velocity += gravity;
        }
        else
        {
            velocity.y = 0;
        }
        movementThisFrame += velocity;
    }

    protected void FixedUpdate()
    {
        GetComponent<BoxCollider2D>().offset = new Vector2(0, movementThisFrame.y);
        Vector2 currentPosition = gameObject.transform.position;
        // Move the character accordingly
        gameObject.transform.position = currentPosition + movementThisFrame;
        movementThisFrame = new Vector2(0, 0);
    }

    public void SetAirborne(bool value) { airborne = value; }
}
