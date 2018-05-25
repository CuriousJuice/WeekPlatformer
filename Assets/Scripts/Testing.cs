using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour {

    public Sprite sprite;

	// Use this for initialization
	void Start () {
        Debug.Log("Hello");
        var obj = (Sprite)Instantiate(this.sprite, transform.position, transform.rotation);
    }

 }
