using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed = 5f;

    void Start()
    {
        // La bala se destruye a los 5s:
        Destroy(gameObject, 5f);
    }

    void Update()
    {
        // Muevo la bala hacia arriba:
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Si choca con un marcianito o un escudo, se destruye:
        if (collision.CompareTag("Enemy") || collision.CompareTag("Building"))
        {
            Destroy(gameObject);
        }
    }
}
