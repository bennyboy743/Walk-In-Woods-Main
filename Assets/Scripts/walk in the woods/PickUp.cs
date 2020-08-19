using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    // Start is called before the first frame update

    HoldItems holdingItems;
    public GameObject boltCutter;

   void Start()
   {
        holdingItems = GameObject.FindObjectOfType<HoldItems>();
   }

    // Update is called once per frame
   

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("Pick up object");
        if(other.tag == "Player")
        {
            PickedUpItem(boltCutter);
        }
    }

    public void PickedUpItem(GameObject item)
    {
        holdingItems.AddItem();
        Debug.Log(holdingItems.Showitems());
        Destroy(item);
    }
}
