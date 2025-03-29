using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipController : MonoBehaviour
{
    public float speed = 5f;
    public float leftLimit;
    public float rightLimit;

    public LifeCounter lifeCounter;

    public GameObject playerBullet;

    void Update()
    {
        // Movimiento horizontal del jugador:
        float hMovement = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        float newX = Mathf.Clamp(transform.position.x + hMovement, leftLimit, rightLimit);

        transform.position = new Vector3(newX, transform.position.y, transform.position.z);


        // Disparo con la tecla ESPACIO:
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(playerBullet, transform.position, transform.rotation);
        }
    }

    // Detecto si le ha dado una bala a la nave:
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBullet"))
        {
            playerHit();
        }
    }

    // Cuando le da una bala:
    public void playerHit()
    {
        // Quito un punto a la vida y la pongo en el centro:
        if (lifeCounter.hp > 0)
        {
            lifeCounter.hp--;
            transform.position = new Vector3(Vector3.zero.x, transform.position.y, transform.position.z);
        }
        // Si me quedo sin vidas, la destruyo y vuelvo al menú:
        else
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Menu");
        }
    }

}