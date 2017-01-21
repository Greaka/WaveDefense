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

    private void Aktualisierung(Enemy Enemies)
    {
        Vector3 a = Enemies.transform.position;
        Vector3 b = positiona[Enemies.Speicherpunkt];
        for (int i = 1; i > 0; i--)
        {
            if (a != b)
            {

                a = Onestep(a, b);
            }

            Enemies.transform.position = a;
            if (a == b&&Enemies.Speicherpunkt<positiona.Length-1)
            {
                Enemies.Speicherpunkt++;
            }
        }

    }
    private Vector3 Onestep(Vector3 a, Vector3 b)
    {
        if (a.x < b.x)
        {
            a.x = a.x + 1;
        }
        else if (a.x > b.x)
        {
            a.x = a.x - 1;
        }
        else if (a.y < b.y)
        {
            a.y = a.y + 1;
        }
        else if (a.y > b.y)
        {
            a.y = a.y - 1;
        }
        return a;
    }

    //public GameObject Waypoint;

    // Use this for initialization
    public void Start()
    {
        //hier die Weg punkte eintragen die die minions laufen sollen
        playerStats = GetComponent<PlayerStats>();

        for (var i = 0; i < EnemyCount; i++)
        {
            GameObject myGameObject = Instantiate(enemyPrefab);
            myGameObject.transform.position = new Vector3(-10, -4, 0);
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
        int i = 0;

        time++;
        foreach (Enemy element in Enemies)
        {
            if (time > i * (10.0-speed))
            {
                Aktualisierung(element);
            }
                i++;
        }
        


    }



}
    


