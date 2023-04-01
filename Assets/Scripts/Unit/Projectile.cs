using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Enemy targettedEnemy;
    private float projectileSpeed;
    private AttackRange attackRange;
    public int damage;

    void Update()
    {
        Aim();
    }

    public void getData(AttackRange range)
    {
        this.targettedEnemy = range.Target;
        this.attackRange = range;
        this.projectileSpeed = range.ProjectileSpeed;
        this.damage = range.Damage;
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
        if(collision.tag == "GroundEnemy"|| collision.tag == "AirEnemy")
        {
            collision.gameObject.GetComponent<Enemy>().takeDamage(damage);
            Destroy(gameObject);
        }
    }
}
