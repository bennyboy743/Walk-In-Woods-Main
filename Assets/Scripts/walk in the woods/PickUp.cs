using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    // Start is called before the first frame update

    HoldItems holdingItems;
    public GameObject boltCutter;
    private Camera fpsCam;
    private int rayLayerMask;
    public float reachRange = 1.8f;
    private string msg;
    private bool showInteractMsg;
    private GUIStyle guiStyle;


    void Start()
   {
        holdingItems = GameObject.FindObjectOfType<HoldItems>();
        fpsCam = Camera.main;
        setupGui();



    }

    // Update is called once per frame

    private void Update()
    {
        IsItem();
    }


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

    public void IsItem()
    {
        Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        //if raycast hits a collider on the rayLayerMask
        if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, 10))
        {
            //that is a item
            Debug.Log(hit.collider.tag);
            if(hit.collider.tag == "log")
            {
                showInteractMsg = true;
                msg = "Pick up log";
            }
        }
    }

    private void setupGui()
    {
        guiStyle = new GUIStyle();
        guiStyle.fontSize = 16;
        guiStyle.fontStyle = FontStyle.Bold;
        guiStyle.normal.textColor = Color.red;
        msg = "";
    }


    void OnGUI()
    {
        //show on-screen prompts to user for guide.
        if (showInteractMsg)  //show on-screen prompts to user for guide.
        {
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 10, 200, 50), msg, guiStyle);
        }
    }
}
