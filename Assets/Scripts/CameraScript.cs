using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Texture2D playerTexture = Resources.Load("square") as Texture2D;
        Sprite playerSprite = Sprite.Create(playerTexture, new Rect(new Vector2(0,0), new Vector2(100, 100)), new Vector2(0, 0));
        GameObject playerObject = new GameObject("Player");
        SpriteRenderer playerRenderer = playerObject.AddComponent<SpriteRenderer>();
        playerObject.AddComponent<Player>();
        playerRenderer.sprite = playerSprite;

        gameObject.transform.position = new Vector3(0,0,-15);

    }
	
	// Update is called once per frame
	void Update () {
	}
}
