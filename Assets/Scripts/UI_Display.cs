using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UI_Display : MonoBehaviour
{
    public SpriteRenderer attackRangeSprite;
    public AttackRange towerStats;
    string name;
    string damage;
    string attackSpeed;
    string level;
    /*public Text towerName;
    public Text towerDamage;
    public Text attackSpeed;*/
    // Start is called before the first frame update
    private void Start()
    {
        towerStats = gameObject.transform.GetChild(0).GetComponent<AttackRange>();
        attackRangeSprite = gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    public void OnMouseOver()
    {
        name = towerStats.theTowerName;
        damage = towerStats.Damage.ToString();
        attackSpeed = towerStats.attackCooldown.ToString();
        level = towerStats.level.ToString();
        GameManager.instance.updateInfo(name, damage, attackSpeed, level);
        GameManager.instance.displayUpgradeOption(name,towerStats.cost);
        GameManager.instance.displayUpgradeOption(name,towerStats.cost);
        //Debug.Log("Test");
        attackRangeSprite.enabled = true;
        //towerData.enabled = true;
    }
    public void OnMouseDown()
    {
        if (GameManager.instance.financial.useMoney(towerStats.cost))
        {
            attackRangeSprite.transform.localScale += new Vector3(0.5f,0.5f,0.5f);
            towerStats.Damage += 1;
            towerStats.attackCooldown -= 0.2f;
            GameManager.instance.displayUpgradeOption(name,towerStats.cost);
            towerStats.cost++;
        }
    }
    public void OnMouseExit()
    {
        //Debug.Log("ExitTest");
        attackRangeSprite.enabled = false;
        //towerData.enabled = false;
    }
}
