using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Botón para jugar:
    public void Play()
    {
        SceneManager.LoadScene("MainScene");
    }


    // Botón para salir:
    public void Exit()
    {
        Application.Quit();
    }
}
