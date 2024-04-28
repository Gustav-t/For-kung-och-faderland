using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Trench : MonoBehaviour
{
    public TextMeshProUGUI HP;
    public TextMeshProUGUI Score;
    public int score = 0;
    public float health = 100;

    public GameObject enemySpawn;
    public GameObject shootingPoint;
    public GameObject player;
    public GameObject artilery;
    void Start()
    {
        HP.text = "Health is " + health;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (health >= 1)
        {
            score += 1;
            Score.text = "Score: " + score;
        }
        else
        {
            Rigidbody2D playerRB = player.GetComponent<Rigidbody2D>();
            playerRB.constraints = RigidbodyConstraints2D.FreezeAll;
            artilery.SetActive(false);
            enemySpawn.SetActive(false);
            shootingPoint.SetActive(false);
        }

    }
    public int GetScore()
    {
        return score;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (health >= 1)
            {
                health -= 1;
                HP.text = "Health is " + health;
            }
        }
    }
}
