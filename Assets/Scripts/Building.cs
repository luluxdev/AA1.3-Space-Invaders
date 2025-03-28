using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    // Puntos de vida de la estructura
    public int hitpoints = 15;

    void Update()
    {
        // Si los puntos de vida llegan a 0 la estructura se destruye
        if (hitpoints <= 0) { Destroy(gameObject); }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Si le choca un proyectil enemigo o del jugador reduce su tamaño y vida
        if (collision.CompareTag("EnemyBullet") || collision.CompareTag("PlayerBullet"))
        {
            transform.localScale = new Vector3(transform.localScale.x - 0.1f, transform.localScale.y, transform.localScale.z);
            hitpoints--;
        }
    }
}
