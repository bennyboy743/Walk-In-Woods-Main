using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    // Start is called before the first frame update

    HoldItems holdingItems;
   // public GameObject boltCutter;
    private Camera fpsCam;
    private int rayLayerMask;
    public float reachRange = 1.8f;
    
    private bool showInteractMsg;
    private GUIStyle guiStyle;
    private bool playerEntered;
    public bool itemPickUp;

    public UiHolder msg;
    

     
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
        PickedUpItem();
    }

    public void PickedUpItem()
    {
        int x = Screen.width / 2;
        int y = Screen.height / 2;
        Ray ray = fpsCam.ScreenPointToRay(new Vector3(x, y));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, reachRange, rayLayerMask))
        {
            msg.ShowMessage(true);
            PickUpAble p = hit.collider.GetComponent<PickUpAble>();
            GameObject itemObj = hit.collider.gameObject;
            msg.AddUiMsg("hit [E] to pick up " + itemObj.name);
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (p != null)
                {
                    itemPickUp = true;
                    holdingItems.AddItem(itemObj);
                    Debug.Log("picking up " + itemObj);
                    Destroy(hit.transform.gameObject);
                }
            }
        }
        else
        {
            msg.ShowMessage(false);
        }
    }
}
