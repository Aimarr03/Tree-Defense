using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Econmy financial;
    public MainBuilding building;
    public Timer timer;

    public Text towerName;
    public Text towerDamage;
    public Text towerAttackSpeed;
    public Text towerLevel;


    public Image upgradeButton;
    public Text upgradeCost;
    public Text upgradeLevel;

    public int enemyWave =1;
    public int score;
    public Text waves;
    public Text scoreboard;
    public Text errorUpgrade;

    public Text HP;
    public Text resultBoard;

    public GameObject gameoverPanel;
    public GameObject winPanel;
    public GameObject result;
    public GameObject upgradeCanon;
    public GameObject upgradeAirTower;


    public bool gameStatus;
    public bool win;

    private void Awake()
    {
        financial = GetComponent<Econmy>();
        instance = this;
        building = GameObject.Find("Test01").GetComponent<MainBuilding>();
        timer = GetComponent<Timer>();
        HP.text = building.health.ToString();
        gameStatus = true;
        waves.text = "Wave " + enemyWave.ToString();
        scoreboard.text = "Score " + score.ToString(); 
    }
    
    public void displayUpgradeOption(string name, int cost)
    {
        upgradeLevel.text = "Level : " + name;
        upgradeCost.text = "Cost :"+ cost ;
    }
    public void updateInfo(string name, string damage, string attackSpeed, string level)
    {
        towerName.text ="Tower name: "+ name;
        towerDamage.text ="Tower damage ="+ damage;
        towerLevel.text = "Tower Lvl: "+level;
        towerAttackSpeed.text = "Tower AtckSd ="+attackSpeed;
    }

    public void updateWave()
    {
        enemyWave++;
        waves.text = "Wave " + enemyWave.ToString();
    }
    public void updateScoreBoard(int value)
    {
        score += value;
        scoreboard.text = "Score " + score.ToString();
    }
    public void GameOver()
    {
        gameoverPanel.SetActive(true);
        result.SetActive(true);
        resultBoard.text = "score: " + score + "\t time: " + timer.getTime();
        
    }
    public void Win()
    {
        winPanel.SetActive(true);
        result.SetActive(true);
        resultBoard.text = "score: " + score + "\t time: " + timer.getTime();
    }
    public void RestartGame()
    {
        gameoverPanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void reduceHp(int health)
    {
        if (gameStatus)
        {
            //building.health -= damage;
            HP.text = health.ToString();
        }
        if(building.health <= 0)
        {
            gameStatus = false;
        }
    }
}
