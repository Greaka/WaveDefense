using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartNewGame : MonoBehaviour {

    //StartGameWhenTitlePressed
    private void OnMouseDown()
    {
        Application.LoadLevel("");
    }
}
