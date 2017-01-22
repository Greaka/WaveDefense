using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    private Vector2 mousePos;
    private bool placing = true;
    public Texture tex;
    public UIInfo uiinfo;
    public SpriteRenderer spritetower;
    public Tower_Angriff towerangriff;

    void Start()
    {
        mousePos = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);
    }

	// Update is called once per frame
	void Update () {
        //button 0 leftclick
        //button 1 rightclick
        //button 2 middleclick
        mousePos = Input.mousePosition;
	    var mouseDown = Input.GetMouseButtonDown(0);


        if (uiinfo.IsInRect(mousePos) && mouseDown)
        {
            int index = uiinfo.GetTowerIndex(mousePos);
            

            switch (index)
            {
                case 0:
                    placing = true;
                   break;
                case 1:
                    placing = true;
                    break;
                case 2:
                    placing = true;
                    break;
                default:
                    break;
            }
	    }

	    if (placing && mouseDown && PlayerStats.PlayerWealth >= towerangriff.cost)
	    {
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            //Vector2 curtile = mousePos-new Vector2(mousePos.x%1,mousePos.y%1);
	       // spritetower.transform.position = curtile;
            //Debug.Log(curtile);
	        Tower_Angriff tower = Instantiate(towerangriff);
	        tower.gameObject.transform.position = mousePos;
	        PlayerStats.PlayerWealth -= tower.cost;
	    }
	}
}
