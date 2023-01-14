using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class GameData : MonoBehaviour
{
    // Store the amount of times the player has died
    public int deathCount;

    // Initialize a constructor which contains
    // the default values used when there's no data to load
    public GameData()
    {
        this.deathCount = 0;
    }
}
