using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UnitSpawner : MonoBehaviour {

    //Transforms
    [SerializeField]
    private GameObject[] _enemyToSpawn;
    [SerializeField]
    private GameObject _bossTransform;
    //Transforms

    //Int
    private int timerSeconds = 10;
    //Int

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
        InvokeRepeating("SpawnRepeater", 0, _waitTime);
       
	}

    void InvokeEnemies()
    {
        SpawnBoss();
        StartCoroutine("SpawnTimer");
        _waveScript.AddWave();
        spawnPos = transform.position;
       
    }

    void SpawnRepeater()
    {
        if (waveRunning)
        Instantiate(_enemyToSpawn[Random.Range(0, _enemyToSpawn.Length)], new Vector2(spawnPos.x, spawnPos.y), Quaternion.identity);
    }

    void SpawnBoss()
    {
        if (waveRunning)
        Instantiate(_bossTransform, new Vector2(spawnPos.x, spawnPos.y), Quaternion.identity);
    }

    IEnumerator SpawnTimer()
    {
        waveRunning = true;
        yield return new WaitForSeconds(timerSeconds);
        waveRunning = false;
    }



   
}