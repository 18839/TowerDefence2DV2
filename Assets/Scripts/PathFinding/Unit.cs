using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour
{

    [SerializeField]
    private Transform _target;
    [SerializeField]
    private float speed = 5;
    Vector3[] path;
    private int _targetIndex;

    public event System.Action noPath;


    void Start()
    {
        PathRequestManager.RequestPath(transform.position, _target.position, OnPathFound);
    }

    public void OnPathFound(Vector3[] newPath, bool pathSuccessful)
    {
        if (pathSuccessful)
        {
            Debug.Log("path");
            path = newPath;
            StopCoroutine("FollowPath");
            StartCoroutine("FollowPath");
        }
        else
        {
            if (noPath != null)
            {
                noPath();
            }
            Debug.Log("test");
            GameObject.Destroy(gameObject);
        }
    }
   

 
    IEnumerator FollowPath()
    {
        Vector3 currentWaypoint = path[0];

        while (true)
        {
           
            if (transform.position == currentWaypoint)
            {
               
                _targetIndex++;
                if (_targetIndex >= path.Length )
                {
                    _targetIndex = 0;
                    path = new Vector3[0];
                  
                }
                currentWaypoint = path[_targetIndex];
            }
            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, speed * Time.deltaTime);
            yield return null;
        }

    }


    public void OnDrawGizmos()
    {
        if (path != null)
        {
            for (int i = _targetIndex; i < path.Length; i++)
            {
                Gizmos.color = Color.black;
                Gizmos.DrawCube(path[i], Vector3.one);

                if (i == _targetIndex)
                {
                    Gizmos.DrawLine(transform.position, path[i]);
                }
                else
                {
                    Gizmos.DrawLine(path[i - 1], path[i]);
                }
            }
        }
    }
}
