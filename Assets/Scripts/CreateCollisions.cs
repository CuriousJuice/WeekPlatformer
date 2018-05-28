using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCollisions{

    private static ArrayList sprites;
    private GameObject player;

    //Constructor
    public CreateCollisions(GameObject player)
    {
        this.player = player;
        GenerateStage stageGenerator = new GenerateStage();
        sprites = stageGenerator.Generate();
    }
	
	// Update is called once per frame
	public void Update () {
        foreach (GameObject platform in sprites)
        {
            //Checks to see if the player is within the (x, y) threshold for collision with the platforms.
            if (player.transform.position.y < platform.transform.position.y && ((player.transform.position.x >=
                platform.transform.position.x && player.transform.position.x <= (platform.transform.position.x + platform.transform.lossyScale.x)) ||
                ((player.transform.position.x + player.transform.lossyScale.x) >= platform.transform.position.x && (player.transform.position.x + 
                player.transform.lossyScale.x) <= (platform.transform.position.x + platform.transform.lossyScale.x))))
            {
                player.GetComponent<Player>().setAirborne(false);
                player.transform.position = new Vector2(player.transform.position.x, 
                    platform.transform.position.y);
                break; //used to terminate for loop early when collision is found.
            }
            //Sets the player to airborne if no collision is detected.
            else
            {
                player.GetComponent<Player>().setAirborne(true);
            }
        }
        //Debug.Log(player.GetComponent<Player>().airborne);
    }

}
