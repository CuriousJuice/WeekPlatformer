using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbableCollisions : Verticles{
    public override void Left(Collision2D col)
    {
        base.Left(col);
        col.gameObject.GetComponent<Player>().climbing = true;
        col.gameObject.GetComponent<Player>().clearHeight = height + gameObject.transform.position.y;
        col.gameObject.GetComponent<Player>().fromLeft = true;
    }

    public override void Right(Collision2D col)
    {
        base.Right(col);
        col.gameObject.GetComponent<Player>().climbing = true;
        col.gameObject.GetComponent<Player>().clearHeight = height + gameObject.transform.position.y;
        col.gameObject.GetComponent<Player>().fromLeft = false;
    }

    public override void Bottom(Collision2D col) { return; }
}
