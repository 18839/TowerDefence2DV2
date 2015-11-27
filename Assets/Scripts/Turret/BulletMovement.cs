using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour {

    //Floats
    [SerializeField]
    private float bulletVelocity;
    //Floats

    //GameObjects
    private GameObject target;
    //GameObjects


    public void setTarget(GameObject obj)
    {
        target = obj;
    }

    void Start()
    {
        bulletVelocity = 5f * Time.deltaTime;
    }

    void Update()
    {
        CheckIfNull();
    }


    void CheckIfNull()
    {
        if (target.gameObject != null)
        {
            this.transform.position = Vector2.MoveTowards(transform.position, target.transform.position, bulletVelocity);
        }

        else if (target.gameObject == null)
        {
            Destroy(this.gameObject);
        }
    }
}
