using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryToggle : MonoBehaviour
{
    public GameObject inventoryUi;
    private bool isVisible;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            isVisible = !isVisible;
            inventoryUi.SetActive(isVisible);
        }
    }
}
