using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.ShaderKeywordFilter;

public class Enemy : MonoBehaviour
{
    public GameObject enemySpawn;
    public float health = 100;
    void FixedUpdate()
    {  
            if (health <= 0)
            {
                Destroy(gameObject);
            }
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb.velocity.x <= -6f)
            {
                rb.velocity = new Vector2(0, 0);
                rb.AddForce(new Vector3(-6, 0, 0));
            }
    }
    public Canvas canvas;

    public float minSpeed = -20f;
    public float maxSpeed = -35f;
    void Start()
    {
        float enemySpeed = Random.Range(minSpeed, maxSpeed); 
        Rigidbody2D enemyRb = GetComponent<Rigidbody2D>();
        enemyRb.AddForce(new Vector2(enemySpeed, 0));
        canvas = FindObjectOfType<Canvas>(); 
        float rand = Random.Range(-4.5f, 4.5f);
        transform.position += new Vector3(0, rand, 0);
    }

    // Update is called once per frame

    void headshot()
    {
        float headDamage = Random.Range(0.8f, 0.9f);
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 velocity = rb.velocity;
        rb.velocity = velocity * headDamage;
        float damage = Random.Range(60, 200);
        health -= damage;
        Debug.Log("Speed = " + rb.velocity);
    }
    void chestHit()
    {
        float chestDamage = Random.Range(0.7f, 0.8f);
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 velocity = rb.velocity;
        rb.velocity = velocity * chestDamage;
        float damage = Random.Range(30, 60);
        health -= damage;
        Debug.Log("Speed = " + rb.velocity);
    }
    void legHit()
    {
        float legDamage = Random.Range(0.3f, 0.7f);
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 velocity = rb.velocity;
        rb.velocity = velocity * legDamage;
        float damage = Random.Range(15, 30);
        health -= damage;
        Debug.Log("Speed = " + rb.velocity);
    }
    //Explosion
    void ExplosionHeadshot()
    {
        float headDamage = Random.Range(0.7f, 0.9f);
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 velocity = rb.velocity;
        rb.velocity = velocity * headDamage;
        float damage = Random.Range(20, 120);
        health -= damage;
    }
    void ExplosionChestHit()
    {
        float chestDamage = Random.Range(0.6f, 0.9f);
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 velocity = rb.velocity;
        rb.velocity = velocity * chestDamage;
        float damage = Random.Range(30, 60);
        health -= damage;
    }
    void ExplosionLegHit()
    {
        float legDamage = Random.Range(0.25f, 0.5f);
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 velocity = rb.velocity;
        rb.velocity = velocity * legDamage; 
        float damage = Random.Range(15, 50);
        health -= damage;
    }

    void bleeding()
    {
    }


    public TextMeshProUGUI legHitText;
    public TextMeshProUGUI chestHitText;
    public TextMeshProUGUI headHitText;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trench"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Explosion"))
        {
            float rand = Random.Range(1, 6);
            if (rand == 1)
            {
                TextMeshProUGUI newText = Instantiate(headHitText, transform.position * 100, Quaternion.identity);
                newText.text = "Face mauled!";
                newText.transform.SetParent(canvas.transform, false);
                ExplosionHeadshot();
            }
            if (rand == 2)
            {
                TextMeshProUGUI newText = Instantiate(legHitText, transform.position * 100, Quaternion.identity);
                newText.text = "Chest slashed!";
                newText.transform.SetParent(canvas.transform, false);
                ExplosionChestHit();
            }
            else
            {
                TextMeshProUGUI newText = Instantiate(chestHitText, transform.position * 100, Quaternion.identity);
                newText.text = "Leg blown up!";
                newText.transform.SetParent(canvas.transform, false);
                ExplosionLegHit();
            }

        }

        if (collision.gameObject.CompareTag("Bullet"))
        {
            float rand = Random.Range(1, 4);
            if (rand == 1)
            {
                TextMeshProUGUI newText = Instantiate(headHitText, transform.position * 100, Quaternion.identity);
                newText.text = "Headshot!";
                newText.transform.SetParent(canvas.transform, false);
                headshot();
            }
            if (rand == 2)
            {
                TextMeshProUGUI newText = Instantiate(chestHitText, transform.position * 100, Quaternion.identity);
                newText.text = "Chest hit!";
                newText.transform.SetParent(canvas.transform, false);
                chestHit();
            }
            if (rand == 3)
            {
                TextMeshProUGUI newText = Instantiate(legHitText, transform.position * 100, Quaternion.identity);
                newText.text = "Leg hit!";
                newText.transform.SetParent(canvas.transform, false);
                legHit();
            }
        }
    }
}
