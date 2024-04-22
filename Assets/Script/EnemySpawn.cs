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

    


    public float minSpeed = 20f;
    public float maxSpeed = 35f;
    void Spawn()
    {
        float enemySpeed = Random.Range(minSpeed, maxSpeed);
        GameObject newEnemy = Instantiate(Enemy, spawnPoint.position, Quaternion.identity);
        Rigidbody2D enemyRb = newEnemy.GetComponent<Rigidbody2D>();
        enemyRb.AddForce(new Vector2(enemySpeed * -1, 0));
        StartCoroutine(Timer());
    }


    IEnumerator Timer()
    {
        yield return new WaitForSeconds(tid);
        spawnHasHappend = false;
    }
}
