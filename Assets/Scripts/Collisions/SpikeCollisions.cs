using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This will destroy the player regardless of any type of contact from any given side.
 * */
public class SpikeCollisions : Collisions{

    // Use this for initialization 
    void Top(Collision2D col)
    {
        Destroy(col.gameObject);
    }

    void Bottom(Collision2D col)
    {
        Destroy(col.gameObject);
    }

    public override void Left(Collision2D col)
    {
        Destroy(col.gameObject);
    }

    public override void Right(Collision2D col)
    {
        Destroy(col.gameObject);
    }
}
