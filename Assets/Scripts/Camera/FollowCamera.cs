using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {

    [SerializeField]
    private GameObject target;
    private Vector3 offset;

    // Use this for initialization
    void Start()
    {
        //target = GameObject.FindGameObjectWithTag("Ball");
        offset = target.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = target.transform.position;
    }
}