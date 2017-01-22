using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.VR;


public class EnemyMovement : MonoBehaviour
{
    public float speed = 1;
    public int EnemyCount;
    public int health;
    public GameObject enemyPrefab;

    private PlayerStats playerStats;

    public Vector3[] checkPoints;

    public List<Enemy> Enemies = new List<Enemy>();

    public List<Enemy> DeadEnemies = new List<Enemy>();

    public int EnemyHealth = 7;

    public int enemybounty = 1;

    public void Awake()
    {
        checkPoints = new Vector3[]{

new Vector3 { x = 6, y = -14, z = 0 },
new Vector3 { x = 22, y = -8, z = 0 },
new Vector3 { x = 35, y = -19, z = 0 },
new Vector3 { x = 44, y = -13, z = 0 },
new Vector3 { x = 53, y = -28, z = 0 },
new Vector3 { x = 37, y = -33, z = 0 },
new Vector3 { x = 24, y = -26, z = 0 },
new Vector3 { x = 15, y = -33, z = 0 },
new Vector3 { x = 5, y = -28, z = 0 },
new Vector3 { x = -5, y = -42, z = 0 },
new Vector3 { x = 6, y = -47, z = 0 },
new Vector3 { x = 24, y = -40, z = 0 },
new Vector3 { x = 33, y = -44, z = 0 },
new Vector3 { x = 49, y = -53, z = 0 },
new Vector3 { x = 40, y = -58, z = 0 },
new Vector3 { x = 11, y = -53, z = 0 },
new Vector3 { x = -4, y = -53, z = 0 }

    };

    }

    private void Aktualisierung(Enemy enemy)
    {
        Vector3 a = enemy.transform.position;
        Vector3 b = checkPoints[enemy.Speicherpunkt];
        var d = a;
        if (a != b)
        {
            d = DirectionDecision(a, b) + a;
        }

        enemy.transform.position = d;
        if (a == b && enemy.Speicherpunkt <= checkPoints.Length - 1)
        {
            enemy.Speicherpunkt++;
        }

        if (a == b && enemy.Speicherpunkt == checkPoints.Length)
        {
            enemy.isDead = true;
        }

        enemy.Update();
    }

    private Vector3 DirectionDecision(Vector3 eigenePosition, Vector3 checkpoint)
    {
        var c = Vector3.zero;
        if (eigenePosition.x < checkpoint.x)
        {
            if (checkpoint.x - eigenePosition.x < Time.deltaTime * speed)
            {
                c.x = checkpoint.x - eigenePosition.x;
            }
            else
            {
                c.x = Time.deltaTime * speed;
            }
        }
        else if (eigenePosition.x > checkpoint.x)
        {
            if (checkpoint.x - eigenePosition.x > -Time.deltaTime * speed)
            {
                c.x = checkpoint.x - eigenePosition.x;
            }
            else
            {
                c.x = -Time.deltaTime * speed;
            }
        }
        else if (eigenePosition.y < checkpoint.y)
        {
            if (checkpoint.y - eigenePosition.y < Time.deltaTime * speed)
            {
                c.y = checkpoint.y - eigenePosition.y;
            }
            else
            {
                c.y = Time.deltaTime * speed;
            }
        }
        else if (eigenePosition.y > checkpoint.y)
        {
            if (checkpoint.y - eigenePosition.y > -Time.deltaTime * speed)
            {
                c.y = checkpoint.y - eigenePosition.y;
            }
            else
            {
                c.y = -Time.deltaTime * speed;
            }
        }

        return c;
    }

    //public GameObject Waypoint;

    // Use this for initialization
    public void Start()
    {
        //hier die Weg punkte eintragen die die minions laufen sollen
        playerStats = GetComponent<PlayerStats>();

        CreateEnemy();
    }

    private void CreateEnemy()
    {
        ++MapInfo.Wave;

        for (var i = 0; i < EnemyCount; i++)
        {
            GameObject myGameObject = Instantiate(enemyPrefab);
            myGameObject.transform.position = new Vector3(-10, -4, 0);
            var myscript = myGameObject.GetComponent<Enemy>();
            Enemies.Add(myscript);
            myscript.Delay = (double)i / EnemyCount * 2;
            myscript.Health = EnemyHealth;
            myscript.Bounty = enemybounty;
            myscript.Die += playerStats.OnEnemyDeath;
            myscript.Die += EnemyDeath;
        }

        enemybounty *= 2;
        EnemyHealth *= 2;
    }

    public void EnemyDeath(Enemy instance)
    {
        DeadEnemies.Add(instance);
    }

    public void FixedUpdate()
    {
        foreach (var enemy in Enemies)
        {
            if (enemy.Delay > 0)
            {
                enemy.Delay -= Time.deltaTime;
                if (enemy.Delay < 0)
                {
                    enemy.Delay = 0;
                }
            }
            else
            {
                Aktualisierung(enemy);
            }
        }
    }

    // Update is called once per frame
    public void Update()
    {
        foreach (var enemy in DeadEnemies)
        {
            enemy.Update();
        }

        while (DeadEnemies.Count > 0)
        {
            var enemy = DeadEnemies[0];
            Enemies.Remove(enemy);
            DeadEnemies.RemoveAt(0);
            Destroy(enemy.gameObject);
        }

        if (Enemies.Count == 0)
        {
            CreateEnemy();
        }
    }
}
    


