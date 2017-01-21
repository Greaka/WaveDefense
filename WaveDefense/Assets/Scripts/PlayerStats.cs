using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    private static PlayerStats _instance;

    public static int PlayerHealth = 100;

    public static int PlayerWealth = 0;

    public static PlayerStats Instance
    {
        get
        {
            if (_instance != null)
                return _instance;
            var CharacterLoadout = new GameObject("PlayerStats");
            _instance = CharacterLoadout.AddComponent<PlayerStats>();
            return _instance;
        }
        private set { }
    }

    public void OnEnemyDeath(Enemy instance)
    {
        if (instance.Health > 0)
            PlayerHealth -= instance.Damage;
        else
            PlayerWealth += instance.Bounty;
    }

    public void Awake()
    {
        if (gameObject.gameObject == null)
            DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        if (PlayerHealth <= 0)
        {
            Console.WriteLine("GAMEOVER");
            SceneManager.LoadScene("Lost");
        }

    }
}