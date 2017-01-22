using UnityEngine;
using UnityEngine.UI;

public class WaveBind : MonoBehaviour
{
    public Text WaveText;
    public string prefix;

    // Update is called once per frame
    public void Update()
    {
        WaveText.text = prefix + MapInfo.Wave;
    }
}