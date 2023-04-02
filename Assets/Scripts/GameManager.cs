using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Econmy financial;
    
    public Text towerName;
    public Text towerDamage;
    public Text towerAttackSpeed;
    public Text towerLevel;


    public Image upgradeButton;
    public Text upgradeCost;
    public Text upgradeLevel;
    private void Awake()
    {
        financial = GetComponent<Econmy>();
        instance = this;
    }

    public void displayUpgradeOption(string name, int cost)
    {
        upgradeLevel.text = "Level : " + name;
        upgradeCost.text = "Cost :"+ cost ;
    }
    public void updateInfo(string name, string damage, string attackSpeed, string level)
    {
        towerName.text ="Tower name: "+ name;
        towerDamage.text ="Tower damage ="+ damage;
        towerLevel.text = "Tower Lvl: "+level;
        towerAttackSpeed.text = "Tower AtckSd ="+attackSpeed;
    }
}
