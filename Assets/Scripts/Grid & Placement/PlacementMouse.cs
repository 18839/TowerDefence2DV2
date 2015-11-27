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
    
    

    [SerializeField]
    private Transform _wizardTower;

    [SerializeField]
    private Transform _wizardTransform;

    [SerializeField]
    private Transform _cannonObject;
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
    [SerializeField]
    private bool spawnWizard = false;
    [SerializeField]
    private bool spawnCannon = false;
    //Bool

    //GameObjects
    private GameObject _TurretPlacement;
    private GameObject _WallPlacement;
    private GameObject _StartBuilding;
    private GameObject _buildWallButton;
    private GameObject _buildTowerButton;
    private GameObject _buildWizardButton;
    private GameObject _buildCannonButton;
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
        _buildCannonButton = GameObject.Find("CannonButton");
        _buildCannonButton.GetComponent<Button>().onClick.AddListener(ChangeCannon);

        _buildWallButton.SetActive(false);
        _buildTowerButton.SetActive(false);
        _buildWizardButton.SetActive(false);
        _buildCannonButton.SetActive(false);
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
            spawnCannon = false;
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
            spawnCannon = false;
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
            spawnCannon = false;
        }

    }

    void ChangeCannon()
    {
        if (spawnCannon)
        {
            spawnCannon = false;
        }
        else
        {
            spawnCannon = true;
            spawnWall = false;
            spawnTurret = false;
            spawnWizard = false;
        }

    }

    void ChangeBuild()
    {
        spawnTurret = false;
        spawnWall = false;
        spawnWizard = false;
        spawnCannon = false;

        if (building)
        {
            building = false;
        }
        else
         building = true;
        _buildWallButton.SetActive(true);
        _buildTowerButton.SetActive(true);
        _buildWizardButton.SetActive(true);
        _buildCannonButton.SetActive(true);

    }
    void CheckMouse()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        if (_checkWaveRunning.waveRunning == false)
        {
            if (building)
            {
                transform.position = gridPos;

            }
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
            _buildCannonButton.SetActive(false);
        }
        else if (building)
        {
            _buildWallButton.SetActive(true);
            _buildTowerButton.SetActive(true);
            _buildWizardButton.SetActive(true);
            _buildCannonButton.SetActive(true);
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
                    Debug.Log(_checkCoins._coinsValue);
                    if (spawnWall && _checkCoins._coinsValue > 149)
                    {
                        Instantiate(tower1, gridPos, Quaternion.identity);
                        _checkCoins.RemoveCoinsWall();
                    }

                    else if (spawnTurret && _checkCoins._coinsValue >= 249)
                    {
                        Instantiate(_archerTransform, gridPos, Quaternion.identity);
                        Instantiate(turret, gridPos, Quaternion.identity);

                        _checkCoins.RemoveCoinsArch();
                    }

                    else if (spawnWizard && _checkCoins._coinsValue >= 499)
                    {
                        Instantiate(_wizardTransform, gridPos, Quaternion.identity);
                        Instantiate(_wizardTower, gridPos, Quaternion.identity);
                        _checkCoins.RemoveCoinsWiz();
                    }

                    else if (spawnCannon && _checkCoins._coinsValue >= 499)
                    {
                        Instantiate(_cannonObject, gridPos, Quaternion.identity);
                        _checkCoins.RemoveCoinsCan();
                    }

                }
            }
        }
    }
}