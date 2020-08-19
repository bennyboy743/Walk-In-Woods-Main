using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldItems : MonoBehaviour
{

    private HoldItems holdingItems;
    public GameObject[] itemsInBagPack;
    private bool isBoltCutter;
    private int item;

 

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItem()
    {
        item = item + 1;
        isBoltCutter = true;
    }

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

    public int Showitems()
    {
        return item;
    }

    
}
