using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Enemy targettedEnemy;
    private float projectileSpeed;
    private AttackRange attackRange;
    public int damage;
    public int id = -1;
    void Update()
    {
        Aim();
    }

    public void getData(AttackRange range)
    {
        targettedEnemy = range.Target;
        attackRange = range;
        projectileSpeed = range.ProjectileSpeed;
        damage = range.Damage;
        id = range.id;
    }
    void Aim()
    {
        if (targettedEnemy != null && targettedEnemy.alive)
        {
            transform.position = Vector3.MoveTowards(transform.position, targettedEnemy.transform.position, projectileSpeed*Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "GroundEnemy"|| collision.tag == "AirEnemy" || collision.tag == "HeavyEnemy")
        {
            if (id == 3)
            {
                StartCoroutine(stunAttack(collision.gameObject.GetComponent<Enemy>()));
            }
            collision.gameObject.GetComponent<Enemy>().takeDamage(damage);
            Destroy(gameObject);
        }
    }
    IEnumerator stunAttack(Enemy enemyTarget)
    {
        enemyTarget.canMove = false;
        yield return new WaitForSeconds(0.1f);
        enemyTarget.canMove = true;
    }
}
