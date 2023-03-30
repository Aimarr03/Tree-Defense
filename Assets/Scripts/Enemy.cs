using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 10;
    public float moveSpeed = 5f;
    public bool alive = true;
    Transform position;
    private Color defaultColor;
    private Color attackedColor;
    private SpriteRenderer enemySprite;
    int damage;

    private void Start()
    {
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
        }
    }
    IEnumerator Damaged()
    {
        enemySprite.color = attackedColor;
        yield return new WaitForSeconds(0.7f);
        enemySprite.color = defaultColor;
    }
}
