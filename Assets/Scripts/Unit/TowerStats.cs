using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerStats : MonoBehaviour
{
    public string towerName;
    public int cost = 5;
    private SpriteRenderer range;

    private void Start()
    {
        range = gameObject.GetComponentInChildren<SpriteRenderer>();
    }
    public void Selected()
    {
        Deselected();
        range.enabled = true;
    }
    public void Deselected()
    {
        range.enabled=false;
    }

}
