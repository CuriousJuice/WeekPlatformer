using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Character {
    Vector2 velocity;
    Vector2 maxVelocity;
    Vector2 accelerationX;
    Vector2 gravity;

    public new void Start()
    {
        base.Start();
        velocity = new Vector2(0, 0);
        maxVelocity = new Vector2(0.8F, 0);
        accelerationX = new Vector2(0.05F, 0);
        gravity = new Vector2(0, -0.1F);
    }

    public new void Update() {
        base.Update();
        Vector2 movementThisFrame = new Vector2(0, 0);
        Vector2 currentPosition = gameObject.transform.position;

        //If neither right/left pressed or both
        if (!(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
            || Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftArrow))
        {
            if (System.Math.Abs(velocity.x) < 0.1F)
            {
                velocity.x = 0;
            }
            else
            {
                velocity *= 0.9F;
            }
        }
        // If only one of right / left pressed
        else
        {
            if (Input.GetKey(KeyCode.RightArrow) && velocity.x < maxVelocity.x)
            {
                if (velocity.x < 0)
                {
                    velocity *= 0.6F;
                }
                velocity += accelerationX;
            }
            if (Input.GetKey(KeyCode.LeftArrow) && -velocity.x < maxVelocity.x)
            {
                if (velocity.x > 0)
                {
                    velocity *= 0.6F;
                }
                velocity -= accelerationX;
            }
        }
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            velocity.y += 0.2F;
        }
        if (currentPosition.y > -3) {
            velocity += gravity;
        }

        movementThisFrame += velocity;
        gameObject.transform.position = currentPosition + movementThisFrame;

        //Adjustments
        if (gameObject.transform.position.y < -3)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, -3);
        }
    }
}
