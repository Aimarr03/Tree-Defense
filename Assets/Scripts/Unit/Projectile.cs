using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Enemy targettedEnemy;
    private float projectileSpeed;
    private AttackRange attackRange;
    private string name;
    public int damage;
    public int id = -1;

    SpriteRenderer projectileRenderer;
    Sprite stun;
    Sprite bottle;
    Sprite sniper;
    private void Start()
    {
        projectileRenderer = GetComponent<SpriteRenderer>();
        stun = Resources.Load<Sprite>("Ammo/stun");
        sniper = Resources.Load<Sprite>("Ammo/sniper");
        bottle = Resources.Load<Sprite>("Ammo/bottle");
    }

    void Update()
    {
        if (id == 0 || id == 1)
        {
            projectileRenderer.sprite = bottle;
        }
        if(id == 2)
        {
            projectileRenderer.sprite = sniper;
        }
        if(id == 3)
        {
            projectileRenderer.sprite = stun;
        }
        Aim();
    }

    public void getData(AttackRange range)
    {
        targettedEnemy = range.Target;
        attackRange = range;
        projectileSpeed = range.ProjectileSpeed;
        damage = range.Damage;
        id = range.id;
        name = range.theTowerName;
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
        if(name== "Canon")
        {
            if (collision.tag == "GroundEnemy" || collision.tag == "HeavyEnemy")
            {
                if(id == 0)
                {
                    StartCoroutine(slowMove(collision.gameObject.GetComponent<EnemyDirection>()));
                }
                collision.gameObject.GetComponent<Enemy>().takeDamage(damage);
                Destroy(gameObject);
            }
        }
        if (name == "AirStrike")
        {
            if(collision.tag == "GroundEnemy"|| collision.tag == "AirEnemy" || collision.tag == "HeavyEnemy")
            {
                if (id == 3)
                {
                    collision.gameObject.GetComponent<Enemy>().moveSpeed *= 0.5f;
                    StartCoroutine(stunAttack(collision.gameObject.GetComponent<Enemy>()));
                }
                collision.gameObject.GetComponent<Enemy>().takeDamage(damage);
                Destroy(gameObject);
            }
        }
    }
    IEnumerator stunAttack(Enemy enemyTarget)
    {
        enemyTarget.canMove = false;
        yield return new WaitForSeconds(0.1f);
        enemyTarget.canMove = true;
    }
    IEnumerator slowMove(EnemyDirection enemyTarget)
    {
        enemyTarget.movespeed *= 0.5f;
        yield return new WaitForSeconds(0.4f);
        enemyTarget.movespeed *= 2;
    }
}
