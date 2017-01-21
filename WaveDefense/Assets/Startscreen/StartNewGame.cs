using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartNewGame : MonoBehaviour
{

    public Button btn;

    public void Start()
    {
        btn.onClick.AddListener(MouseClick);
    }

    //StartGameWhenTitlePressed
    private static void MouseClick()
    {
        SceneManager.LoadScene("");
    }
}
