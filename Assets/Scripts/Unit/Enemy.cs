using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string name;
    public int health = 10;
    public int damage = 10;
    public int score = 500;
    public float attackSpeed = 0.5f;
    public float moveSpeed = 5f;
    public bool alive = true;
    [SerializeField] private int bounty = 5;

    Transform position;
    private Color defaultColor;
    private Color attackedColor;
    private SpriteRenderer enemySprite;
    private MainBuilding mainBuilding;
    Econmy economy;

    private void Start()
    {
        economy = GameObject.Find("Script").GetComponent<Econmy>();
        enemySprite = GetComponent<SpriteRenderer>();
        defaultColor = GetComponent<SpriteRenderer>().color;
        attackedColor = new Color(1, 0, 0);
    }
    public void takeDamage(int damage)
    {
        if (health > 0)
        {
            StartCoroutine(Damaged());
            health -= damage;
            alive = true;
        }
        else
        {
            Destroy(gameObject);
            alive = false;
            economy.gainMoney(bounty);
            GameManager.instance.updateScoreBoard(score);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collides!");
        if (collision.gameObject.tag == "MainBuilding")
        {
            Debug.Log("MainBuilding Collides");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "MainBuilding" && GameManager.instance.gameStatus)
        {
            Debug.Log("Main Building");
            MainBuilding building = collision.GetComponent<MainBuilding>();
            StartCoroutine(Attacking(building));
        }
    }
    public IEnumerator Attacking(MainBuilding test)
    {
        while (test.health > 0)
        {
            yield return new WaitForSeconds(attackSpeed);
            test.takeDamaged(damage);
        }
    }
    IEnumerator Damaged()
    {
        enemySprite.color = attackedColor;
        yield return new WaitForSeconds(0.7f);
        enemySprite.color = defaultColor;
    }
    public void upgradeEnemy()
    {
        health += 10;
        damage += 4;
        attackSpeed -= 0.04f;
        score += 15;
    }
}
