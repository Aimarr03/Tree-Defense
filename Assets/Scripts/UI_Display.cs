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

    int value;
    /*public Text towerName;
    public Text towerDamage;
    public Text attackSpeed;*/
    // Start is called before the first frame update
    private void Start()
    {
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
        //Debug.Log("Test");
        attackRangeSprite.enabled = true;
        //towerData.enabled = true;
        if (Input.GetMouseButtonDown(0))
        {
            if (GameManager.instance.financial.useMoney(towerStatsAttackRange.cost))
            {
                attackRangeSprite.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
                towerStatsAttackRange.Damage += 1;
                towerStatsAttackRange.attackCooldown -= 0.2f;
                GameManager.instance.displayUpgradeOption(name, towerStatsAttackRange.cost);
                towerStatsAttackRange.cost++;
                value += towerStatsAttackRange.cost;
            }
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
    public void OnMouseDown()
    {
        
        
    }
    public void OnMouseExit()
    {
        //Debug.Log("ExitTest");
        attackRangeSprite.enabled = false;
        //towerData.enabled = false;
    }
}
