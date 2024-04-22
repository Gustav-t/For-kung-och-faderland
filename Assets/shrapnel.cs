using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shrapnel : MonoBehaviour
{

    public float speed = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D ridgidbody2D = GetComponent<Rigidbody2D>();
        float randomAngle = Random.Range(-50f, 50f);
        Quaternion randomRotation = Quaternion.Euler(0, 0, randomAngle);

        transform.rotation = transform.rotation * randomRotation;

        Vector2 direction = transform.right;

        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
