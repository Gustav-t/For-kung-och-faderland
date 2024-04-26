using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject shrapnel;
    public GameObject explosionRadius;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(explosionRadius, transform.position, Quaternion.identity);
        StartCoroutine(SpawnAfterDelay(0));
        StartCoroutine(DestroyAfterDelay(0));
    }
    IEnumerator SpawnAfterDelay(float delay)
    {
        delay = (0.2f);
        yield return new WaitForSeconds(delay);
        Instantiate(shrapnel, transform.position, Quaternion.identity);
        delay = (0.1f);
        yield return new WaitForSeconds(delay);
        Instantiate(shrapnel, transform.position, Quaternion.identity);
        delay = (0.1f);
        yield return new WaitForSeconds(delay);
        Instantiate(shrapnel, transform.position, Quaternion.identity);
        delay = (0.1f);
        yield return new WaitForSeconds(delay);
        Instantiate(shrapnel, transform.position, Quaternion.identity);
    }
    IEnumerator DestroyAfterDelay(float delay)
    {
        delay = (0.5f);
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
  
    }
}
