using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DataKills : MonoBehaviour
{
    public TextMeshProUGUI killsText;

    private void Awake()
    {
        // kills = GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        killsText.text = $"You have done {PersistentData.sharedInstance.kills} kills!";
    }
}