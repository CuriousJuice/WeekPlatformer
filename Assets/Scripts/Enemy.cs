using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : Character, IObserver {

    Vector2 gameObjectDimensions;
    GameObject healthbar; // This enemy's health bar

	// Use this for initialization
	public new void Start () {
        base.Start();
        velocity = new Vector2(0.1F, 0);
        gameObjectDimensions = new Vector2(GetComponent<SpriteRenderer>().bounds.size.x, GetComponent<SpriteRenderer>().bounds.size.y);
        //Create health bar
        GameObject healthbarObject = Resources.Load("Healthbar") as GameObject;
        Vector2 healthbarDimensions = healthbarObject.GetComponent<SpriteRenderer>().bounds.size;
        healthbar = Instantiate(healthbarObject, new Vector2(transform.position.x + gameObjectDimensions.x / 2,
            transform.position.y + gameObjectDimensions.y + healthbarDimensions.y / 3), Quaternion.identity);
        healthbar.GetComponent<Healthbar>().SetTarget(gameObject);
        healthbar.GetComponent<Healthbar>().AddObserver(this);

    }
	
	// Update is called once per frame
	public new void Update () {
        base.Update();
	}

    private new void FixedUpdate()
    {
        base.FixedUpdate();
    }

    //Handles events
    public void HandleEvent(object o, EventArgs args)
    {

    }

    //Deal with collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Surface(Clone)")
        {

            //Gets rectangle of floor
            GameObject floor = collision.gameObject;
            if (velocity.y < 0)
            {
                float floorHeight = floor.GetComponent<SpriteRenderer>().bounds.size.y;
                gameObject.transform.position = new Vector2(gameObject.transform.position.x,
                    collision.gameObject.transform.position.y + floorHeight);
                airborne = false;
            }
            else if (velocity.y > 0)
            {
                float floorHeight = floor.GetComponent<SpriteRenderer>().bounds.size.y;
                gameObject.transform.position = new Vector2(gameObject.transform.position.x,
                    collision.gameObject.transform.position.y - gameObjectDimensions.y);
            }
            movementThisFrame = new Vector2(movementThisFrame.x, 0);
            velocity.y = 0;
        }
    }
}
