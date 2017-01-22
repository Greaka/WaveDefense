using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UIInfo : MonoBehaviour
{

    private List<RectTransform> towlist;
    // Use this for initialization
    void Start ()
	{
        towlist = gameObject.GetComponentsInChildren<RectTransform>().ToList();
        List<RectTransform> helper = new List<RectTransform>(towlist.Count);
        while (towlist.Count > 0)
	    {
	        int small = 0;
	        for (Int16 i = 0; i < towlist.Count; i++)
	        {
	            if (towlist[i].position.x <= towlist[small].position.x)
	                small = i;
	        }
	        helper.Add(towlist[small]);
            towlist.RemoveAt(small);
	    }
	    towlist = helper;
        //Debug.Log(towlist[0].position);
	}

    public bool IsInRect(Vector2 vec)
    {
         
        foreach (RectTransform stuff in towlist)
        {
            if (stuff.rect.Contains(vec))
                return true;
        }
        return false;
    }

    public int GetTowerIndex(Vector2 vec)
    {
        for (int i = 0; i < towlist.Count; i++)
        {
            if (towlist[i].rect.Contains(vec))
                return i;
        }
        return -1;
    }

    public Texture GetTexture(int index)
    {
        return towlist[index].GetComponent<Image>().mainTexture;
    }
	// Update is called once per frame
	void Update () {
		//if (Input.anyKeyDown)
        //    Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }
}
