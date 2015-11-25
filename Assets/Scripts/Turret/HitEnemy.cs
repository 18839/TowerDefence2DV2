using UnityEngine;
using System.Collections;

public class HitEnemy : MonoBehaviour {

    [SerializeField]
    private LayerMask enemyLayer;

    private Collider2D[] _hitEnemies;
    private GameObject _enemyToHit;

	// Use this for initialization
	void Start () 
    { 
        _hitEnemies = Physics2D.OverlapCircleAll(this.gameObject.transform.position, 4f, enemyLayer);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FindEnemy()
    {
        for (int i = 0; i < _hitEnemies.Length; i++)
        {
            
                _enemyToHit = _hitEnemies[i].gameObject;

        }

        if (_enemyToHit != null)
        {
            FindEnemy();
        }
    }
}
