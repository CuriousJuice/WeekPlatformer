using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateStage : MonoBehaviour{

	// Use this for initialization
    /**
     * Used to place collidable surfaces for player interaction.
     * */
	public void Start () {
        //ArrayList sprites = new ArrayList(); //keep track of each sprite created.

        //Currently makes ground for left to right of the screen, 18 blocks)
        for (int i = 0; i < 21; i++)
        {
            GameObject holder = Resources.Load("Surface") as GameObject;
            GameObject platform = Instantiate(holder, new Vector2(-9 + i, -5), Quaternion.identity);
           // sprites.Add(platform);
        }

        //Adds some triangle hazards
        for(int i = 0; i < 4; i++)
        {
            GameObject holder = Resources.Load("Triangle") as GameObject;
            GameObject triangle = Instantiate(holder, new Vector2(-9 + i, 0), Quaternion.identity);
            //sprites.Add(triangle);
        }

        //Add walls
        for(int i = 0; i < 3; i++)
        {
            GameObject holder = Resources.Load("VSurface") as GameObject;
            GameObject wall = Instantiate(holder, new Vector2(8, -4 + i), Quaternion.identity);
            //sprites.Add(wall);
        }
        //return sprites;

    }
}
