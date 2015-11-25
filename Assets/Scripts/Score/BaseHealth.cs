using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BaseHealth : MonoBehaviour
{

    [SerializeField]
    private LayerMask enemyLayer;

    private GameObject _bHealthText;
    private GameObject _baseObject;

    private float _bHealthValue;

    void Start()
    {
        _baseObject = GameObject.Find("Target");
        _bHealthValue = 100f;
        _bHealthText = GameObject.Find("TowerPercentage");

        _bHealthText.GetComponent<Text>().text = _bHealthValue + "%";
    }

    void FindEnemy()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(_baseObject.gameObject.transform.position, 2f, enemyLayer);


        for (int i = 0; i < hitEnemies.Length; i++)
        {
            Debug.Log("Werk?");
        }

    }
   

}
