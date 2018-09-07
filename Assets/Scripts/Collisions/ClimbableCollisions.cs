using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbableCollisions : Verticles{
    public override void Left(Collision2D col)
    {
        base.Left(col);
        if (col.gameObject.GetComponent<Player>().canDescend) { col.gameObject.GetComponent<Player>().canMoveLeft = false; }
        col.gameObject.GetComponent<Player>().climbing = true;
        col.gameObject.GetComponent<Player>().canDescend = true;
        col.gameObject.GetComponent<Player>().clearHeight = height + gameObject.transform.position.y;
        col.gameObject.GetComponent<Player>().fromLeft = true;
        col.gameObject.GetComponent<Player>().airborne = false;
    }

    public override void Right(Collision2D col)
    {
        base.Right(col);
        if (col.gameObject.GetComponent<Player>().canDescend) { col.gameObject.GetComponent<Player>().canMoveRight = false; }
        col.gameObject.GetComponent<Player>().climbing = true;
        col.gameObject.GetComponent<Player>().canDescend = true;
        col.gameObject.GetComponent<Player>().clearHeight = height + gameObject.transform.position.y;
        col.gameObject.GetComponent<Player>().fromLeft = false;
        col.gameObject.GetComponent<Player>().airborne = false;
    }

    public override void Bottom(Collision2D col) { return; }
}
