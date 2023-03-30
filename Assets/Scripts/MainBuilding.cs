using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBuilding : MonoBehaviour
{
    public int health;
    public void takeDamaged(int damage)
    {
        if (health > 0) health--;
        else
        {
            Destroy(gameObject);
        }
    }
}
