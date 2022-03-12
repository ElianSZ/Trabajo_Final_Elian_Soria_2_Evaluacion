using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DataKills : MonoBehaviour
{
    public TextMeshProUGUI killsText;
    public TextMeshProUGUI highestScoreText;

    void Start()
    {
        killsText.text = $"You have done {PersistentData.sharedInstance.kills} kills!";
        highestScoreText.text = $"High Score: {PersistentData.sharedInstance.highestScore} kills";
    }
}