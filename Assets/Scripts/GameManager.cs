using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Econmy financial;
    public MainBuilding building;

    public Text towerName;
    public Text towerDamage;
    public Text towerAttackSpeed;
    public Text towerLevel;


    public Image upgradeButton;
    public Text upgradeCost;
    public Text upgradeLevel;

    public Text HP;
    public GameObject gameoverPanel;

    public bool gameStatus;
    private void Awake()
    {
        financial = GetComponent<Econmy>();
        instance = this;
        building = GameObject.Find("Test01").GetComponent<MainBuilding>();
        HP.text = building.health.ToString();
        gameStatus = true;
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

    
    public void GameOver()
    {
        gameoverPanel.SetActive(true);
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
