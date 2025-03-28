using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public float speed = 5f;
    public EnemiesController enemiesController;
    private Rigidbody2D rb;
    public GameObject enemyBullet;

    public int scoreValue;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesController.left)
        {
            rb.velocity = Vector2.left * (speed + enemiesController.speedIncrease);
        } else
        {
            rb.velocity = Vector2.right * (speed + enemiesController.speedIncrease);
        }

        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wall"))
        {
            if (enemiesController.left)
            {
                enemiesController.left = false;
            }
            else
            {
                enemiesController.left = true;
            }
        }
        if (other.CompareTag("PlayerBullet"))
        {
            Destroy(gameObject);
            enemiesController.score += scoreValue;
            enemiesController.EnemyDeath();
        }

    }
    

    public void Shoot()
    {
        Instantiate(enemyBullet, transform.position, transform.rotation);
    }
}
