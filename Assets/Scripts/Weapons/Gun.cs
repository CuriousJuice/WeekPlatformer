using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gun : Weapon {
    GameObject player;
    Vector2 playerMiddle; //Midpoint of player

	// Use this for initialization
	void Start () {
        player = Camera.main.GetComponent<CameraScript>().GetPlayer();
        playerMiddle = new Vector2(player.transform.position.x + player.GetComponent<SpriteRenderer>().bounds.size.x / 2,
            player.transform.position.y + player.GetComponent<SpriteRenderer>().bounds.size.y / 2);
    }
	
	// Update is called once per frame
	void Update () {
        //Update player middle
    //    playerMiddle = new Vector2(player.transform.position.x + player.GetComponent<SpriteRenderer>().bounds.size.x / 2,
    //player.transform.position.y + player.GetComponent<SpriteRenderer>().bounds.size.y / 2);
        playerMiddle = new Vector2(player.transform.position.x, player.transform.position.y);

        //Stick to player
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, - 0.001F);
        //Point to mouse
        Vector2 mouseLocation = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
            Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

        Vector2 playerToMouse = mouseLocation - playerMiddle;

        float rotateAngle = Vector2.Angle(playerToMouse, new Vector2(1, 0));
        //Adjust to get the larger angle if mouse is below (1,0) vector
        if (playerToMouse.y < 0)
        {
            rotateAngle = 360 - rotateAngle;
        }
        //Set rotation
        transform.rotation = Quaternion.Euler(0, 0, rotateAngle);


        //print(rotateAngle);
    }
}
