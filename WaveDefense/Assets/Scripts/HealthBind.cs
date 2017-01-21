using UnityEngine;
using UnityEngine.UI;

public class HealthBind : MonoBehaviour
{
    public Text HealthText;
    private PlayerStats playerStats;
    public string prefix;

    // Use this for initialization
    public void Start()
    {
        playerStats = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    public void Update()
    {
        HealthText.text = prefix + playerStats.PlayerHealth;
    }
}