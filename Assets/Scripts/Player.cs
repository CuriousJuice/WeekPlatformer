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
    bool airborne;
    int jumpTimer;
    int maxJump;

    public new void Start()
    {
        base.Start();
        velocity = new Vector2(0, 0);
        maxVelocity = new Vector2(0.8F, 0);
        accelerationX = new Vector2(0.05F, 0);
        accelerationY = new Vector2(0, 0.15F);
        gravity = new Vector2(0, -0.1F);
        stopMultiplier = 0.6F;
        airborne = true;
        jumpTimer = 0;
        maxJump = 8;
    }

    public new void Update() {
        base.Update();
        CheckUserMovement();
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided");
        airborne = false;
        velocity.y = 0;
        jumpTimer = 0;
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
                velocity.x *= (1 + stopMultiplier) / 2;
            }
        }
        // If only one of right / left pressed
        else
        {
            if (Input.GetKey(KeyCode.RightArrow) && velocity.x < maxVelocity.x)
            {
                if (velocity.x < 0)
                {
                    velocity.x *= stopMultiplier;
                }
                velocity += accelerationX;
            }
            if (Input.GetKey(KeyCode.LeftArrow) && -velocity.x < maxVelocity.x)
            {
                if (velocity.x > 0)
                {
                    velocity.x *= stopMultiplier;
                }
                velocity -= accelerationX;
            }
        }

        //Jump if the up key is held, and the jump wasn't too long
        if (Input.GetKey(KeyCode.UpArrow) && jumpTimer < maxJump)
        {
            // Makes jump explosive at the beginning
            if (jumpTimer < 2)
            {
                velocity += 1.5F * accelerationY;
                airborne = true;
            }
            //Resets jump after initial burst
            if (jumpTimer == 3)
            {
                velocity -= 1.5F * accelerationY;
            }
            if (airborne)
            {
                velocity += accelerationY;
                jumpTimer += 1;
            }
            
        }
        //If jump key released, then can't jump again
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            jumpTimer = maxJump;
        }
        //if (currentPosition.y > -3)
        //{
        //    airborne = true;
        //}

        

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
        gameObject.transform.position = currentPosition + movementThisFrame;

        //For testing
        if (gameObject.transform.position.y < -6)
        {
            airborne = false;
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, -6);
            jumpTimer = 0;
        }

    }

    public void SetAirborne(bool value) { airborne = value; }
}
