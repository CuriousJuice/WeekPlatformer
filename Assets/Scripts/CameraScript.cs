using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
    private GameObject player;
    //private CreateCollisions collision;
    GenerateStage generator;
    private Vector3 distance;
    private float distanceOffset;

	// Use this for initialization
	void Start () {
        //Set framerate
        Application.targetFrameRate = 60;

        //Find camera distance
        distance = Camera.main.ViewportToWorldPoint(new Vector3(0,0,0));
        distanceOffset = distance.x * -0.75F;

        //Texture2D playerTexture = Resources.Load("square") as Texture2D;
        //Sprite playerSprite = Sprite.Create(playerTexture, new Rect(new Vector2(0,0), new Vector2(100, 100)), new Vector2(0, 0));
        //player = new GameObject("Player");
        //SpriteRenderer playerRenderer = player.AddComponent<SpriteRenderer>();
        //player.AddComponent<Player>();
        //playerRenderer.sprite = playerSprite;
        GameObject holder = Resources.Load("PlayerPref") as GameObject;
        player = Instantiate(holder, new Vector2(0, 0), Quaternion.identity);

        //Initial camera position
        gameObject.transform.position = new Vector3(0,0,-15);
    }
	
	// Update is called once per frame
	void Update () {
            if (player.transform.position.x > gameObject.transform.position.x)
        {
            gameObject.transform.position = new Vector3(player.transform.position.x, gameObject.transform.position.y,
                gameObject.transform.position.z);
        }
        else if (player.transform.position.x < gameObject.transform.position.x - distanceOffset)
        {
            gameObject.transform.position = new Vector3(player.transform.position.x + distanceOffset,
                gameObject.transform.position.y, gameObject.transform.position.z);
        }
        //collision.Update();
    }

    public GameObject GetPlayer()
    {
        return player;
    }
}
