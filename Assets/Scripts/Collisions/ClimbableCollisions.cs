using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbableCollisions : Collisions {

    public override void Left(Collision2D col)
    {
        col.gameObject.GetComponent<Player>().climbing = true;
    }

    public override void Right(Collision2D col)
    {
        col.gameObject.GetComponent<Player>().climbing = true;
    }

}
