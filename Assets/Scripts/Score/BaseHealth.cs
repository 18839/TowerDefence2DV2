using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BaseHealth : MonoBehaviour
{
    //LayerMasks
    [SerializeField]
    private LayerMask enemyLayer;
    //LayerMasks

    //GameObjects
    private GameObject _bHealthText;
    private GameObject _baseObject;
    private GameObject _enemyObject;
    //GameObjects

    //Floats
    [SerializeField]
    private float _bHealthValue;
    private float _downSpeed = 10f;
    //Floats

    //Bools
    private bool _showHealth = false;
    //Bools
    

    void Start()
    {
        _baseObject = GameObject.Find("Target");
        _bHealthValue = 100f;
        _bHealthText = GameObject.Find("TowerHealth");

        _bHealthText.GetComponent<Text>().text = _bHealthValue + " ";
    }

    void Update()
    {
        DropHealth();
        ShowHealth();
        ChangeScene();
    }

    void DropHealth()
    {
        if (_showHealth)
        {
            if (_bHealthValue >= 0)
            {

                _bHealthValue -= _downSpeed * Time.deltaTime;
                Mathf.Round(_bHealthValue);
            }
        }   
    }

    void ShowHealth()
    {
        if (_showHealth)
            _bHealthText.GetComponent<Text>().text = _bHealthValue.ToString("f0") + " ";
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            _showHealth = true;
            
        }
    }
   

    void ChangeScene()
    {
        if (_bHealthValue <= 0)
        {
            Application.LoadLevel(2);
        }
    }

}
