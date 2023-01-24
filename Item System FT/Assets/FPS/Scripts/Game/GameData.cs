using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class GameData
{
    // Store the player's position
    public Vector3 playerPos;

    //Dictionary that keeps track if the collected items
    public Dictionary<string, bool> itemsCollected;

    // This constructor contains the default values
    // used when there's no data to load
    public GameData()
    {
        playerPos = Vector3.zero;
        itemsCollected = new Dictionary<string, bool>();
    }
}
