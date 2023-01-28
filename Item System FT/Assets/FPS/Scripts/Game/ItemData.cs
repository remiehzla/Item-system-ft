using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
//Responsible with creating ScriptableObjects
public class ItemData : ScriptableObject
{
    //Add as many field as you want for the items
    public string itemName;
    public Sprite icon;
}
