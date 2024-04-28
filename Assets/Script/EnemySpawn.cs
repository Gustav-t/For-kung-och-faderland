using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject Enemy;
    public Transform spawnPoint;

    void Start()
    {
        
    }


    bool spawnHasHappend = false;
    float tid = 10;
    void FixedUpdate()
    {
        if (spawnHasHappend == false)
        {
            spawnHasHappend = true;
            Spawn();
            tid -= 0.2f;
        }
    }

    


   
    void Spawn()
    {
        
        Instantiate(Enemy, spawnPoint.position, Quaternion.identity);
        StartCoroutine(Timer());
    }


    IEnumerator Timer()
    {
        yield return new WaitForSeconds(tid);
        spawnHasHappend = false;
    }
}
