using Unity.FPS.Game;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;

namespace Unity.FPS.Gameplay
{
    public class ItemPickup : Pickup, IDataManager
    {
        // Use their pick up system with new items by overriding their own script
        // Generate ID for the dictionary
        // 32 characters that have a very high chance to be unique
        [SerializeField] private string id;
        [SerializeField] private bool pickedUp = false;

        //Add a command for reference
        [ContextMenu("Generate GUID into ID")]
        private void GenerateGUID()
        {
            id = System.Guid.NewGuid().ToString();
        }
        public void LoadData(GameData data)
        {
            // Check whether this item has already been collected or not
            data.itemsCollected.TryGetValue(id, out pickedUp);
            if (pickedUp)
            {
                // Make sure the item cannot be collected again upon loading the game
                Destroy(gameObject);
            }
        }

        public void SaveData(GameData data)
        {
            // Check if the ID of the item exists in the dictionary
            if (data.itemsCollected.ContainsKey(id))
            {
                data.itemsCollected.Remove(id);
            }

            data.itemsCollected.Add(id, pickedUp);
        }

        protected override void OnPicked(PlayerCharacterController byPlayer)
        {
            // Check if the item has been collected
            // Other scripts check if the item has been assigned to the player's component,
            // but it is not neccessary in this context
            if (!pickedUp)
            {
                CollectItem();
            }
            
        }

        private void CollectItem()
        {
            pickedUp = true;
            Destroy(gameObject);
        }
        
    }
}

