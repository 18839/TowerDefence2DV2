using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CheckWave : MonoBehaviour
{
    
    private GameObject _waveText;
    public float _waveValue;

    // Use this for initialization
    void Start()
    {
        _waveValue = 0;
        _waveValue += 1;
        _waveText = GameObject.Find("ShowWave");

        
    }

    public void AddWave()
    {
        _waveText.GetComponent<Text>().text = _waveValue + "/10";
        _waveValue += 1;
    }

    void Update()
    {

    }
}
