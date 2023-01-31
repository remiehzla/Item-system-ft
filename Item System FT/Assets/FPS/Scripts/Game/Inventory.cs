using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class Inventory : MonoBehaviour, IDataManager
{
    public static Inventory Instance;
    public Item itemData;
    public List<Item> items = new List<Item>();

    public Transform ItemContent;
    public GameObject InventoryItem;

    private void Awake()
    {
        Instance = this;
    }
    public void LoadData(GameData data)
    {
        this.items = data.items;
    }
    public void SaveData(GameData data)
    {
       data.items = this.items;
    }
    public void Add(Item item)
    {
        items.Add(item);
    }
    public void ListItems()
    {
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }
        foreach (var item in items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();

            itemName.text = item.itemName;
            itemIcon.sprite = item.itemIcon;
        }
    }
}
