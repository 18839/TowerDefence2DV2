using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour
{

    [SerializeField]
    private Transform _target;
    [SerializeField]
    private float speed = 5;
    //private bool reset = false;
    Vector3[] path;
    private int _targetIndex;

    public event System.Action noPath;

    //private bool reset = false;

    void Start()
    {
        PathRequestManager.RequestPath(transform.position, _target.position, OnPathFound);
        //StartCoroutine("DynamicPath"); //maybe for dynamic
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
    /*void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StopCoroutine("DynamicPath");
            StartCoroutine("DynamicPath");
        }
    }
    IEnumerator DynamicPath()
    /*IEnumerator DynamicPath()
    {
        //float RefreshTime = .5f;
        while (true)
        {
            reset = true;
            PathRequestManager.RequestPath(transform.position, target.position, OnPathFound);
            yield break;
            //yield return new WaitForSeconds(RefreshTime);
        }
    }*/
    //maybe for dynamic
    IEnumerator FollowPath()
    {
        Vector3 currentWaypoint = path[0];

        while (true)
        {
            /*if (reset)
            {
                reset = false;
                targetIndex = 0;
                currentWaypoint = path[targetIndex];
                path = new Vector3[0];
            }*/
            //maybe for dynamic
            if (transform.position == currentWaypoint)
            {
                //StopCoroutine("DynamicPath");
                //StartCoroutine("DynamicPath");
                _targetIndex++;
                if (_targetIndex >= path.Length /*&& !reset*/)
                {
                    _targetIndex = 0;
                    path = new Vector3[0];
                    //yield break;
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