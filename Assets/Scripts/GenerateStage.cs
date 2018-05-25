using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateStage : MonoBehaviour{

	// Use this for initialization
    /**
     * Used to place collidable surfaces for player interaction.
     * */
	void Start () {
        Texture2D platformTexture = Resources.Load("Surface") as Texture2D;
        ArrayList sprites = new ArrayList();
        ArrayList platformObjects = new ArrayList();
        for (int i = 0; i < 18; i++)
        {
            Sprite platformsprite = Sprite.Create(platformTexture, new Rect(55, 42, 100, 100), new Vector2(0, 0));
            GameObject platformobject = new GameObject("Groud");
            SpriteRenderer spriterenderer = platformobject.AddComponent<SpriteRenderer>();
            platformobject.AddComponent<Ground>();
            platformobject.transform.position = new Vector2(-9 + i, -5);
            spriterenderer.sprite = platformsprite;
            sprites.Add(platformsprite);
        }
        gameObject.transform.position = new Vector3(0, 0, -15);
    }
}
