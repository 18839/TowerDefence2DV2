using UnityEngine;
using System.Collections;

[System.Serializable]
public class TowerUpgrade
{
    public float upgradeCost;
    public Sprite newSprite;
    public float newRadius;
    public float newDamage;
    public float newCooldown;
}

public class UpgradeController : MonoBehaviour {

    [SerializeField]
    TowerUpgrade[] upgrades;

    private SpriteRenderer _renderer;
    private int currentUpgrade;
    private int maxAmountOfUpgrades;

    void Awake ()
    {

    }
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
