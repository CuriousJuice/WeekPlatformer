using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateStage : MonoBehaviour{

	// Use this for initialization
    /**
     * Used to place collidable surfaces for player interaction.
     * */
	public void Start () {
        //Texture2D platformTexture = Resources.Load("Surface") as Texture2D; //set texture
        ArrayList sprites = new ArrayList(); //keep track of each sprite created.

        //Currently makes ground for left to right of the screen, 18 blocks)
        for (int i = 0; i < 18; i++)
        {
            GameObject holder = Resources.Load("Surface") as GameObject;
            GameObject platform = Instantiate(holder, new Vector2(-9 + i, -5), Quaternion.identity);
            sprites.Add(platform);
        }

        //Adds some triangle hazards
        for(int i = 0; i < 4; i++)
        {
            GameObject holder = Resources.Load("Triangle") as GameObject;
            GameObject triangle = Instantiate(holder, new Vector2(-9 + i, 0), Quaternion.identity);
            sprites.Add(triangle);
        }
        //return sprites;
    }
}
