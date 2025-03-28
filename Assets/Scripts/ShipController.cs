using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento de la nave
    public float leftLimit; // Límite izquierdo del movimiento
    public float rightLimit; // Límite derecho del movimiento

    public LifeCounter lifeCounter; // Referencia al contador de vidas

    public GameObject playerBullet; // Prefab del proyectil del jugador

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
        // Si el jugador es golpeado por una bala enemiga, se llama a playerHit()
        if (collision.CompareTag("EnemyBullet"))
        {
            playerHit();
        }
    }

    public void playerHit()
    {
        if (lifeCounter.playerHp > 0)
        {
            lifeCounter.playerHp--; // Reducir vida del jugador
            transform.position = new Vector3(Vector3.zero.x, transform.position.y, transform.position.z); // Reposicionar la nave
        }
        else
        {
            Destroy(gameObject); // Destruir la nave si se queda sin vidas
        }
    }

}