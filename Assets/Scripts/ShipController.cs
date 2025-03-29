using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float speed = 5f;
    public float leftLimit;
    public float rightLimit;

    public LifeCounter lifeCounter;

    public GameObject playerBullet;

    void Update()
    {
        // Movimiento horizontal del jugador
        float hMovement = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        float newX = Mathf.Clamp(transform.position.x + hMovement, leftLimit, rightLimit);

        transform.position = new Vector3(newX, transform.position.y, transform.position.z);

        // Disparo con la tecla ESPACIO
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(playerBullet, transform.position, transform.rotation);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Si el jugador es golpeado por una bala enemiga:
        if (collision.CompareTag("EnemyBullet"))
        {
            playerHit();
        }
    }

    public void playerHit()
    {
        if (lifeCounter.hp > 0)
        {
            lifeCounter.hp--;
            transform.position = new Vector3(Vector3.zero.x, transform.position.y, transform.position.z);
        }
        else
        {
            Destroy(gameObject); // Destruir la nave si se queda sin vidas
        }
    }

}