using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntreEscenas : MonoBehaviour
{
    public void BtwnNewScene()
    {
        SceneManager.LoadScene("2. Juego");     // Carga la escena 2
    }

    public void Restart()
    {
        SceneManager.LoadScene("2. Juego");     // Carga la escena 2
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("1. Men�");     // Carga la escena 2
    }
}