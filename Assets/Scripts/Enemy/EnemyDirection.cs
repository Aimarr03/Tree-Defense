using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDirection : MonoBehaviour
{
    private Transform targetRoute;
    private Enemy currentStat;
    private int checkpointIndex;
    public float movespeed;
    void Start()
    {
        currentStat = GetComponent<Enemy>();
        movespeed = GetComponent<Enemy>().moveSpeed;
        checkpointIndex = 0;
        targetRoute = EnemyRoute.checkpoints[checkpointIndex];
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(canMove());
        if(currentStat.canMove) transform.position = Vector3.MoveTowards(transform.position, targetRoute.position, movespeed * Time.deltaTime);
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
    IEnumerator canMove()
    {
        if (!currentStat.canMove)
        {
            yield return new WaitForSeconds(0.15f);
            currentStat.canMove = true;
        }
    }
}
