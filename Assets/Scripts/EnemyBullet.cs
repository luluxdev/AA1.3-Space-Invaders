using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // Velocidad del proyectil enemigo
    public float speed = 4f;

    void Start()
    {
        // Destruyo el proyectil tras 5 segundos
        Destroy(gameObject, 5f);
    }

    void Update()
    {
        // Muevo el proyectil hacia abajo en el eje Y
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Si impacta con el jugador o una estructura se destruye
        if (collision.CompareTag("Player") || collision.CompareTag("Building"))
        {
            Destroy(gameObject);
        }
    }
}
