using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.Port;

public class GasCloud : MonoBehaviour
{
    public float opacity = 1f;
    private SpriteRenderer spriteRenderer;
    public GasArtillery duration;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyAfterDelay(0));
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
    }
    IEnumerator DestroyAfterDelay(float duration)
    {
        yield return new WaitForSeconds(duration);
        Destroy(gameObject);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        opacity -= 0.01f;
        Color color = spriteRenderer.color;
        color.a = Mathf.Clamp(opacity, 0, 1);
        spriteRenderer.color = color;
    }

   
}
