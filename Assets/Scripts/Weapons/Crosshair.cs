using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
    }

    // Update is called once per frame
    void Update () {
        // Get mouse coordinates
        Vector2 mouseLocation = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
            Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        // Affix crosshair to mouse location (Offset by half downwards, then half to the left)
        gameObject.transform.position = new Vector2(mouseLocation.x - GetComponent<SpriteRenderer>().bounds.size.x / 2,
            mouseLocation.y - GetComponent<SpriteRenderer>().bounds.size.y / 2);
	}
}
