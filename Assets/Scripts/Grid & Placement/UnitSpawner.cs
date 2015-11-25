using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UnitSpawner : MonoBehaviour {

    //Transforms
    [SerializeField]
    private GameObject[] _enemyToSpawn;
    //Transforms

    //Floats
    [SerializeField]

    private float _waitTime;
    private float _waveDuration;

    //Floats

    //Vector2
    private Vector2 spawnPos;
    //Vector2


    //Bools
    [SerializeField]
    public bool waveRunning = false;
    //Bools

    //GameObjects
    private GameObject _startWave;
    //GameObjects

    //Scripts
    private GameObject _scoreController;
    private CheckWave _waveScript;
    //Scripts

	void Start () 
    {
        _scoreController = GameObject.Find("ScoreController");
         _waveScript = _scoreController.GetComponent<CheckWave>();
        _startWave = GameObject.Find("WaveButton");
        _startWave.GetComponent<Button>().onClick.AddListener(InvokeEnemies);
        _waveDuration = 10f;
	}

    void InvokeEnemies()
    {
        waveRunning = true;
        _waveScript.AddWave();
        spawnPos = transform.position;
        InvokeRepeating("SpawnRepeater", 0, _waitTime);
    }


    void SpawnRepeater()
    {
        Instantiate(_enemyToSpawn[Random.Range(0, _enemyToSpawn.Length)], new Vector2(spawnPos.x, spawnPos.y), Quaternion.identity);
    }
}