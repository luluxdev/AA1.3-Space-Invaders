using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Progress;

public class EnemiesController : MonoBehaviour
{
    public bool left;
    public bool goDown;
    public float speedIncrease;
    public float bulletTimer = 1;

    public TextMeshProUGUI scorePrint;
    public int score = 0;
    public List<GameObject> enemies;

    void Start()
    {
        UpdateScoreUI();
    }

    void Update()
    {
        UpdateScoreUI();

        // Si los enemigos no van a la izquierda, bajan:
        if (left != goDown)
        {
            transform.Translate(Vector3.down * 0.2f);
            goDown = left;
        }

        // Disparo de los enemigos por cada loop del temporizador:
        if (Time.time >= bulletTimer)
        {
            GameObject targetEnemy = GetRandomAliveEnemy();

            if (targetEnemy != null)
            {
                Enemies targetEnemyScript = targetEnemy.GetComponent<Enemies>();
                targetEnemyScript.Shoot();
            }

            bulletTimer = Time.time + 1; // Reinicio temporizador.
        }
    }

    // Aumenta la velocidad cada vez que muere un enemigo:
    public void EnemyDeath()
    {
        speedIncrease += 0.1f;
    }

    // Ecojo un enemigo random desde donde saldrá la bala:
    GameObject GetRandomAliveEnemy()
    {
        // Estructura de lista donde guardo los marcianitos:
        List<GameObject> aliveEnemies = new List<GameObject>();

        // Filtro para seleccionar solo los "vivos":
        foreach (var enemy in enemies)
        {
            if (enemy != null)
            {
                aliveEnemies.Add(enemy);
            }
        }

        if (aliveEnemies.Count > 0)
        {
            int randomIndex = UnityEngine.Random.Range(0, aliveEnemies.Count);
            return aliveEnemies[randomIndex];
        }

        return null;
    }

    // Actualizar la puntuación:
    private void UpdateScoreUI()
    {
        if (scorePrint != null)
        {
            scorePrint.text = score.ToString();
        }
    }

}
