using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class HitText : MonoBehaviour
{

    public TextMeshProUGUI textMesh;
    // Start is called before the first frame update
    void Start()
    {
        float rand = Random.Range(-25, 26);
        transform.RotateAround(transform.position, transform.position, rand);
        float colour = Random.Range(1, 3);
        if (colour == 1)
        {
            textMesh.color = Color.yellow;
        }
        if (colour == 2)
        {
            textMesh.color = Color.red;
        }


        StartCoroutine(ShootAfterDelay(1.2f));
    }

    IEnumerator ShootAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
