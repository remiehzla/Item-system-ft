using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Inventory 
{
    // List of inventory items
    public List<InventoryItem> playerInventory = new List<InventoryItem>();

    //Stacking items is handled by dictionaries
    //The key is ItemData, and the value is InventoryItem
    //ItemData tracks which objects are added
    //InventoryItem tracks how many of those objects were added
    private SerializableDictionary<ItemData, InventoryItem> itemDictionary;

    //Add the item to the dictionary
    public void AddItem(ItemData itemData)
    {
        //Check if it is already in the dictionary
        //If there is nothing, it returns null
        if (itemDictionary.TryGetValue(itemData, out InventoryItem item))
        {
            //If it does find something, reference the item value
            //and increase the number of items in the dictionary
            item.IncreaseNumberOfItems();
        }
        else
        {
            //Create an inventory item, if it does not already exist in the inventory by passing in the itemData
            InventoryItem newItem = new InventoryItem(itemData);
            //Add the new item to the list 
            playerInventory.Add(newItem);
            //Add it to the dictionary as well, to keep track of the number of items collected
            //Next time the same item is collected, it will just increase its number
            itemDictionary.Add(itemData, newItem);
        }
    }

    public void RemoveItem(ItemData itemData)
    {
        if (itemDictionary.TryGetValue(itemData, out InventoryItem item))
        {
            //If it does find something, reference the item value
            //and decrease the number of items in the dictionary
            item.DecreaseNumberOfItems();

            //If the number of that item is zero
            if (item.itemCount == 0)
            {
                //Then remove it from the list and dictionary
                playerInventory.Remove(item);
                itemDictionary.Remove(itemData);
            }
        }
    }

    

}
