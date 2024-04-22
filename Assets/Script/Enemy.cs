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

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
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

    void bleeding()
    {
    }


    float headDamage = 0;
    float chestDamage = 0;
    float legDAmage = 0;

    public TextMeshProUGUI legHitText;
    public TextMeshProUGUI chestHitText;
    public TextMeshProUGUI headHitText;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            float rand = Random.Range(1, 4);
            if (rand == 1)
            {
                bleeding();
                TextMeshProUGUI newText = Instantiate(headHitText, transform.position * 100, Quaternion.identity);
                newText.text = "Headshot!";
                newText.transform.SetParent(canvas.transform, false);
                headshot();
            }
            if (rand == 2)
            {
                bleeding();
                TextMeshProUGUI newText = Instantiate(chestHitText, transform.position * 100, Quaternion.identity);
                newText.text = "Chest hit!";
                newText.transform.SetParent(canvas.transform, false);
                chestHit();
            }
            if (rand == 3)
            {
                bleeding();
                TextMeshProUGUI newText = Instantiate(legHitText, transform.position * 100, Quaternion.identity);
                newText.text = "Leg hit!";
                newText.transform.SetParent(canvas.transform, false);
                legHit();
            }
        }
    }
}
