using System.Collections;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject Bullet;
    public Transform shootPoint;
    public float rotationSpeed = 20f;
    public float shootingSpeed = 100f;
    public float shootingCooldown = 0.5f;
    private float lastShootTime = -10f;
    public Trench health;
    void Update()
    {
        if (health.health >= 1)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Rotate(Vector3.back, rotationSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.Space) && Time.time - lastShootTime > shootingCooldown)
            {
                StartCoroutine(ShootAfterDelay(0f));
                StartCoroutine(ShootAfterDelay(0.1f));
                StartCoroutine(ShootAfterDelay(0.2f));

                lastShootTime = Time.time;
            } 
        }
    
    }

    IEnumerator ShootAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Shot();
    }

    void Shot()
    {
        GameObject newBullet = Instantiate(Bullet, shootPoint.position, Quaternion.identity);

        float randomAngle = Random.Range(-5f, 5f);
        Quaternion randomRotation = Quaternion.Euler(0, 0, randomAngle); 

        newBullet.transform.rotation = shootPoint.rotation * randomRotation;

        Vector2 direction = newBullet.transform.right;
        
        newBullet.GetComponent<Rigidbody2D>().velocity = direction * shootingSpeed;
    }
}
