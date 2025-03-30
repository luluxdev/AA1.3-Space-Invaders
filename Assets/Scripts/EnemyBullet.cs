using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 4f;

    void Start()
    {
        // Las balas se destruyen a los 5s:
        Destroy(gameObject, 5f);
    }

    void Update()
    {
        // Muevo la bala hacia abajo:
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Si choca con la nave o un escudo, se destruye:
        if (collision.CompareTag("Player") || collision.CompareTag("Building"))
        {
            Destroy(gameObject);
        }
    }
}