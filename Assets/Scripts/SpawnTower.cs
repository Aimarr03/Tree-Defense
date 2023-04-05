using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class SpawnTower : MonoBehaviour
{
    public List<GameObject> towerPrefabs;
    public List<Image> towerSelections;
    private List<GameObject> instantiatedTower;

    Econmy economy;
    public int idTower = -1;
    Color unselectedColor = new Color(0.2f, 0.4f, 0.2f);
    public Tilemap towerGround;
    public Transform containment;
    public Vector3Int tilePosInfo;

    public bool buildNow;
    // Start is called before the first frame update
    void Start()
    {
        economy = GameObject.Find("Script").GetComponent<Econmy>();
        idTower = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (checkID())
        {
            getPos();
        }
        if(GameManager.instance.score >= 500)
        {
            GameManager.instance.gameStatus = false;
            GameManager.instance.win = true;
        }
        if (!GameManager.instance.gameStatus)
        {
            if (!GameManager.instance.win) GameManager.instance.GameOver();
            else GameManager.instance.Win();
        }
    }
    void getPos()
    {
        if (Input.GetMouseButton(0) && GameManager.instance.gameStatus && buildNow)
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var tilePos = towerGround.WorldToCell(mousePos);
            tilePosInfo = tilePos;
            Debug.Log(tilePos);
            var centerPos = towerGround.GetCellCenterWorld(tilePos);
            var modifiedPos = centerPos;
            Debug.Log("Before: " + towerGround.GetColliderType(tilePos));
            if (towerGround.GetColliderType(tilePos) == Tile.ColliderType.Sprite)
            {
                int cost = getCost();
                if (GetComponent<Econmy>().useMoney(cost))
                {
                    towerSpawning(modifiedPos);
                    towerGround.SetColliderType(tilePos, Tile.ColliderType.None);
                    Debug.Log("After: " + towerGround.GetColliderType(tilePos));
                }
            }
            else
            {
                Debug.Log("Already Built!");
            }
        }
    }
    

    int getCost()
    {
        int cost = towerPrefabs[idTower].GetComponent<TowerStats>().cost;
        return cost;
    }
    void towerSpawning(Vector3 position)
    {
        GameObject tower = Instantiate(towerPrefabs[idTower], containment);
        tower.transform.position = position;
        deselectID();
        buildNow = false;
    }
    public bool checkID()
    {
        if (idTower != -1) return true;
        else return false;
    }
    public void canBuild()
    {
        buildNow = true;
    }
    public void setID(int input)
    {
        if (GameManager.instance.gameStatus)
        {
            deselectID();
            idTower = input;
            Debug.Log("ID set to: " + idTower);
            towerSelections[idTower].color = new Color(1, 1, 1);

        }
    }
    public void deselectID()
    {
        idTower = -1;
        for(int counter = 0; counter<towerSelections.Count; counter++)
        {
            towerSelections[counter].color = unselectedColor;
        }
        buildNow = false;
    }
}
