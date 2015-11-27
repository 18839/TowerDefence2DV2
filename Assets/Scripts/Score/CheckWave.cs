using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CheckWave : MonoBehaviour
{
    //GameObject
    private GameObject _waveText;
    //GameObject

    //Float
    public float _waveValue;
    //Float

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
}
