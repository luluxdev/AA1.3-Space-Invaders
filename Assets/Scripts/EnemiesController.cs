using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Progress;

public class EnemiesController : MonoBehaviour
{
    public bool left; // Dirección de movimiento
    public bool goDown; // Indica si los enemigos deben bajar
    public float speedIncrease; // Aumento de velocidad al destruir enemigos
    public float bulletTimer = 1; // Temporizador para disparos

    public TextMeshProUGUI scorePrint; // UI para mostrar la puntuación
    public int score = 0; // Puntuación del jugador
    public List<GameObject> enemies; // Lista de enemigos

    void Start()
    {
        UpdateScoreUI(); // Actualiza la UI al inicio
    }

    void Update()
    {
        UpdateScoreUI(); // Actualiza la UI cada frame

        // Movimiento de los enemigos, si no van a la izquierda, bajan
        if (left != goDown)
        {
            transform.Translate(Vector3.down * 0.2f); // Mueve hacia abajo
            goDown = left;
        }

        // Lógica de disparo de los enemigos
        if (Time.time >= bulletTimer) // Si ha pasado el tiempo para disparar
        {
            GameObject targetEnemy = GetRandomAliveEnemy();

            if (targetEnemy != null)
            {
                Enemies targetEnemyScript = targetEnemy.GetComponent<Enemies>();
                targetEnemyScript.Shoot(); // El enemigo dispara
            }

            bulletTimer = Time.time + 1; // Reinicia el temporizador
        }
    }

    // Método llamado cuando un enemigo muere, aumenta la velocidad de los enemigos
    public void EnemyDeath()
    {
        speedIncrease += 0.1f; // Aumenta la velocidad en cada muerte
    }

    // Obtiene un enemigo aleatorio que esté vivo
    GameObject GetRandomAliveEnemy()
    {
        List<GameObject> aliveEnemies = new List<GameObject>();

        // Filtrar los enemigos vivos
        foreach (var enemy in enemies)
        {
            if (enemy != null) // Solo agregar enemigos vivos
            {
                aliveEnemies.Add(enemy);
            }
        }

        // Si hay enemigos vivos, selecciona uno aleatoriamente
        if (aliveEnemies.Count > 0)
        {
            int randomIndex = UnityEngine.Random.Range(0, aliveEnemies.Count);
            return aliveEnemies[randomIndex];
        }

        return null; // No hay enemigos vivos
    }

    // Actualiza el valor de la puntuación en la UI
    private void UpdateScoreUI()
    {
        if (scorePrint != null) // Verifica si la UI está asignada
        {
            scorePrint.text = score.ToString(); // Actualiza el texto de la UI con el valor actual de la puntuación
        }
    }

}
