using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Artilery : MonoBehaviour
{
    public GameObject Explotion;
    bool spawnHasHappend = false;
    float tid = 5f;
    bool isBaught = false;
    public Color newColor = Color.red;
    private void OnMouseDown()
    {
        newColor = Color.white;
        Renderer renderer = GetComponent<SpriteRenderer>();
        renderer.material.color = newColor;
        isBaught = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        Renderer renderer = GetComponent<SpriteRenderer>();
        renderer.material.color = newColor;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (isBaught == true && spawnHasHappend == false)
        {
            spawn();
        }
    }

    void spawn()
    {
        float x = Random.RandomRange(-4f, 8.5f);
        float y = Random.RandomRange(-4.5f, 4.1f);
        GameObject newEnemy = Instantiate(Explotion, new Vector2(x, y), Quaternion.identity);
        spawnHasHappend = true;
        StartCoroutine(Timer());
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(tid);
        spawnHasHappend = false;
    }

}
