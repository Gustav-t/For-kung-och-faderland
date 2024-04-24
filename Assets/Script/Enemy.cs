using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.ShaderKeywordFilter;

public class Enemy : MonoBehaviour
{
    public float health = 100;
    void FixedUpdate()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb.velocity.x <= -1f) 
        {
            rb.AddForce(new Vector2(-3, 0));
        }

    }
    public Canvas canvas;
    void Start()
    {
        canvas = FindObjectOfType<Canvas>(); 
        float rand = Random.Range(-5, 6);
        transform.position += new Vector3(0, rand, 0);
    }

    // Update is called once per frame

    void headshot()
    {
        float headDamage = Random.Range(0.05f, 1f);
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(headDamage, 0));
        float damage = Random.Range(20, 200);
        health -= damage;
        Debug.Log("Headshot! Enemy health = " + health);
    }
    void chestHit()
    {
        float chestDamage = Random.Range(0.05f, 0.5f);
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(chestDamage, 0));
        float damage = Random.Range(30, 60);
        health -= damage;
        Debug.Log("Chest hit, Enemy health = " + health);
    }
    void legHit()
    {
        float legDamage = Random.Range(0.5f, 3f);
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(legDamage, 0));
        float damage = Random.Range(15, 30);
        health -= damage;
        Debug.Log("Leg hit, Enemy health = " + health);
    }
    //Explosion
    void ExplosionHeadshot()
    {
        float headDamage = Random.Range(2f, 4f);
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(headDamage, 0));
        float damage = Random.Range(10, 100);
        health -= damage;
        Debug.Log("Headshot! Enemy health = " + health);
    }
    void ExplosionChestHit()
    {
        float chestDamage = Random.Range(1f, 2f);
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(chestDamage, 0));
        float damage = Random.Range(30, 40);
        health -= damage;
        Debug.Log("Chest hit, Enemy health = " + health);
    }
    void ExplosionLegHit()
    {
        float legDamage = Random.Range(2f, 5f);
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(legDamage, 0));
        float damage = Random.Range(15, 50);
        health -= damage;
        Debug.Log("Leg hit, Enemy health = " + health);
    }

    void bleeding()
    {
    }


    public TextMeshProUGUI legHitText;
    public TextMeshProUGUI chestHitText;
    public TextMeshProUGUI headHitText;

    private void OnCollisionEnter2D(Collision2D collision)
    {
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
