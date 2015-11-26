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

    public IEnumerator RemoveMessage()
    {
        _buildMessages.SetActive(true);
        yield return new WaitForSeconds(2);
        _buildMessages.SetActive(false);
    }
}
