using Unity.FPS.Game;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;

namespace Unity.FPS.Gameplay
{
    public class ItemPickup : Pickup
    {
        // Use their pick up system with new items
        // by overriding their own script
        protected override void OnPicked(PlayerCharacterController byPlayer)
        {
            Destroy(gameObject);
        }
    }
}

