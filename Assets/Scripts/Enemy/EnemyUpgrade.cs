using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUpgrade : MonoBehaviour
{
    public static EnemyUpgrade upgradeFunction; 
    public int upgradeAirHP = 0;
    public int upgradeAirDamage = 0;
    public float upgradeAirMovementSpeed = 0;
    public int upgradeAirScore = 0;
    //Space
    public int upgradeGroundHP = 0;
    public int upgradeGroundDamage = 0;
    public float upgradeGroundAttackSpeed = 0;
    public float upgradeGroundMovementSpeed = 0;
    public int upgradeGroundScore = 0;
    //Space
    public int upgradeHeavyHP = 0;
    public int upgradeHeavyDamage = 0;
    public int upgradeHeavyScore = 0;

    private void Start()
    {
        upgradeFunction = this;
    }
    public void Upgraded()
    {
         upgradeAirHP  += 5;
        upgradeAirMovementSpeed += 0.15f;
        upgradeAirScore += 2;
        //Space
        upgradeGroundHP += 6;
        upgradeGroundDamage += 2;
        upgradeGroundAttackSpeed -= 0.03f;
        upgradeGroundMovementSpeed += 0.1f;
        upgradeGroundScore += 1;
    //Space
        upgradeHeavyHP += 10;
        upgradeHeavyDamage += 1;
        upgradeHeavyScore += 7;
    }
}
