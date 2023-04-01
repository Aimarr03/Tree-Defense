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
        name = towerStats.name;
        damage = towerStats.Damage.ToString();
        attackSpeed = towerStats.attackCooldown.ToString();
        GameManager.instance.updateInfo(name, damage, attackSpeed);
        //Debug.Log("Test");
        attackRangeSprite.enabled = true;
        //towerData.enabled = true;
    }
    public void OnMouseDown()
    {
        attackRangeSprite.transform.localScale += new Vector3(0.5f,0.5f,0.5f);
        towerStats.Damage += 1;
        towerStats.attackCooldown -= 0.2f;
    }
    public void OnMouseExit()
    {
        //Debug.Log("ExitTest");
        attackRangeSprite.enabled = false;
        //towerData.enabled = false;
    }
}
