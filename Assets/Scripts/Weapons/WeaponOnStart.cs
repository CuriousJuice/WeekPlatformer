using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponOnStart : MonoBehaviour {
    GameObject crosshair;
    GameObject gun;
    GameObject player;

	// Use this for initialization
	void Start () {
        //Add the crosshair
        Vector2 mouseLocation = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
            Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

        crosshair = new GameObject();
        Texture2D crosshairTexture = Resources.Load("crosshair") as Texture2D;
        Sprite crosshairSprite = Sprite.Create(crosshairTexture, new Rect(new Vector2(0, 0),
            new Vector2(200, 200)), new Vector2(0, 0));
        SpriteRenderer crosshairRenderer = crosshair.AddComponent<SpriteRenderer>();
        crosshair.AddComponent<Crosshair>();
        crosshairRenderer.sprite = crosshairSprite;
        //Scale it down
        crosshair.transform.localScale = new Vector3(0.2F, 0.2F, 0.2F);

        //Make cursor invisible
        Cursor.visible = false;

        // Add the gun

        gun = new GameObject();
        Texture2D gunTexture = Resources.Load("gun") as Texture2D;
        Sprite gunSprite = Sprite.Create(gunTexture, new Rect(new Vector2(0, 0),
            new Vector2(gunTexture.width, gunTexture.height)), new Vector2(0, 0));
        SpriteRenderer gunRenderer = gun.AddComponent<SpriteRenderer>();
        gun.AddComponent<Gun>();
        gunRenderer.sprite = gunSprite;
        //Scale it down
        //gun.transform.localScale = new Vector3(0.5F, 0.5F, 0.5F);

    }
	
}
