using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public static EnemySpawn spawning;
    public List<GameObject> Enemy;
    public Transform spawnPoint;
    public float intervalSpawn;

    private void Start()
    {
        spawning = this;
        InvokeRepeating("SpawnUnit", 1, intervalSpawn);
    }
    void SpawnUnit()
    {
        if (!GameManager.instance.gameStatus) return;
        int index = Random.Range(0, Enemy.Count);
        GameObject enemySpawned = Instantiate(Enemy[index], spawnPoint);
        Enemy enemyStat = enemySpawned.GetComponent<Enemy>();
        Debug.Log(enemyStat==null);
        enemySpawned.transform.position = transform.position;
        if(enemySpawned.tag == "GroundEnemy")
        {
            enemyStat.health += EnemyUpgrade.upgradeFunction.upgradeGroundDamage;
            enemyStat.damage += EnemyUpgrade.upgradeFunction.upgradeGroundDamage;
            enemyStat.attackSpeed += EnemyUpgrade.upgradeFunction.upgradeGroundAttackSpeed;
            enemyStat.moveSpeed += EnemyUpgrade.upgradeFunction.upgradeGroundMovementSpeed;
            enemyStat.score += EnemyUpgrade.upgradeFunction.upgradeGroundScore;
        }
        if(enemySpawned.tag == "AirEnemy")
        {
            enemyStat.health += EnemyUpgrade.upgradeFunction.upgradeAirHP;
            enemyStat.damage += EnemyUpgrade.upgradeFunction.upgradeAirDamage;
            enemyStat.moveSpeed += EnemyUpgrade.upgradeFunction.upgradeAirMovementSpeed;
            enemyStat.score += EnemyUpgrade.upgradeFunction.upgradeAirScore;
        }
        if(enemySpawned.tag == "HeavyEnemy")
        {
            enemyStat.health += EnemyUpgrade.upgradeFunction.upgradeHeavyHP;
            enemyStat.damage += EnemyUpgrade.upgradeFunction.upgradeHeavyDamage;
            enemyStat.score += EnemyUpgrade.upgradeFunction.upgradeHeavyScore;
        }
    }
}
