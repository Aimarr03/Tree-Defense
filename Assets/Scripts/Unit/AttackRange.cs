using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackRange : MonoBehaviour
{
    [SerializeField]private int damage = 10;
    [SerializeField]private float projectileSpeed = 10f;
    public string theTowerName;

    bool canAttack = false;
    private float attackTimer;
    public float attackCooldown = 1f;
    public int level = 1;
    public int cost = 2;
    
    private Enemy target;
    private Queue<Enemy> enemies = new Queue<Enemy>();
    public GameObject ammo;

    public float ProjectileSpeed
    {
        get { return projectileSpeed; }
        set { projectileSpeed = value; }
    }
    public Enemy Target
    {
        get { return target; }
    }
    public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }

    private void Start()
    {

    }
    public void Update()
    {
        Attack();    
    }

    void Attack()
    {
        if (!canAttack)
        {
            attackTimer += Time.deltaTime;
            if(attackTimer >= attackCooldown)
            {
                Debug.Log("Ammo loaded");
                canAttack = true;
                attackTimer = 0;
            }
        }
        if (target == null && enemies.Count > 0)
        {
            Debug.Log(enemies.Count);
            Debug.Log("Target got the value");
            target = enemies.Dequeue();
            Debug.Log(enemies.Count);
            Debug.Log(target.IsUnityNull());
            Debug.Log(target);
        }
        if(target != null && target.alive)
        {
            Debug.Log("Target is aimed");
            if (canAttack)
            {
                Debug.Log("Shooting!"); ; 
                Shoot();

                canAttack = false;
            }
        }
    }
    void Shoot()
    {
        GameObject projectile = Instantiate(ammo);
        Projectile aim = projectile.GetComponent<Projectile>();
        aim.getData(this);
        projectile.transform.position = transform.position;
        Projectile projectileScript = projectile.GetComponent<Projectile>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(theTowerName == "Test04");
        if (theTowerName == "Test02")
        {
            if (collision.tag == "GroundEnemy")
            {
                Debug.Log("Enemy enter test02 territory");
                enemies.Enqueue(collision.GetComponent<Enemy>());
            }
        }
        else if (theTowerName == "Test04")
        {
            if (collision.tag == "GroundEnemy" || collision.tag == "AirEnemy")
            {
                Debug.Log("Enemy enter test04 territory");
                enemies.Enqueue(collision.GetComponent<Enemy>());
                
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GroundEnemy" || collision.gameObject.tag == "AirEnemy")
        {
            Debug.Log("Enemy exit tower territory");
            target = null;
        }
    }
}
