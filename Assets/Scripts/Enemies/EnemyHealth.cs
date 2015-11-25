using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

    [SerializeField]
    public float _Enemyhealth = 100f;
    private GameObject _healthBar;

    void Update()
    {
        DestroyEnemy();
        
    }

    void DestroyEnemy()
    {
        if (_Enemyhealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void DestroyThis()
    { 

}

    void AdjustHealthBar()
    {
        _Enemyhealth -= 50;
        _healthBar = GameObject.Find("HealthBar");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag=="Bullet")
        {
            AdjustHealthBar();
            Destroy(other.gameObject);

            
            
           
        }
    }
}
