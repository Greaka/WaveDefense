using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.VR;

public class MoveObjekts : MonoBehaviour
{
    public int speed;
    public int EnemyCount;
    public int health;
    public GameObject enemyPrefab;
    int time;               // mit absicht nicht public
    int[] n = new int[100]; //Zählarray

    private PlayerStats playerStats;

    public Vector3[] positiona = new Vector3[5];

    public List<Enemy> Enemies = new List<Enemy>();

    public List<Enemy> DeadEnemies = new List<Enemy>();

    //public GameObject Waypoint;

    // Use this for initialization
    public void Start()
    {
        //hier die Weg punkte eintragen die die minions laufen sollen
        playerStats = GetComponent<PlayerStats>();

        for (var i = 0; i < EnemyCount; i++)
        {
            GameObject myGameObject = Instantiate(enemyPrefab);
            var myscript = myGameObject.GetComponent<Enemy>();
            Enemies.Add(myscript);
            myscript.Die += playerStats.OnEnemyDeath;
            myscript.Die += EnemyDeath;
        }

    }

    public void EnemyDeath(Enemy instance)
    {
        DeadEnemies.Add(instance);
        Enemies.Remove(instance);
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


