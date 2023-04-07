using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class UI_Display : MonoBehaviour
{
    public SpriteRenderer attackRangeSprite;
    public AttackRange towerStatsAttackRange;

    string name;
    string damage;
    string attackSpeed;
    string level;

    public Text errorUpgrade;
    public GameObject upgradeAir;
    public GameObject upgradeCanon;

    SpriteRenderer towerSprite;
    public Sprite airTower01;
    public Sprite airTower02;
    public Sprite canon01;
    public Sprite canon02;

    int value;
    bool canUpgrade;
    /*public Text towerName;
    public Text towerDamage;
    public Text attackSpeed;*/
    // Start is called before the first frame update
    private void Start()
    {
        towerSprite = GetComponent<SpriteRenderer>();

        errorUpgrade = GameManager.instance.errorUpgrade;
        upgradeAir = GameManager.instance.upgradeAirTower;
        upgradeCanon = GameManager.instance.upgradeCanon;

        errorUpgrade.enabled = false;
        towerStatsAttackRange = gameObject.transform.GetChild(0).GetComponent<AttackRange>();
        attackRangeSprite = gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
        value = GetComponent<TowerStats>().cost;
        airTower01 = Resources.Load<Sprite>("Tower/magic-1");
        airTower02 = Resources.Load<Sprite>("Tower/magic-3");
        canon01 = Resources.Load<Sprite>("Tower/bunker-2");
        canon02 = Resources.Load<Sprite>("Tower/bunker-3");

    }
    private void Update()
    {
        UpgradingMax();
    }

    void UpgradingMax()
    {
        if (canUpgrade)
        {
            if (towerStatsAttackRange.theTowerName == "Canon")
            {
                upgradeCanon.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    towerSprite.sprite = canon01;
                    upgradeCanon.SetActive(false);
                    canUpgrade = false;
                    towerStatsAttackRange.id = 0;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    towerSprite.sprite = canon02;
                    upgradeCanon.SetActive(false);
                    canUpgrade = false;
                    towerStatsAttackRange.id = 1;
                }
            }
            else if (towerStatsAttackRange.theTowerName == "AirStrike")
            {
                upgradeAir.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    towerSprite.sprite = airTower01;
                    upgradeAir.SetActive(false);
                    canUpgrade = false;
                    towerStatsAttackRange.id = 2;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    towerSprite.sprite = airTower02;
                    upgradeAir.SetActive(false);
                    canUpgrade = false;
                    towerStatsAttackRange.id = 3;
                }
            }
        }
    }
    public void OnMouseOver()
    {
        name = towerStatsAttackRange.theTowerName;
        damage = towerStatsAttackRange.Damage.ToString();
        attackSpeed = towerStatsAttackRange.attackCooldown.ToString();
        level = towerStatsAttackRange.level.ToString();
        GameManager.instance.updateInfo(name, damage, attackSpeed, level);
        GameManager.instance.displayUpgradeOption(name,towerStatsAttackRange.cost);
        GameManager.instance.displayUpgradeOption(name,towerStatsAttackRange.cost);
        
        //Debug.Log("Test");
        attackRangeSprite.enabled = true;
        //towerData.enabled = true;
        if (Input.GetMouseButtonDown(0) && towerStatsAttackRange.level<3)
        {
            if (GameManager.instance.financial.useMoney(towerStatsAttackRange.cost))
            {
                attackRangeSprite.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
                towerStatsAttackRange.Damage += 1;
                towerStatsAttackRange.attackCooldown -= 0.2f;
                towerStatsAttackRange.level++;
                GameManager.instance.displayUpgradeOption(name, towerStatsAttackRange.cost);
                towerStatsAttackRange.cost++;
                value += towerStatsAttackRange.cost;
            }
            if (towerStatsAttackRange.level == 3) canUpgrade = true;
        }
        if(Input.GetMouseButtonDown(0) && towerStatsAttackRange.level >= 3)
        {
            StartCoroutine(displayError());

        }
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Tesst");
            Tilemap groundTile = GameObject.Find("Script").GetComponent<SpawnTower>().towerGround;
            Vector3Int tilePos = GameObject.Find("Script").GetComponent<SpawnTower>().tilePosInfo;
            GameManager.instance.financial.gainMoney((int)(value * 0.75));
            Destroy(gameObject);
            groundTile.SetColliderType(tilePos, Tile.ColliderType.Sprite);
        }
    }
    IEnumerator displayError()
    {
        errorUpgrade.text = "Tower" + towerStatsAttackRange.name+" cannot exceed level 3";
        errorUpgrade.enabled = true;
        yield return new WaitForSeconds(0.6f);
        errorUpgrade.enabled = false;
    }
    public void OnMouseExit()
    {
        //Debug.Log("ExitTest");
        attackRangeSprite.enabled = false;
        //towerData.enabled = false;
    }
}
