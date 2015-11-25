using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlacementMouse : MonoBehaviour {


    //Int
    [SerializeField]
    private int grid;
    //Int

    //Transforms
    [SerializeField]
    private Transform tower1;

    [SerializeField]
    private Transform turret;
    //Transforms

    [SerializeField]
    private LayerMask isTaken;

    //Vector2
    private Vector2 mousePosition;
    private Vector2 gridPos;
    //Vector2

    //Bool
    public bool building;

    private bool isFree;
    [SerializeField]
    private bool spawnWall = false;
    [SerializeField]
    private bool spawnTurret = false;
    //Bool

    //GameObjects
    private GameObject _TurretPlacement;
    private GameObject _WallPlacement;
    private GameObject _StartBuilding;
    private GameObject _buildWallButton;
    private GameObject _buildTowerButton;
    private GameObject _dropDown;
    private GameObject _scoreController;
    private GameObject _findSpawner;
    //GameObjects

    //Scripts
    private CoinsController _checkCoins;
    private UnitSpawner _checkWaveRunning;
    //Scripts

    void Awake()
    {
        _findSpawner = GameObject.Find("Spawner");
        _scoreController = GameObject.Find("ScoreController");
        _checkCoins = _scoreController.GetComponent<CoinsController>();
        _checkWaveRunning = _findSpawner.GetComponent<UnitSpawner>();
    }


    void Start()
    {

        _StartBuilding = GameObject.Find("BuildButton");
        _StartBuilding.GetComponent<Button>().onClick.AddListener(ChangeBuild);
        _buildWallButton = GameObject.Find("WallButton");
        _buildWallButton.GetComponent<Button>().onClick.AddListener(ChangeWall);
        _buildTowerButton = GameObject.Find("TowerButton");
        _buildTowerButton.GetComponent<Button>().onClick.AddListener(ChangeTower);

        _buildWallButton.SetActive(false);
        _buildTowerButton.SetActive(false);
    }



    void Update()
    {
        CheckMouse();
        PlaceInput();
        HideButtons();

        gridPos = new Vector2(Mathf.Round(mousePosition.x / grid) * grid, Mathf.Round(mousePosition.y / grid) * grid);
        /*if (GUI.Button(Rect,"BuildButton"))
        {
        }*/
    }


    void ChangeTower()
    {
        if (spawnTurret)
        {
            spawnTurret = false;
        }
        else
        {
            spawnTurret = true;
            spawnWall = false;
        }
            
    }
    void ChangeWall()
    {
        if (spawnWall)
        {
            spawnWall = false;
        }
        else
        {
            spawnTurret = false;
            spawnWall = true;
        }
    }
    void ChangeBuild()
    {
        spawnTurret = false;
        spawnWall = false;

        if (building)
        {
            building = false;
        }
        else
         building = true;
        _buildWallButton.SetActive(true);
        _buildTowerButton.SetActive(true);

        if (_checkCoins._coinsValue <= 0)
        {
            building = false;
        }
    }
    void CheckMouse()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
       
        if (building)
        {
            transform.position = gridPos;
        
        }
        else transform.position = new Vector2(-10000, 0);
    }

    void HideButtons()
    {
        if (_checkWaveRunning.waveRunning)
        {
            _buildWallButton.SetActive(false);
            _buildTowerButton.SetActive(false);
        }
        else if (building)
        {
            _buildWallButton.SetActive(true);
            _buildTowerButton.SetActive(true);
        }
    }

    void PlaceInput()
    {
        if (building)
        {
            isFree = !(Physics2D.OverlapCircle(gridPos, (grid / 2), isTaken));
            if (isFree)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    if (spawnWall)
                    {
                        Instantiate(tower1, gridPos, Quaternion.identity);
                        _checkCoins.RemoveCoins();
                    }
                        
                    else if (spawnTurret)
                    {
                        Instantiate(turret, gridPos, Quaternion.identity);
                        _checkCoins.RemoveCoins();
                    }
                        
                }
            }
        }
    }
}