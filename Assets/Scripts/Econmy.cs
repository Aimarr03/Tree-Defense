using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Econmy : MonoBehaviour
{
    public int money = 15;
    public Text moneyDisplay;

    // Start is called before the first frame update
    void Start()
    {
        UpdateUI();
    }
    public void gainMoney(int input)
    {
        money += input;
        UpdateUI();
    }
    public bool useMoney(int input)
    {
        if (checkMoney(input))
        {
            money -= input;
            UpdateUI();
            return true;
        }
        else return false;
    }
    bool checkMoney(int input)
    {
        if (money >= input) return true;
        else return false;
    }
    // Update is called once per frame
    void UpdateUI()
    {
        moneyDisplay.text = money.ToString();
    }
}
