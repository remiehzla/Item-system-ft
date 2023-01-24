using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
{
    [SerializeField] private List<TKey> keys = new List<TKey>();
    [SerializeField] private List<TValue> values = new List<TValue>();

    // Save the dictionary to the list 
    public void OnBeforeSerialize()
    {
        // Initialize list by clearing it
        keys.Clear();
        values.Clear();
        // Loop through each key-value pair of the dictionary and add them to the list
        foreach (KeyValuePair<TKey, TValue> pair in this)
        {
            keys.Add(pair.Key);
            values.Add(pair.Value);
        }
    }
    
    // Load the dictionary from the list
    public void OnAfterDeserialize()
    {
        // Clear dictionary
        this.Clear();

        // Check for errors; keys and values number should match
        if (keys.Count != values.Count)
        {
            Debug.Log("Amount of keys (" + keys.Count + ") does not match with the values (" + values.Count + "). Check the error.");
        }

        // Loop through each key-value pair and add them to the dictionary
        for (int i = 0; i < keys.Count; i++)
        {
            this.Add(keys[i], values[i]);
        }
    }
}
