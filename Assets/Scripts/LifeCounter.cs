using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class LifeCounter : MonoBehaviour
{
    public int hp = 3; // Puntos de vida del jugador

    public TextMeshProUGUI hpPrint; // Referencia al texto de la UI para mostrar la vida

    public ShipController shipController; // Referencia al controlador de la nave

    void Start()
    {
        UpdateHpUI(); // Asegura que la UI muestre el HP correcto al iniciar
    }

    void Update()
    {
        UpdateHpUI(); // Actualiza la UI con el valor actual de hp
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Si el jugador colisiona con un enemigo, pierde toda su vida
        if (other.CompareTag("Enemy"))
        {
            hp = 0;

            if (shipController != null)
            {
                shipController.playerHit();
            }
        }
    }

    private void UpdateHpUI()
    {
        // Actualiza el texto de la UI con el valor actual de HP
        if (hpPrint != null)
        {
            hpPrint.text = hp.ToString();
        }
    }
}
