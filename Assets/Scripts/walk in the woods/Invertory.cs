using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invertory : MonoBehaviour
{
    public bool inventoryEnabled;
    public GameObject inventory;

    

    private void Start()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            inventoryEnabled = !inventoryEnabled;

        if (inventoryEnabled == true)
        {
            OpenInventory();
        }
        else
        {
            CloseInventory();
        }
    }

    void OpenInventory()
    {
        inventory.SetActive(true);
    }

    void CloseInventory()
    {
        inventory.SetActive(false);
    }



}

