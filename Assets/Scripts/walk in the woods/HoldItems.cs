using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldItems : MonoBehaviour
{

    public List<GameObject> itemsInBagPack = new List<GameObject>();
    //private bool isBoltCutter;
    

    private void Start()
    {
        //debug prepose, just so i dont have to pick up the item
        //isBoltCutter = true;
    }

   

    // Update is called once per frame


    public void AddItem(GameObject item)
    {
        Debug.Log( item.name + " has been added to inventory" );
        itemsInBagPack.Add(item);
    }

    public bool HasItemInventory(GameObject item)
    {
        for (int i = 0; i < itemsInBagPack.Count; i++)
        {
            if(item.tag == itemsInBagPack[i].tag)
            {
                return true;
            }
            else
            {
                Debug.Log("You do not have this item");
                return false;
            }

           
        }

        return false; 
    }



    /*
   public bool HasBoltCutter() 
   {

       if (isBoltCutter)
       {
           return true;
       }
       else
       {
           return false;
       }

   }

   */


}
