using UnityEngine;
using UnityEngine.UI;

public class GoldBind : MonoBehaviour
{
    public Text GoldText;
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
        GoldText.text = prefix + playerStats.PlayerHealth;
    }
}