using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]
[System.Serializable]
public class Item : ScriptableObject
{
    public int id;
    public string itemName;
    public Sprite itemIcon;
   
}
