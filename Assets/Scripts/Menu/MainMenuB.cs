using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuB : MonoBehaviour {


    private GameObject _playButton;


	void Start () {
        _playButton = GameObject.Find("Play");
        _playButton.GetComponent<Button>().onClick.AddListener(PlayButton);
	}
	

    void PlayButton()
    {
        Application.LoadLevel(1);
    }
}
