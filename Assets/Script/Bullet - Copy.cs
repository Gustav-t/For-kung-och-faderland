using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Bullet : MonoBehaviour
{

    private Collider2D collider;
    void Start()
    {
        collider = GetComponent<Collider2D>();
        float rand = Random.Range(0, 10);
        if (rand >= 9)
        {
            collider.enabled = false;
            StartCoroutine(DestroyAfterDelay(5));
        }
        if (rand <= 3)
        {
            StartCoroutine(DestroyAfterDelay(0));
        }
    }

    IEnumerator DestroyAfterDelay(float delay)
    {
        delay = Random.Range(0.1f, 1f);
        yield return new WaitForSeconds(delay);
        Instantiate(dirtParticles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    void Update()
    {
        
    }
    public ParticleSystem dirtParticles;
    public ParticleSystem bloodParticles;
    public ParticleSystem particles;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            collider.enabled = false;
        }
        if (collision.gameObject.CompareTag("Explosion"))
        {
            collider.enabled = false;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Instantiate(bloodParticles, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else
        {
            Instantiate(particles, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            collider.enabled = true;
        }
        if (collision.gameObject.CompareTag("Explosion"))
        {
            collider.enabled = true;
        }
    }



}
