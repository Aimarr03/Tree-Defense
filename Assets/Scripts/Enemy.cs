using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 10;
    public float moveSpeed = 5f;
    public bool alive = true;
    Transform position;

    public void takeDamage(int damage)
    {
        if (health > 0)
        {
            health -= damage;
            alive = true;
        }
        else
        {
            Destroy(gameObject);
            alive = false;
        }
    }
}
