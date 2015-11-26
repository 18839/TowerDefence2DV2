using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

    [SerializeField]
    public float _Enemyhealth = 100f;
    private GameObject _healthBar;


    private Color32 _changeColor;

    void Start()
    {
        _healthBar = GameObject.Find("Healthbar");
        _healthBar.GetComponent<Renderer>().material.color = Color.red;
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
       
        if (_Enemyhealth <= 99)
        {
            _changeColor = new Color(255,0,0,255);
            _healthBar = GameObject.Find("Healthbar");
            this._healthBar.GetComponent<Renderer>().material.color = _changeColor;
        }
        
        
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
