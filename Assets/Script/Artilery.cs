using System.Collections;
using UnityEngine;

public class Artilery : MonoBehaviour
{
    public GameObject Explotion;
    bool spawnHasHappend = false;
    float tid = 5f;
    bool isBaught = false;
    public Color newColor = Color.red;

    public Trench score;
    private void OnMouseDown()
    {
        if (score.score >= 1000)
        {
            score.score -= 1000;
            Renderer renderer = GetComponent<SpriteRenderer>();
            renderer.enabled = false;
            isBaught = true;
        }
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
        float x = Random.Range(-4f, 8.5f);
        float y = Random.Range(-4.5f, 4.1f);
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
