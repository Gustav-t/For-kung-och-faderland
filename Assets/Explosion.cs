using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    float antal = Random.RandomRange(0,2);
    public GameObject shrapnel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (antal < 5)
        {
            Instantiate(shrapnel, transform.position, Quaternion.identity);
            antal++;
        }
           
    }
}
