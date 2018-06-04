using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * The abstract class that will be inherited by all collision type classes
 * */
public abstract class Collisions : MonoBehaviour {

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
            if(col.gameObject.GetComponent<Player>().velocity.x > 0)
            {
                Left(col);
            }
            //Right
            if(col.gameObject.GetComponent<Player>().velocity.x < 0)
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
