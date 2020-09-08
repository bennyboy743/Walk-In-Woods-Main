﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAndRemove : MonoBehaviour
{
    // Start is called before the first frame update

    HoldItems holdingItems;
    private GameObject item;
    private Camera fpsCam;
    private int rayLayerMask;
    public float reachRange = 1.8f;

    public InventoryObject inventory;



    public bool itemPickUp;
    public UiHolder pickUpMsg;

    private GameObject holdingTempItem;
    private int id;    

     
    void Start()
    {
        holdingItems = GameObject.FindObjectOfType<HoldItems>();
        fpsCam = Camera.main;
        LayerMask iRayLM = LayerMask.NameToLayer("InteractRaycast");
        rayLayerMask = 1 << iRayLM.value;
    }

    // Update is called once per frame

    private void Update()
    {
        ShowItemAboutToPickUp();
        
    }

 

    public void ShowItemAboutToPickUp()
    {
        int x = Screen.width / 2;
        int y = Screen.height / 2;
        Ray ray = fpsCam.ScreenPointToRay(new Vector3(x, y));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, reachRange, rayLayerMask))
        {
            var item = hit.collider.GetComponent<Item>();
            
            pickUpMsg.ShowMessage(item.name,2);
            pickUpMsg.showInteractMsg = true;
            PickedUpItem(item);
        }
        else
        {
            pickUpMsg.ShowMessage(" ",2);
            pickUpMsg.showInteractMsg = false;
        }
    }
    

    public void PickedUpItem(Item item)
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (item)
            {
                inventory.AddItem(item.item, 1);
                Destroy(item.gameObject);
            }
        }

    }



    public void DropItem(GameObject item)
    {
        if (holdingItems.CheckingItem(item))
        {
            Debug.Log("has item");
            holdingItems.itemsInBagPack.Remove(item);
        }
        else
        {
            Debug.Log("cant drop Item as dont have it");
        }
    }
}
