using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PersistentData : MonoBehaviour
{
    public static PersistentData sharedInstance;
    public int kills;

    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}