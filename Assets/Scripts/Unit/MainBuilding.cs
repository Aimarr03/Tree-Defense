using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBuilding : MonoBehaviour
{
    public int health;
    public Color damagedColor;
    public Color defaultColor;
    private SpriteRenderer spriteRenderer;

    public AudioSource audioPlay;
    public AudioClip damagedClip;
    public void Awake()
    {
        damagedColor = new Color(1, 0, 0);
        defaultColor = new Color(1,1,1);
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioPlay = GetComponent<AudioSource>();
    }

    public void takeDamaged(int damage)
    {
        if (health > 0) { 
            health-=damage;
            audioPlay.PlayOneShot(damagedClip);
            StartCoroutine(colorDamaged());
            GameManager.instance.reduceHp(health);
            //GameManager.instance.HP.text = health.ToString();
        }
        if (health < 0)
        {
            health = 0;
            GameManager.instance.reduceHp(health);
            //GameManager.instance.HP.text = health.ToString();
            Destroy(gameObject);
        }

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "AirEnemy" || collision.tag == "GroundEnemy")
        {
            Debug.Log("Enemy got detected!");
        }
    }
    IEnumerator colorDamaged()
    {
        spriteRenderer.color = damagedColor;
        yield return new WaitForSeconds(0.3f);
        spriteRenderer.color = defaultColor;
    }
}
