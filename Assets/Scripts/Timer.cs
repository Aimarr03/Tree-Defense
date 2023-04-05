using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public string dataTime;
    private float startTime;
    private int breakPoint;
    private int intervalTime;
    private Enemy enemy;

    private string minute;
    private string second;

    bool statusUpdate = true;
    void Start()
    {
        startTime = Time.time;
        intervalTime = 20;
        enemy = GameObject.FindGameObjectWithTag("AirEnemy").GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.gameStatus) return;

        float t = Time.time - startTime;
        breakPoint = (int)t;
        StartCoroutine(waveDetection(t));
        minute = ((int)t / 60).ToString();
        second = (t%60).ToString("f2");
        dataTime = minute + ":" + second;
        timerText.text= minute+":"+second;
    }
    IEnumerator waveDetection(float time)
    {
        if (breakPoint % intervalTime == 0 && statusUpdate && time > 1)
        {
            statusUpdate = false;
            enemy.upgradeEnemy();
            GameManager.instance.updateWave();
            yield return new WaitForSeconds(1f);
            statusUpdate = true;
        }
    }
    public string getTime()
    {
        return minute + ":" + second;
    }
}
