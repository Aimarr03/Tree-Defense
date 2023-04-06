using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoute : MonoBehaviour
{
    public static Transform[] checkpoints;
    private void Awake()
    {
        checkpoints = new Transform[transform.childCount];
        for(int counter = 0; counter < checkpoints.Length; counter++)
        {
            checkpoints[counter] = transform.GetChild(counter).GetComponent<Transform>();
        }
    }
}
