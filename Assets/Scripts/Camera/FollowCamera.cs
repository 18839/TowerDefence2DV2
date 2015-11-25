using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {

    private Vector2 mousePosition;
    private Vector2 goRight;
    private Vector2 goLeft;
    [SerializeField]
    private Transform right;
    [SerializeField]
    private Transform left;
    // Use this for initialization
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        CheckMouse();
    }

    void CheckMouse()
    {
        goRight = right.position;
        goLeft = left.position;
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        if (mousePosition.x <= goLeft.x)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-10, 0));
        }
        else if (mousePosition.x >= goRight.x)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(10, 0));
        }
        else
            GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        
    }
}