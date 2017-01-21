using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update ()
    {
        var position = gameObject.transform.position;
        if (Input.GetKeyDown("a"))
            position += new Vector3(-1, 0, 0);
        if (Input.GetKeyDown("s"))
            position += new Vector3(0, -1, 0);
        if (Input.GetKeyDown("d"))
            position += new Vector3(1, 0, 0);
        if (Input.GetKeyDown("w"))
            position += new Vector3(0, 1, 0);

        gameObject.transform.position = position;
    }
}