using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Character {
    Vector2 velocity;
    Vector2 maxVelocity;
    Vector2 accelerationX;
    Vector2 accelerationY;
    Vector2 gravity;
    float stopMultiplier;

    public new void Start()
    {
        base.Start();
        velocity = new Vector2(0, 0);
        maxVelocity = new Vector2(0.8F, 0);
        accelerationX = new Vector2(0.05F, 0);
        accelerationY = new Vector2(0, 0.15F);
        gravity = new Vector2(0, -0.1F);
        stopMultiplier = 0.6F;
    }

    public new void Update() {
        base.Update();
        CheckUserMovement();
    }

    // Helper method to check user key presses related to movement
    private void CheckUserMovement()
    {
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
                velocity *= (1 + stopMultiplier) / 2;
            }
        }
        // If only one of right / left pressed
        else
        {
            if (Input.GetKey(KeyCode.RightArrow) && velocity.x < maxVelocity.x)
            {
                if (velocity.x < 0)
                {
                    velocity *= stopMultiplier;
                }
                velocity += accelerationX;
            }
            if (Input.GetKey(KeyCode.LeftArrow) && -velocity.x < maxVelocity.x)
            {
                if (velocity.x > 0)
                {
                    velocity *= stopMultiplier;
                }
                velocity -= accelerationX;
            }
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            velocity += accelerationY;
        }
        if (currentPosition.y > -3)
        {
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
