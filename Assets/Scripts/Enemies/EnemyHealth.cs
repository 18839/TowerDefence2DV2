using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

    [SerializeField]
    public float _Enemyhealth = 100f;
    [SerializeField]
    private GameObject _healthBar;


    private float _EnemyHpScaler;
    private Color32 _changeColor;

    void Start()
    {
        //_healthBar = GameObject.Find("Healthbar");
        _healthBar.GetComponent<Renderer>().material.color = Color.red;
        _EnemyHpScaler = (_Enemyhealth / 2);
    }

    void Update()
    {
        DestroyEnemy();
        AdjustHealthBar();
        
    }

    void DestroyEnemy()
    {
        if (_Enemyhealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void AdjustHealthBar()
    {
        _healthBar.transform.localScale = new Vector3((_Enemyhealth / _EnemyHpScaler), 0.15f, 1f);    
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag=="Bullet")
        {
            _Enemyhealth -= 50;
            Destroy(other.gameObject);
        }
    }
}
