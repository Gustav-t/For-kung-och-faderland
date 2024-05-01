using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GasArtillery : MonoBehaviour
{
    public GameObject GasCloud;
    bool spawnHasHappend = false;
    bool isBaught1 = false;
    bool isBaught2 = false;
    bool isBaught3 = false;
    bool isBaught4 = false;
    int currentPrice = 1500;
    float fadeTime = 3;

    public Color newColor = Color.red;

    public Trench score;
    private void OnMouseDown()
    {
        if (score.score >= currentPrice && isBaught1 != true)
        {
            score.score -= currentPrice;
            currentPrice += 500;
            TextMeshProUGUI newText = GetComponent<TextMeshProUGUI>();
            newText.text = "Artillery speed upgrade " + currentPrice + " points!";
            isBaught1 = true;
            newText.color = Color.yellow;
            Debug.Log(fadeTime);
        }
        else if (score.score >= currentPrice && isBaught2 != true && isBaught1 == true)
        {
            score.score -= currentPrice;
            currentPrice += 500;
            TextMeshProUGUI newText = GetComponent<TextMeshProUGUI>();
            newText.text = "Artillery speed upgrade " + currentPrice + " points!";
            isBaught1 = true;
            newText.color = Color.yellow;
            fadeTime += 0.5f;
            Debug.Log(fadeTime);
        }
        else if (score.score >= currentPrice && isBaught3 != true && isBaught2 == true)
        {
            score.score -= currentPrice;
            currentPrice += 500;
            TextMeshProUGUI newText = GetComponent<TextMeshProUGUI>();
            newText.text = "Artillery speed upgrade " + currentPrice + " points!";
            isBaught1 = true;
            newText.color = Color.yellow;
            fadeTime += 0.5f;
            Debug.Log(fadeTime);
        }
        else if (score.score >= currentPrice && isBaught4 != true && isBaught3 == true)
        {
            score.score -= currentPrice;
            TextMeshProUGUI newText = GetComponent<TextMeshProUGUI>();
            newText.text = "Gasartillery at max speed!";
            newText.color = Color.cyan;
            isBaught4 = true;
            fadeTime += 0.5f;
            Debug.Log(fadeTime);
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
        GameObject newCloud = Instantiate(GasCloud, new Vector2(x, y), Quaternion.identity);
        newCloud.GetComponent<GasCloud>().SetFadeTime(fadeTime);
        spawnHasHappend = true;
        StartCoroutine(Timer());
    }
    float tid = 10f;

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(tid);
        spawnHasHappend = false;
    }

}

