using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

    [SerializeField]
     private Transform target;
    [SerializeField]
    private Transform _baseTransform;

     private Vector3 v_diff;
     private float atan2;
     private float trackingSpeed = 5f;
     private float _enemyTrackingSpeed = 10f;
 



     void Update()
     {
         if (target != null)
         {
             if (this.gameObject.tag == "Archer" || this.gameObject.tag == "Bullet" || this.gameObject.tag == "Wizard")
             {
                 ArcherRotation();
             }

             else if (this.gameObject.tag == "Enemy")
             {
                 EnemyRotation();
             }
         }
        
     }
 

    void ArcherRotation()
     {
         v_diff = (target.position + transform.position);
         atan2 = Mathf.Atan2(v_diff.y, v_diff.x);
         transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f, (atan2 - Mathf.Rad2Deg)-110), trackingSpeed * Time.deltaTime);
     }

    void EnemyRotation()
    {
        v_diff = (_baseTransform.position + transform.position);
        atan2 = Mathf.Atan2(v_diff.y, v_diff.x);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f, (atan2 - Mathf.Rad2Deg) - 45), trackingSpeed * Time.deltaTime);
    }

}
