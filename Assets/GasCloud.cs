using System.Collections;
using UnityEngine;

public class GasCloud : MonoBehaviour
{
    private float fadeTime;  

    public void SetFadeTime(float time)
    {
        fadeTime = time; 
    }

    void Start()
    {
        StartCoroutine(DestroyAfterDelay(fadeTime));  
    }

    IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        
    }
}