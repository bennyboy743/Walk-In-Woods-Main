using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAndRemove : MonoBehaviour
{
    // Start is called before the first frame update

    HoldItems holdingItems;
    private GameObject item;
    private Camera fpsCam;
    private int rayLayerMask;
    public float reachRange = 2.8f;

    public InventoryObject inventory;



    public bool itemPickUp;
    public UiHolder pickUpMsg;

     

     
    void Start()
    {
        //holdingItems = GameObject.FindObjectOfType<HoldItems>();
        fpsCam = Camera.main;
        LayerMask iRayLM = LayerMask.NameToLayer("InteractRaycast");
        rayLayerMask = 1 << iRayLM.value;
    }

    // Update is called once per frame

    private void Update()
    {
        
        
    }

    private void FixedUpdate()
    {
         ShowItemAboutToPickUp();
        // TestingPickUp();
    }
    /*
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
    */
    public void TestPickedUpItem(Item item)
    {
        if (Input.GetKey(KeyCode.E))
        {
           
            if (item)
            {
                Destroy(item.gameObject);
                inventory.AddItem(item.item, 1);
                
            }
        }
    }


    public void ShowItemAboutToPickUp()
    {
        int x = Screen.width / 2;
        int y = Screen.height / 2;
        Ray ray = fpsCam.ScreenPointToRay(new Vector3(x, y));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, reachRange, rayLayerMask))
        {
            var theItem = hit.collider.GetComponent<Item>();
            
            pickUpMsg.ShowMessage(theItem.name,2);
            pickUpMsg.showInteractMsg = true;
            TestPickedUpItem(theItem);
        }
        else
        {
            pickUpMsg.ShowMessage(" ",2);
            pickUpMsg.showInteractMsg = false;
        }
    }

    public void TestingPickUp()
    {
        int x = Screen.width / 2;
        int y = Screen.height / 2;
        Ray ray = fpsCam.ScreenPointToRay(new Vector3(x, y));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, reachRange, rayLayerMask))
        {
            Destroy(hit.collider.gameObject);
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
