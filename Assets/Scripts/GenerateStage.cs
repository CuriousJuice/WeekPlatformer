using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateStage : MonoBehaviour{

	// Use this for initialization
    /**
     * Used to place collidable surfaces for player interaction.
     * */
	public ArrayList Generate () {
        //Texture2D platformTexture = Resources.Load("Surface") as Texture2D; //set texture
        ArrayList sprites = new ArrayList(); //keep track of each sprite created.

        //Currently makes ground for left to right of the screen, 18 blocks)
        for (int i = 0; i < 18; i++)
        {
            GameObject platform = Resources.Load("Surface") as GameObject;
            Instantiate(platform, new Vector2(-9 + i, -5), Quaternion.identity);
            sprites.Add(platform);
        }
        //Adds some triangle hazards
        for(int i = 0; i < 4; i++)
        {
            GameObject triangle = Resources.Load("Triangle") as GameObject;
            Instantiate(triangle, new Vector2(-9 + i, 0), Quaternion.identity);
        }
        Debug.Log(((GameObject) sprites[0]).transform.position.y);
        return sprites;
    }
}
