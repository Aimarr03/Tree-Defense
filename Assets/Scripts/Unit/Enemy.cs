using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 10;
    public float moveSpeed = 5f;
    public bool alive = true;
    [SerializeField] private int bounty = 5;

    Transform position;
    private Color defaultColor;
    private Color attackedColor;
    private SpriteRenderer enemySprite;
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
        }
    }
    IEnumerator Damaged()
    {
        enemySprite.color = attackedColor;
        yield return new WaitForSeconds(0.7f);
        enemySprite.color = defaultColor;
    }
}
