using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionRadius : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyAfterDelay(0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator DestroyAfterDelay(float delay)
    {
        delay = (0.1f);
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
