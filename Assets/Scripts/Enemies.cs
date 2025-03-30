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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movimiento del enemigo según la dirección:
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
        // Si el enemigo choca con la pared, cambia de dirección:
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
        // Si choca con la bala de la nave:
        if (other.CompareTag("PlayerBullet"))
        {   
            // Destruyo el marciano, aumento la puntuación y subo la velocidad:
            Destroy(gameObject);
            enemiesController.score += scoreValue;
            enemiesController.EnemyDeath();
        }
    }

    // Disparo del enemigo: crea una bala en su posición en la que esté.
    public void Shoot()
    {
        Instantiate(enemyBullet, transform.position, transform.rotation);
    }
}