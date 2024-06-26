using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Artilery : MonoBehaviour
{
    public GameObject Explotion;
    bool spawnHasHappend = false;
    bool isBaught1 = false;
    bool isBaught2 = false;
    bool isBaught3 = false;
    bool isBaught4 = false;
    int currentPrice = 1000;

    public Color newColor = Color.red;

    public Trench score;
    private void OnMouseDown()
    {
        if (score.score >= currentPrice && isBaught1 != true)
        {
            score.score -= currentPrice;
            currentPrice += 250;
            TextMeshProUGUI newText = GetComponent<TextMeshProUGUI>();
            newText.text = "Artillery speed upgrade " + currentPrice + " points!";
            isBaught1 = true;
            newText.color = Color.yellow;
            tid -= 0.5f;
            Debug.Log(tid);
        }
        else if (score.score >= currentPrice && isBaught2 != true && isBaught1 == true)
        {
            score.score -= currentPrice;
            currentPrice += 250;
            TextMeshProUGUI newText = GetComponent<TextMeshProUGUI>();
            newText.text = "Artillery speed upgrade " + currentPrice + " points!";
            isBaught2 = true;
            tid -= 0.5f;
            Debug.Log(tid);
        }
        else if (score.score >= currentPrice && isBaught3 != true && isBaught2 == true)
        {
            score.score -= currentPrice;
            currentPrice += 250;
            TextMeshProUGUI newText = GetComponent<TextMeshProUGUI>();
            newText.text = "Artillery speed upgrade " + currentPrice + " points!";
            isBaught3 = true;
            tid -= 0.5f;
            Debug.Log(tid);
        }
        else if (score.score >= currentPrice && isBaught4 != true && isBaught3 == true)
        {
            score.score -= currentPrice;
            TextMeshProUGUI newText = GetComponent<TextMeshProUGUI>();
            newText.text = "Artillery at max speed!";
            newText.color = Color.cyan;
            isBaught4 = true;
            tid -= 0.5f;
            Debug.Log(tid);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        TextMeshProUGUI newText = GetComponent<TextMeshProUGUI>();
        newText.text = "Artillery 1000 points!";
        newText.color = Color.red;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isBaught1 == true && spawnHasHappend == false)
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
    float tid = 5f;

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(tid);
        spawnHasHappend = false;
    }

}
