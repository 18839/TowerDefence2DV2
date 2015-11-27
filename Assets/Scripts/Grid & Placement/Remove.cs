using UnityEngine;
using System.Collections;

public class Remove : MonoBehaviour {

    private Transform obj;

    void Start()
    {
        obj = this.gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))

                if (hit.collider.gameObject == obj)
                {
                    Destroy(hit.collider.gameObject);
                }
        }
    }
}
