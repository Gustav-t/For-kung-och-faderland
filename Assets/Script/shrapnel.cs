using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shrapnel : MonoBehaviour
{
    public GameObject dirtParticles;
    void Start()
    {
        Spawn();

        Collider2D collider = GetComponent<Collider2D>();
        float rand = Random.Range(0, 10);
        if (rand == 10)
        {
            collider.enabled = false;
            StartCoroutine(DestroyAfterDelay(5));
        }
        else
        {
            StartCoroutine(DestroyAfterDelay(0));
        }

    }

    void Spawn()
    {
        float speed = Random.Range(2f, 5f);

        Rigidbody2D ridgidbody2D = GetComponent<Rigidbody2D>();
        float randomAngle = Random.Range(0f, 360f);
        Quaternion randomRotation = Quaternion.Euler(0, 0, randomAngle);

        transform.rotation = randomRotation;

        Vector2 direction = transform.right;

        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }
    IEnumerator DestroyAfterDelay(float delay)
    {
        delay = Random.Range(0.1f, 1.1f);
        yield return new WaitForSeconds(delay);
        Instantiate(dirtParticles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public ParticleSystem bloodParticles;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D collider = GetComponent<Collider2D>();

        if (collision.gameObject.CompareTag("Bullet"))
        {
            collider.enabled = false;
            Debug.Log("bullet collider off");
        }
        if (collision.gameObject.CompareTag("Explosion"))
        {
            collider.enabled = false;
            Debug.Log("Explosion collider off");
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Instantiate(bloodParticles, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
       

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        Collider2D collider = GetComponent<Collider2D>();

        if (collision.gameObject.CompareTag("Bullet"))
        {
            collider.enabled = true;
            Debug.Log("bullet collider on");
        }
        if (collision.gameObject.CompareTag("Explosion"))
        {
            collider.enabled = true;
            Debug.Log("Explosin collider on");
        }
    }

    void Update()
    {
        
    }
}
