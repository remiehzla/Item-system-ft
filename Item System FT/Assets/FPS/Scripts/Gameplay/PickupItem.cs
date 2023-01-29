using Unity.FPS.Game;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

namespace Unity.FPS.Gameplay
{
    public class PickupItem : Pickup
    {
        public Item Item;

        protected override void OnPicked(PlayerCharacterController byPlayer)
        {
            Inventory.Instance.Add(Item);
            Destroy(gameObject);
            Inventory.Instance.ListItems();
            
        }
    }
}
