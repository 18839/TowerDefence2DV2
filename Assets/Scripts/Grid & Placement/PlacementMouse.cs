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

    [SerializeField]
    private Transform _archerTransform;
    //Transforms

    [SerializeField]
    private Transform _wizardTower;

    [SerializeField]
    private Transform _wizardTransform;

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
    [SerializeField]
    private bool spawnWizard = false;
    //Bool

    //GameObjects
    private GameObject _TurretPlacement;
    private GameObject _WallPlacement;
    private GameObject _StartBuilding;
    private GameObject _buildWallButton;
    private GameObject _buildTowerButton;
    private GameObject _buildWizardButton;
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
        _buildWizardButton = GameObject.Find("WizardButton");
        _buildWizardButton.GetComponent<Button>().onClick.AddListener(ChangeWizard);

        _buildWallButton.SetActive(false);
        _buildTowerButton.SetActive(false);
        _buildWizardButton.SetActive(false);
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
            spawnWizard = false;
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
            spawnWizard = false;
            spawnWall = true;
        }
    }

    void ChangeWizard()
    {
        if (spawnWizard)
        {
            spawnWizard = false;
        }
        else
        {
            spawnWizard = true;
            spawnWall = false;
            spawnTurret = false;
        }

    }


    void ChangeBuild()
    {
        spawnTurret = false;
        spawnWall = false;
        spawnWizard = false;

        if (building)
        {
            building = false;
        }
        else
         building = true;
        _buildWallButton.SetActive(true);
        _buildTowerButton.SetActive(true);
        _buildWizardButton.SetActive(true);

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
            _buildWizardButton.SetActive(false);
        }
        else if (building)
        {
            _buildWallButton.SetActive(true);
            _buildTowerButton.SetActive(true);
            _buildWizardButton.SetActive(true);
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
                        Instantiate(_archerTransform, gridPos, Quaternion.identity);
                        Instantiate(turret, gridPos, Quaternion.identity);
                       
                        _checkCoins.RemoveCoins();
                    }

                    else if (spawnWizard)
                    {
                        Instantiate(_wizardTransform, gridPos, Quaternion.identity);
                        Instantiate(_wizardTower, gridPos, Quaternion.identity);
                    }
                        
                }
            }
        }
    }
}