using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var position = gameObject.transform.position;
        if (Input.GetKey("a") && Camera.main.transform.position.x>=0)
            position += new Vector3(-1, 0, 0) * Camera.main.orthographicSize / 15;
        if (Input.GetKey("s"))
            position += new Vector3(0, -1, 0) * Camera.main.orthographicSize / 15;
        if (Input.GetKey("d"))
            position += new Vector3(1, 0, 0) * Camera.main.orthographicSize / 15;
        if (Input.GetKey("w"))
            position += new Vector3(0, 1, 0) * Camera.main.orthographicSize / 15;
        position.x = Mathf.Clamp(position.x, 20F,26F);
        position.y = Mathf.Clamp(position.y, -45F, -15F);
        
        gameObject.transform.position = position;

        const int orthographicSizeMin = 8;
        const int orthographicSizeMax = 20;

        if (Input.GetAxis("Mouse ScrollWheel") < 0) // forward
        {
            Camera.main.orthographicSize++;
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0) // back
        {
            Camera.main.orthographicSize--;
        }

        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, orthographicSizeMin, orthographicSizeMax);
    }
}