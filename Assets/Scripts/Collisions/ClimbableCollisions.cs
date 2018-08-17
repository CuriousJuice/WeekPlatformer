using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbableCollisions : Verticles{

    public override void Left(Collision2D col)
    {
        base.Left(col);
        col.gameObject.GetComponent<Player>().climbing = true;
    }

    public override void Right(Collision2D col)
    {
        base.Right(col);
        col.gameObject.GetComponent<Player>().climbing = true;
    }

}
