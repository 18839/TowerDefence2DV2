using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CoinsController : MonoBehaviour {

    private GameObject _coinsText;
    public float _coinsValue;

    void Awake()
    {
        _coinsText = GameObject.Find("CoinsValue");
        
    }

	void Start () 
    {
        
        _coinsValue = 1000f;
        _coinsText.GetComponent<Text>().text = " " + _coinsValue;
        
	}
	
	void CheckCoins()
    {
        _coinsText.GetComponent<Text>().text = " " + _coinsValue;
    }

    public void RemoveCoins()
    {
        CheckCoins();
        _coinsValue -= 500f;
    }
}
