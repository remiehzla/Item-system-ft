using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour, IDataManager
{
    [SerializeField] public int collectedItems = 0;
    private TextMeshProUGUI itemsCollectedText;
    public bool isPicked;

    private void Awake()
    {
        itemsCollectedText = this.GetComponent<TextMeshProUGUI>();
    }
    public void LoadData(GameData data)
    {
        // Check whether this item has already been collected or not
        foreach (KeyValuePair<string, bool> pair in data.itemsCollected)
        {
            if (pair.Value)
            {
                collectedItems++;            
            }
        }
    }

    public void SaveData(GameData data)
    {
        data.collectedItems = this.collectedItems;
    }
    private void Update()
    {
        itemsCollectedText.text = "Number of items collected: " + collectedItems;
    }
}
