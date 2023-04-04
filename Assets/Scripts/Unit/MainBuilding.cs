using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBuilding : MonoBehaviour
{
    public int health;
    public void takeDamaged(int damage)
    {
        if (health > 0) { 
            health-=damage;
            GameManager.instance.reduceHp(health);
            //GameManager.instance.HP.text = health.ToString();
        }
        if (health < 0)
        {
            health = 0;
            GameManager.instance.reduceHp(health);
            //GameManager.instance.HP.text = health.ToString();
            Destroy(gameObject);
        }

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="AirEnemy" || collision.tag == "GroundEnemy")
        {
            Debug.Log("Enemy got detected!");
        }    
    }
}
