using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class GameData
{
    // Store the player's position
    public Vector3 playerPos;

    public bool isJetpackPicked;

    public float healthAmount;

    //Dictionary that keeps track if the collected items
    public SerializableDictionary<string, bool> itemsCollected;

    public List<Item> items;

    // This constructor contains the default values
    // used when there's no data to load
    public GameData()
    {
        playerPos = Vector3.zero;
        isJetpackPicked = false;
       // healthAmount = 60f;
        itemsCollected = new SerializableDictionary<string, bool>();
        items = new List<Item>();
    }
}
