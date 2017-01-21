﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveObjekts : MonoBehaviour
{
    public int speed;
    public int EnemyCount;
    public int health;
    public GameObject enemyPrefab;
    int time;               // mit absicht nicht public
    int[] n = new int[100]; //Zählarray


    public Vector3[] positiona = new Vector3[5];

    public List<GameObject> Enemies = new List<GameObject>();

    //public GameObject Waypoint;

    // Use this for initialization
    public void Start()
    {
        


        for (var i = 0; i < EnemyCount; i++)
        {
            GameObject myGameObject = Instantiate(enemyPrefab);
            myGameObject.transform.position = new Vector3(-10, -10, 0);
            Enemies.Add(myGameObject);
        }
        for (int i = 0; i < EnemyCount; i++)
            {
                n[i] = 0;
            }

    }

    // Update is called once per frame
    public void Update()
    {
       
        time++;
        if (time % 3 == 1)
        {

            for (int j = 0; j < EnemyCount; j++)
            {

                if (Enemies[j]!=null)
                {
                    Vector3 position = Enemies[j].transform.position;
                    
                    int x = (int)position.x;
                    int y = (int)position.y;
                    position.x = x;
                    position.y = y;
                    if (n[j] < positiona.Length)
                    {
                        if (time >= (j * 9))
                            for (int i = speed; i > 0; i--)
                            {
                            if (position.x < positiona[n[j]].x)
                            {
                                position.x = position.x + 1;
                            }
                            else if (position.x > positiona[n[j]].x)
                            {
                                position.x = position.x - 1;
                            }
                            else if (position.y < positiona[n[j]].y)
                            {
                                position.y = position.y + 1;
                            }
                            else if (position.y > positiona[n[j]].y)
                            {
                                position.y = position.y - 1;
                            }


                            else if (position.x == positiona[n[j]].x && position.y == positiona[n[j]].y && n[j] == positiona.Length - 1)
                            {
                                    // hier müssen sich die minions noch auflösen
                                    Sprite.Destroy(Enemies[j]);
                                    //Enemies[j] = Enemies[j + 1];
                                    
                            }
                            else if (position.x == positiona[n[j]].x && position.y == positiona[n[j]].y && n[j] < positiona.Length - 1)
                            {
                                n[j]++;
                                  
                            }

                        Enemies[j].transform.position = position;

                    }
                }

                }
            }
        }
    }
}


