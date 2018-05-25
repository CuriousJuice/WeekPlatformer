using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    Vector2 velocity;

	// Use this for initialization
	public void Start () {
        velocity = new Vector2(1, 0);
	}
	
	// Update is called once per frame
	public void Update () {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            gameObject.transform.position = (Vector2)gameObject.transform.position + velocity;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            gameObject.transform.position = (Vector2)gameObject.transform.position - velocity;
        }
    }
}
