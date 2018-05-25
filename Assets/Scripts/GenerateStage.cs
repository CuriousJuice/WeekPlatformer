using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateStage : MonoBehaviour{

	// Use this for initialization
    /**
     * Used to place collidable surfaces for player interaction.
     * */
	void Start () {
        Texture2D platformTexture = Resources.Load("Surface") as Texture2D; //set texture
        ArrayList sprites = new ArrayList(); //keep track of each sprite created.

        //Currently makes ground for left to right of the screen, 18 blocks)
        for (int i = 0; i < 18; i++)
        {
            Sprite platformsprite = Sprite.Create(platformTexture, new Rect(0, 0, 100, 100), new Vector2(0, 0));
            GameObject platformobject = new GameObject("Groud");
            SpriteRenderer spriterenderer = platformobject.AddComponent<SpriteRenderer>();
            platformobject.AddComponent<Ground>();
            platformobject.transform.position = new Vector2(-9 + i, -5); //Makes it so the position of each block is on a different x coordinate
            spriterenderer.sprite = platformsprite;
            sprites.Add(platformsprite);
        }
        gameObject.transform.position = new Vector3(0, 0, -15);
    }
}
