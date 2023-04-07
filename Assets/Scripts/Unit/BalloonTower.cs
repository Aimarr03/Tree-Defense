using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonTower : MonoBehaviour
{
    public bool selected;
    public bool moveState;
    public bool moveNow;
    public float moveSpeed = 5f;
    public Color selectedColor;
    Vector3 targetPos;
    private void Start()
    {
        selectedColor = new Color(0.5f, 0.85f, 0.85f);
    }
    private void Update()
    {
        moveSpeed = 5f;
        if (moveState && selected)
        {
            getPos();
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
            if (moveNow)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
                if (transform.position == targetPos)
                {
                    moveState = false;
                    moveNow = false;
                    selected = false;
                }
            }

        }
    }
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            selected = true;
            moveState = true;
        }
    }
    private void getPos()
    {
        if (Input.GetMouseButtonDown(0))
        {
            targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0,0, 10);
            Debug.Log(targetPos);
            moveNow = true;
        }
        
    }
}
