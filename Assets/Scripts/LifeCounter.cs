using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

public class LifeCounter : MonoBehaviour
{
    public int hp = 3;

    public TextMeshProUGUI hpPrint;

    public ShipController shipController;

    void Start()
    {
        UpdateHpUI();
    }

    void Update()
    {
        UpdateHpUI();
    }

    // Si el jugador choca con un marciano, muere y vamos al menú:
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            hp = 0;

            if (shipController != null)
            {
                shipController.playerHit();
            }

            SceneManager.LoadScene("Menu");
        }
    }

    // Actualizar la vida:
    private void UpdateHpUI()
    {
        if (hpPrint != null)
        {
            hpPrint.text = hp.ToString();
        }
    }
}
