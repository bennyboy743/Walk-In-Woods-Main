using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldItems : MonoBehaviour
{

    private HoldItems holdingItems;
    private bool isBoltCutter;
    private int item;

    private void Awake()
    {
        
    }

    void Start()
    {
        
    }

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
