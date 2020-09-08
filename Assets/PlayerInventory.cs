using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public InventoryObject inventory;
    public GameObject inventoryUi;
    private bool openClose;

    public void OpenInventory(bool state)
    {
        inventoryUi.SetActive(state);
    }

  

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            inventory.Save();
        }
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            inventory.Load();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            openClose = !openClose;
            
        }
        OpenInventory(openClose);
    }
    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }

}
