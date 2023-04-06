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
    SpriteRenderer towerSprite;
    [SerializeField] Sprite airTower03;
    [SerializeField] Sprite canon03;

    int value;
    /*public Text towerName;
    public Text towerDamage;
    public Text attackSpeed;*/
    // Start is called before the first frame update
    private void Start()
    {
        towerSprite = GetComponent<SpriteRenderer>();
        errorUpgrade = GameManager.instance.errorUpgrade;
        errorUpgrade.enabled = false;
        towerStatsAttackRange = gameObject.transform.GetChild(0).GetComponent<AttackRange>();
        attackRangeSprite = gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
        value = GetComponent<TowerStats>().cost;
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
        airTower03 = Resources.Load<Sprite>("Tower/magic-3");
        canon03 = Resources.Load<Sprite>("Tower/bunker-2");
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
            if(towerStatsAttackRange.level == 3)
            {
                if(towerStatsAttackRange.theTowerName == "Canon")
                {
                    towerSprite.sprite = canon03;
                }
                else if(towerStatsAttackRange.theTowerName == "AirStrike")
                {
                    towerSprite.sprite = airTower03;
                }
            }
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
