using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public int hitpoints = 15;

    void Update()
    {
        // Si la estructura se queda sin los hitpoints, desaparece:
        if (hitpoints <= 0) { Destroy(gameObject); }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Si choca un proyectil reduce el tamaño y los hitpoints:
        if (collision.CompareTag("EnemyBullet") || collision.CompareTag("PlayerBullet"))
        {
            transform.localScale = new Vector3(transform.localScale.x - 0.1f, transform.localScale.y, transform.localScale.z);
            hitpoints--;
        }
    }
}
