using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    private float horizontalInput, verticalInput;
    
    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        transform.Translate(Vector2.right * Time.deltaTime * speed*horizontalInput);
        transform.Translate(Vector2.up * Time.deltaTime * speed*verticalInput);
    }

}
