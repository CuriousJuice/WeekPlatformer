using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Character {
    float stopMultiplier;
    int jumpTimer;
    int maxJump;
    Vector2 playerDimensions;
    float climbingSpeed;
    float descendingSpeed;
    public bool jumpLock; // tells if jump should be locked starting from this frame
    public bool jumpReset; // tells if jump should be reset this frame
    public bool climbing;

    public bool onPlatform; //determines whether the player is on the platform or not.
    public float platformStart; //the x-coordinate of the start of the platform
    public float platformWidth; //the width of the platform
    public bool reEnableMovement; //Used to determine if the player has made a wall collision and has surpassed the appropriate height
    public bool canMoveRight; //Used to reenable right movement
    public bool canMoveLeft; //Used to reenable left movement
    public bool canClimb; //used to reenable climbing up
    public bool canDescend; //used to reenable climbing down
    public bool fromLeft; //used to determine whether a collision was made from the left or right side.

    public float clearHeight; //used to determine how far the player can climb

    public new void Start()
    {
        base.Start();
        velocity = new Vector2(0, 0);
        maxVelocity = new Vector2(0.8F, 0);
        accelerationX = new Vector2(0.05F, 0);
        accelerationY = new Vector2(0, 0.15F);
        gravity = new Vector2(0, -0.1F);
        climbingSpeed = 0.025F; //new Vector2(0, 0.003F);
        descendingSpeed = 0.08F; //new Vector2(0, 0.08F);
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
        canClimb = true;
        canDescend = true;
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

        ///////////////////////////HORIZONTAL MOVEMENT////////////////////////////////

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
                if (climbing)
                {
                    Debug.Log("Wyvern");
                    climbing = false;
                    //airborne = true;
                }
            }
            if (Input.GetKey(KeyCode.LeftArrow) && -velocity.x < maxVelocity.x && canMoveLeft)
            {
                Debug.Log("worms");
                if (velocity.x > 0)
                {
                    velocity.x *= stopMultiplier;
                }
                velocity -= accelerationX;
                canMoveRight = true;
                if (climbing)
                {
                    Debug.Log("nevermore");
                    climbing = false;
                    //airborne = true;
                }
                
            }
        }

        ///////////////////////////VERTICLE MOVEMENT////////////////////////////////

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

        //Jump if the up key is held, and the jump wasn't too long, also will make the player move up if they're climbing
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (jumpTimer < maxJump && climbing == false)
            {
                Debug.Log("what");
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
            // The player is in contact with a climbable surface
            else if(climbing == true && canClimb)
            {
                Debug.Log("fuck");
                //gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + climbingSpeed);
                velocity = new Vector2(velocity.x, climbingSpeed);
                canDescend = true;
                canMoveLeft = false;
                canMoveRight = false;

                //Reenable right and left movement when the player passes the climbable height
                if (gameObject.transform.position.y >= clearHeight)
                {
                    velocity = new Vector2(velocity.x, 0);
                    onPlatform = true;
                    if (!canMoveRight) { gameObject.transform.position = new Vector2(gameObject.transform.position.x + 0.05F, gameObject.transform.position.y); }
                    else { gameObject.transform.position = new Vector2(gameObject.transform.position.x - 0.05F, gameObject.transform.position.y);}
                    climbing = false;
                }

            }
        }

        //Descends if the player is climbing.
        if(Input.GetKey(KeyCode.DownArrow) && climbing && canDescend)
        {
            velocity = new Vector2(velocity.x, -descendingSpeed);
            canClimb = true;
        }
        //Stops moving down upon key release
        if(Input.GetKeyUp(KeyCode.DownArrow) && climbing)
        {
            if (climbing) { velocity = new Vector2(velocity.x, 0); }
        }
        
        //If jump key released, then can't jump again also stops climbing up when key is released
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            jumpLock = true;
            if (climbing) { velocity = new Vector2(velocity.x, 0); }
        }

                //Reset remove after development
                if (Input.GetKeyDown(KeyCode.R))
                {
                    gameObject.transform.position = new Vector2(0, 0);
                    canClimb = true;
                    canMoveRight = true;
                    canMoveLeft = true;
                    canDescend = true;
                    climbing = false;
                    airborne = true;
                    onPlatform = false;
                }
                if (Input.GetKeyDown(KeyCode.I))
                {
                    Debug.Log("Status:\tcanClimb: " + canClimb + "\tcanMoveRight: " + canMoveRight + "\tcanMoveLeft: " + canMoveLeft + "\tcanDescend: " + canDescend + "\tclimbing: " + climbing + "\tairborne: " + airborne +
                        "\tonPlatform: " + onPlatform);
                }

        /////////////REENABLING MOVEMENT AND MISCELLNANIOUS////////////////////////////

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
