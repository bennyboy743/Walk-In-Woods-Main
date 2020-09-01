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

    private void Update()
    {

    }

    public bool CheckingItem(GameObject item)
    {
        if (itemsInBagPack.Contains(item))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    public GameObject GetLogs()
    {
        for (int i = 0; i < itemsInBagPack.Count; i++)
        {
            
            return itemsInBagPack[i];
        }
        return null;
    }


    // Update is called once per frame


    public void AddItem(GameObject item)
    {
        Debug.Log(item.name + " has been added to inventory");
        itemsInBagPack.Add(item);
    }

}
