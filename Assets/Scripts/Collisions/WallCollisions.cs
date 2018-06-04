using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This acts as the wall of the playing field
/// </summary>
public class WallCollisions : Collisions{
    /// <summary>
    /// Prevents the player from going through from the left on the collided surface.
    /// </summary>
    /// <param name="col"></param>
    public override void Left(Collision2D col)
    {
        col.gameObject.transform.position = new Vector2(gameObject.transform.position.x - 1, col.gameObject.transform.position.y);
        col.gameObject.GetComponent<Player>().velocity.x = 0;
        col.gameObject.GetComponent<Player>().canMoveRight = false;
    }

    /// <summary>
    /// Prevents the player from going through from the right on the collided surface.
    /// </summary>
    /// <param name="col"></param>
    public override void Right(Collision2D col)
    {
        col.gameObject.transform.position = new Vector2(gameObject.transform.position.x + 1, col.gameObject.transform.position.y);
        col.gameObject.GetComponent<Player>().velocity.x = 0;
        col.gameObject.GetComponent<Player>().canMoveLeft = false;
    }

}
