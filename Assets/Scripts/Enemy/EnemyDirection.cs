using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDirection : MonoBehaviour
{
    private Transform targetRoute;
    private int checkpointIndex;
    private float movespeed;
    void Start()
    {
        movespeed = GetComponent<Enemy>().moveSpeed;
        checkpointIndex = 0;
        targetRoute = EnemyRoute.checkpoints[checkpointIndex];
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetRoute.position, movespeed * Time.deltaTime);
        if (transform.position == targetRoute.position)
        {
            updateCheckPoint();
        }
    }
    void updateCheckPoint()
    {
        if (checkpointIndex == EnemyRoute.checkpoints.Length - 1) return;
        checkpointIndex++;
        targetRoute = EnemyRoute.checkpoints[checkpointIndex];
    }
}
