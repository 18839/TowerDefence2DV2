using UnityEngine;
using System.Collections;

public class ShootEnemy : MonoBehaviour {

    //LayerMasks
    [SerializeField]
    private LayerMask enemyLayer;
    //LayerMasks

    //GameObjects
    [SerializeField]
    private GameObject bulletObj;
    private GameObject closestEnemy;
    //GameObjects

    //Vector2
   private Vector2 bulletSpawnVec;
    //Vector2

    //Animator
    Animator anim;
    //Animator


	void Start () 
    {
       InvokeRepeating("FindEnemy", 0, 1f);
       anim = this.gameObject.GetComponent<Animator>();
	}



	void FindEnemy()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(this.gameObject.transform.position, 2f, enemyLayer);


        float shortestDistance = float.MaxValue;

        for (int i = 0; i < hitEnemies.Length; i++)
        {
            float distance = Vector2.Distance(this.gameObject.transform.position, hitEnemies[i].transform.position);

            if (distance < shortestDistance)
            {
                closestEnemy = hitEnemies[i].gameObject;
                shortestDistance = distance;
            }
        }

            if (closestEnemy != null)
            {
                ShootBullet();
                Animations();
            }
        
    }
   
    void SpawnBullets()
    {
        GameObject bulletToSpawn = Instantiate(bulletObj, transform.position, transform.rotation) as GameObject;
        bulletToSpawn.GetComponent<BulletMovement>().setTarget(closestEnemy);    
    }

  

    void ShootBullet()
    {
        SpawnBullets();
    }

    void Animations()
    {
        if (this.gameObject.name == "TowerArcher(Clone)")
        {
            anim.SetBool("Shoot", true);
            anim.SetBool("Idle", false);
        }

        else if (this.gameObject.name == "Wizard(Clone)")
        {
            anim.SetBool("Lightning", true);
        }

        else if (this.gameObject.name == "Cannon(Clone)")
        {

        }
    }
     
}
