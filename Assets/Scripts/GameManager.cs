using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TextMeshProUGUI killsText;
    public TextMeshProUGUI highestScoreText;

    public int kills = 0;
    public int highestScore = 0;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        highestScore = PlayerPrefs.GetInt("highestScore", 0);
        killsText.text = kills.ToString() + " Kills";
        highestScoreText.text = "High Score: " + highestScore.ToString();
    }

    // Actualizar el contador de muertes
    public void AddPoint()
    {
        kills += 1;
        killsText.text = kills.ToString() + " Kills";

        if (highestScore < kills)
        {
            PlayerPrefs.SetInt("highestScore", kills);
        }
    }
}