using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    // Velocidad de la bala del jugador
    public float speed = 5f;

    void Start()
    {
        // Destruyo el proyectil después de 5 segundos
        Destroy(gameObject, 5f);
    }

    void Update()
    {
        // Muevo el proyectil hacia arriba en el eje Y
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Si impacta con un enemigo o una estructura se destruye
        if (collision.CompareTag("Enemy") || collision.CompareTag("Building"))
        {
            Destroy(gameObject);
        }
    }
}
