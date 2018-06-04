using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Character {
    float stopMultiplier;
    int jumpTimer;
    int maxJump;
    Vector2 playerDimensions;
    bool jumpLock; // tells if jump should be locked starting from this frame
    bool jumpReset; // tells if jump should be reset this frame
    bool climbing;

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
    }

    public new void Update() {
        base.Update();
        CheckUserMovement();
    }

    //private new void FixedUpdate()
    //{
    //    base.FixedUpdate();
    //    //Debug.Log(GetComponent<SpriteRenderer>().bounds.size.y);
    //    //Debug.Log(movementThisFrame.y);
    //}

    /**
     * Responsble for handling collisions for the following objects:
     * Walls
     * Spikes
     * Surface
     **/
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject.name);
        //Ground
        if(collision.gameObject.name == "Surface(Clone)")
        {
         

            Debug.Log(transform.position.y + "-" + collision.gameObject.transform.position.y);
            //Gets rectangle of floor
            GameObject floor = collision.gameObject;
            Debug.Log("COLLIDED");
            if (velocity.y < 0)
            {
                //Debug.Log("Collided with surface up");
                float floorHeight = floor.GetComponent<SpriteRenderer>().bounds.size.y;
                gameObject.transform.position = new Vector2(gameObject.transform.position.x,
                    collision.gameObject.transform.position.y + floorHeight);
                //print(gameObject.transform.position.y - floorHeight);
                //print(collision.gameObject.transform.position.y);
                jumpReset = true;
                airborne = false;
            }
            else if (velocity.y > 0)
            {
                //Debug.Log("Collided with surface down");
                float floorHeight = floor.GetComponent<SpriteRenderer>().bounds.size.y;
                gameObject.transform.position = new Vector2(gameObject.transform.position.x,
                    collision.gameObject.transform.position.y - playerDimensions.y);
                jumpLock = true;
            }
            if(velocity.y == 0 && transform.position.y > collision.gameObject.transform.position.y)
            {
                jumpReset = true;
            }

            movementThisFrame = new Vector2(movementThisFrame.x, 0);
            velocity.y = 0;
        }
        
        //Spikes
        if(collision.gameObject.name == "Triangle(Clone)")
        {
            //Debug.Log("Die");
            Destroy(gameObject);
        }

        //Wall
        if (collision.gameObject.name == "VSurface(Clone)")
        {
            //Debug.Log("WALL");
            //Left
            if (velocity.x > 0) {
                gameObject.transform.position = new Vector2(collision.gameObject.transform.position.x - 1, gameObject.transform.position.y);
            }
            //Right
            if (velocity.x < 0)
            {
                gameObject.transform.position = new Vector2(collision.gameObject.transform.position.x + 1, gameObject.transform.position.y);
            }
            velocity.x = 0;

            if(velocity.y < 0 && gameObject.transform.position.x > collision.gameObject.transform.position.x &&
                gameObject.transform.position.x < collision.gameObject.transform.position.x + 1)
            {
                velocity.y = 0;
                gameObject.transform.position = new Vector2(gameObject.transform.position.x,
                    collision.gameObject.transform.position.y + collision.gameObject.GetComponent<SpriteRenderer>().bounds.size.y);
                jumpReset = true;
                airborne = false;
            }
        }

        //Climbables
        if(collision.gameObject.name == "Climb(Clone)")
        {
            climbing = true;
            Debug.Log(climbing);
        }
        
    }

    //void OnCollisionExit2D(Collision2D collision)
    //{
    //    if(collision.gameObject.name == "Surface(Clone)")
    //    {
    //        airborne = true;
    //    }
    //}

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
            jumpLock = true;
        }
        //if (currentPosition.y > -3)
        //{
        //    airborne = true;
        //}

        //Reset remove after development
        if (Input.GetKeyDown(KeyCode.R))
        {
            gameObject.transform.position = new Vector2(0, 0);
        }

        

        



        movementThisFrame += velocity;
        

        //For testing
        if (gameObject.transform.position.y < -6)
        {
            airborne = false;
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, -6);
            jumpReset = true;
        }

    }

    public void SetAirborne(bool value) { airborne = value; }
}
