using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjekts : MonoBehaviour
{
    public int speed = 2;
    int n = 0;
    public int health = 100;
    public Vector3[] positiona = new Vector3[5];

    //public GameObject Waypoint;

    // Use this for initialization
    public void Start()
    {
        //hier die Weg punkte eintragen die die minions laufen sollen






    }

    // Update is called once per frame
    public void Update()
    {
        if (health <= 0)
        {
            Sprite.Destroy(gameObject);
        }

        Vector3 position = this.transform.position;
        //Vector3 position1 = Waypoint.transform.position;
        int x = (int)position.x;
        int y = (int)position.y;
        position.x = x;
        position.y = y;
        if (n < positiona.Length)
        {
            for (int i = speed; i > 0; i--)
            {
                if (position.x < positiona[n].x)
                {
                    position.x++;
                }
                else if (position.x > positiona[n].x)
                {
                    position.x--;
                }
                else if (position.y < positiona[n].y)
                {
                    position.y++;
                }
                else if (position.y > positiona[n].y)
                {
                    position.y--;
                }

                else if(position.x==positiona[n].x&& position.y == positiona[n].y)
                {
                    n++;
                }



                this.transform.position = position;

            }

        }
    }
}


