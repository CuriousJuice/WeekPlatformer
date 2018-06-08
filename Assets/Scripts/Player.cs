﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Character {
    float stopMultiplier;
    int jumpTimer;
    int maxJump;
    Vector2 playerDimensions;
    public bool jumpLock; // tells if jump should be locked starting from this frame
    public bool jumpReset; // tells if jump should be reset this frame
    public bool climbing;

    public bool onPlatform; //determines whether the player is on the platform or not.
    public float platformStart; //the x-coordinate of the start of the platform
    public float platformWidth; //the width of the platform
    public bool reEnableMovement; //Used to determine if the player has made a wall collision and has surpassed the appropriate height
    public bool canMoveRight; //Used to reenable right movement
    public bool canMoveLeft; //Used to reenable left movement

    public float clearHeight;

    public new void Start()
    {
        base.Start();
        velocity = new Vector2(0, 0);
        maxVelocity = new Vector2(0.8F, 0);
        accelerationX = new Vector2(0.05F, 0);
        accelerationY = new Vector2(0, 0.15F);
        gravity = new Vector2(0, -0.1F);
        movementThisFrame = new Vector2(0, 0);
        stopMultiplier = 0.6F;
        airborne = true;
        jumpTimer = 0;
        maxJump = 8;
        playerDimensions = new Vector2(GetComponent<SpriteRenderer>().bounds.size.x, GetComponent<SpriteRenderer>().bounds.size.x);
        jumpLock = false;
        jumpReset = false;
        canMoveLeft = true;
        canMoveRight = true;
    }

    public new void Update() {
        CheckUserMovement();
        base.Update();
    }

    private new void FixedUpdate()
    {
        base.FixedUpdate();
    }

    // Helper method to check user key presses related to movement
    private void CheckUserMovement()
    {
        //Debug.Log(velocity.x);

        // Deals with jump resetting
        if (jumpLock)
        {
            jumpTimer = maxJump;
            jumpLock = false;
        }

        if (jumpReset)
        {
            jumpTimer = 0;
            jumpReset = false;
        }

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
            if (Input.GetKey(KeyCode.RightArrow) && velocity.x < maxVelocity.x && canMoveRight)
            {
                if (velocity.x < 0)
                {
                    velocity.x *= stopMultiplier;
                }
                velocity += accelerationX;
                canMoveLeft = true;
            }
            if (Input.GetKey(KeyCode.LeftArrow) && -velocity.x < maxVelocity.x && canMoveLeft)
            {
                if (velocity.x > 0)
                {
                    velocity.x *= stopMultiplier;
                }
                velocity -= accelerationX;
                canMoveRight = true;
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
            jumpLock = true;
        }

        //Reset remove after development
        if (Input.GetKeyDown(KeyCode.R))
        {
            gameObject.transform.position = new Vector2(0, 0);
        }

        //For reenabling left and right movement for when a wall collisions occurs.
        if (reEnableMovement && gameObject.transform.position.y >= clearHeight)
        {
            canMoveLeft = true;
            canMoveRight = true;
            reEnableMovement = false;
        }

        //To reenable gravity for when a player walks off a platform.
        if(onPlatform && (gameObject.transform.position.x > platformStart + platformWidth || 
            gameObject.transform.position.x + gameObject.GetComponent<SpriteRenderer>().bounds.size.x < platformStart))
        {
            airborne = true;
            onPlatform = false;
        }

        //For testing
        if (gameObject.transform.position.y < -6)
        {
            airborne = false;
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, -6);
            jumpReset = true;
        }

    }

}
