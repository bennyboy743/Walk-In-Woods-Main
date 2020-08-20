using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldItems : MonoBehaviour
{

    public List<string> itemsInBagPack = new List<string>();
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
        itemsInBagPack.Add(item.name);
    }

   

    public string HasItemInventory()

    {
        for (int i = 0; i < itemsInBagPack.Count; i++)
        {
            Debug.Log(itemsInBagPack[i]);
            return itemsInBagPack[i];
        }

        return ""; 
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
