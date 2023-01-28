using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryItem 
{
    //Which item and how many are picked up
    public ItemData itemData;
    public int itemCount;

    //Create a constructor which creates an item and adds it
    //Will be directly stored into the inventory
    public InventoryItem(ItemData item)
    {
        itemData = item;
        IncreaseNumberOfItems();
    }
    public void IncreaseNumberOfItems()
    {
        itemCount++;
    } 
    public void DecreaseNumberOfItems()
    {
        itemCount--;
    }
}
