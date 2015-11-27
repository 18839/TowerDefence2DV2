using UnityEngine;
using System.Collections;

public class Messages : MonoBehaviour {


    private GameObject _buildMessages;

	void Start () 
    {
        _buildMessages = GameObject.Find("BuildMessage");
        StartCoroutine("RemoveMessage");
	}
	
	
	void Update () 
    {
	//
	}

    IEnumerator RemoveMessage()
    {
        yield return new WaitForSeconds(2);
        _buildMessages.SetActive(false);
    }
}
