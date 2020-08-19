using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldItems : MonoBehaviour
{

    public List<GameObject> itemsInBagPack;
    private bool isBoltCutter;
    

    private void Start()
    {
        //debug prepose, just so i dont have to pick up the item
        isBoltCutter = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItem(object item)
    {
        //itemsInBagPack.Add(item);
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

    

    
}
