using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private static PlayerStats _instance;

    public int PlayerHealth;

    public int PlayerWealth;

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
        PlayerWealth += instance.Bounty;
    }

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}