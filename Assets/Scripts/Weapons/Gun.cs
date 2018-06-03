using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gun : Weapon {
    GameObject player;

	// Use this for initialization
	void Start () {
        player = Camera.main.GetComponent<CameraScript>().GetPlayer();
	}
	
	// Update is called once per frame
	void Update () {
        //Stick to player
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 0.001F);
	}
}
