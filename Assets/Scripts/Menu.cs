using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Bot�n para jugar:
    public void Play()
    {
        SceneManager.LoadScene("MainScene");
    }


    // Bot�n para salir:
    public void Exit()
    {
        Application.Quit();
    }
}
