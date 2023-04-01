using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Text towerName;
    public Text towerDamage;
    public Text towerAttackSpeed;
    public Image towerInfo;
    private void Awake()
    {
        instance = this;
    }

    public void updateInfo(string name, string damage, string attackSpeed)
    {
        towerName.text = name;
        towerDamage.text = damage;
        towerAttackSpeed.text = attackSpeed;
    }
}
