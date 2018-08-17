using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * The abstract class that will be inherited by all collision type classes
 * */
public abstract class Collisions : MonoBehaviour {
    public bool platform;
    public float platformWidth;

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "PlayerPref(Clone)")
        {
            //Top
            if (col.gameObject.GetComponent<Player>().velocity.y < 0)
            {
                Top(col);
            }
            //Bottom
            if(col.gameObject.GetComponent<Player>().velocity.y > 0) {
                Bottom(col);
            }
            //Left
            if(col.gameObject.GetComponent<Player>().velocity.x > 0 && (gameObject.transform.position.y < col.gameObject.transform.position.y + col.gameObject.GetComponent<SpriteRenderer>().bounds.size.y &&
                gameObject.transform.position.y + gameObject.GetComponent<SpriteRenderer>().bounds.size.y > col.gameObject.transform.position.y))
            {
                Left(col);
            }
            //Right
            if(col.gameObject.GetComponent<Player>().velocity.x < 0 && (gameObject.transform.position.y < col.gameObject.transform.position.y + col.gameObject.GetComponent<SpriteRenderer>().bounds.size.y &&
                gameObject.transform.position.y + gameObject.GetComponent<SpriteRenderer>().bounds.size.y > col.gameObject.transform.position.y))
            {
                Right(col);
            }
        }
    }

    /// <summary>
    /// Prevents the player from falling through the collided surface.
    /// </summary>
    /// <param name="col"></param>
    void Top(Collision2D col)
    {
        col.gameObject.transform.position = new Vector2(col.gameObject.transform.position.x, gameObject.transform.position.y +
            gameObject.GetComponent<SpriteRenderer>().bounds.size.y);

        col.gameObject.GetComponent<Player>().jumpReset = true;
        col.gameObject.GetComponent<Player>().airborne = false;
        col.gameObject.GetComponent<Player>().velocity.y = 0;
        col.gameObject.GetComponent<Player>().canDescend = false;

        if (platform)
        {
            col.gameObject.GetComponent<Player>().platformStart = gameObject.transform.position.x;
            col.gameObject.GetComponent<Player>().onPlatform = true;
            col.gameObject.GetComponent<Player>().platformWidth = platformWidth;
        }
    }

    /// <summary>
    /// Prevents the player from going up through the collided surface
    /// </summary>
    /// <param name="col"></param>
    void Bottom(Collision2D col)
    {
        col.gameObject.transform.position = new Vector2(col.gameObject.transform.position.x, gameObject.transform.position.y -
            col.gameObject.GetComponent<SpriteRenderer>().bounds.size.y);
        col.gameObject.GetComponent<Player>().jumpLock = true;
        col.gameObject.GetComponent<Player>().velocity.y = 0;
        col.gameObject.GetComponent<Player>().canClimb = false;

        if (col.gameObject.GetComponent<Player>().velocity.y == 0 && col.gameObject.transform.position.y > gameObject.transform.position.y)
        {
            col.gameObject.GetComponent<Player>().jumpReset = true;
        }
    }

    /// <summary>
    /// To be overwritten appropriatly for the given surface for a collision from the left side
    /// </summary>
    /// <param name="col"></param>
    public abstract void Left(Collision2D col);

    /// <summary>
    /// To be overwritten appropriately for the given surface for a collision from the right side.
    /// </summary>
    /// <param name="col"></param>
    public abstract void Right(Collision2D col);
}
