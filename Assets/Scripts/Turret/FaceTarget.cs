using UnityEngine;
using System.Collections;

public class FaceTarget : MonoBehaviour
{



    //LayerMasks
    [SerializeField]
    private LayerMask enemyLayer;
    //LayerMasks

    //Transforms
    private Transform _targetTransform;
    //Transforms

    //Floats
    private float atan2;
    private float _trackingSpeed = 5f;
    //Floats

    //GameObjects
    private GameObject _closestEnemy;
    private GameObject target;
    private GameObject[] _towerObjects;
    private GameObject[] _enemyObjects;
    //GameObjects

    //Vector3
    private Vector3 v_diff;
    //Vector3


    void Start()
    {
        target = GameObject.Find("Target");
        _targetTransform = target.transform;
        _towerObjects = GameObject.FindGameObjectsWithTag("Tower");
        _enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");
    }


    void Update()
    {
        FindEnemy();
        RemoveEnemy();
        RotateTowers();
        RotateEnemies();
    }

    void FindEnemy()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(this.gameObject.transform.position, 5f, enemyLayer);


        float shortestDistance = float.MaxValue;

        for (int i = 0; i < hitEnemies.Length; i++)
        {
            float distance = Vector2.Distance(this.gameObject.transform.position, hitEnemies[i].transform.position);

            if (distance < shortestDistance)
            {
                _closestEnemy = hitEnemies[i].gameObject;
                shortestDistance = distance;
            }
        }
    }

   

    void RotateTowers()
    {

        foreach (GameObject towers in _towerObjects)
        {
            if (_closestEnemy != null)
            {
                if (this.gameObject.tag == "Tower" || (this.gameObject.tag) == "Bullet")
                {
                    _targetTransform = _closestEnemy.transform;
                    v_diff = (_targetTransform.position - transform.position);
                    if (this.gameObject.name == ("Cannon(Clone)") || this.gameObject.name == "Bullet(Clone)")
                        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f, (atan2 * Mathf.Rad2Deg) - 90), _trackingSpeed * Time.deltaTime);
                    else
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f, (atan2 * Mathf.Rad2Deg) - 180), _trackingSpeed * Time.deltaTime);
                    atan2 = Mathf.Atan2(v_diff.y, v_diff.x);
                   
                }
            }
        }
  
    }

    void RotateEnemies()
    {
        foreach (GameObject enemies in _enemyObjects)
        {
            if (target != null)
            {
                if (this.gameObject.tag == "Enemy")
                {
                    _targetTransform = target.transform;
                    v_diff = (_targetTransform.position - transform.position);
                    atan2 = Mathf.Atan2(v_diff.y, v_diff.x);
                    if (this.gameObject.name == "Snail(Clone)")
                    transform.rotation = Quaternion.Euler(0f, 0f, (atan2 * Mathf.Rad2Deg) - 90);
                    else if (this.gameObject.name == "Fly(Clone)")
                    transform.rotation = Quaternion.Euler(0f, 0f, (atan2 * Mathf.Rad2Deg) - 90);
                    else if (this.gameObject.name == "Boss(Clone)")
                        transform.rotation = Quaternion.Euler(0f, 0f, (atan2 * Mathf.Rad2Deg) - 180);
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.gameObject.transform.position, 5f);
    }

    void RemoveEnemy()
    {
        if (_closestEnemy == null)
        {
            if (this.gameObject.tag == "Bullet")
            {
                Destroy(this.gameObject);
            }
        }
    }
}