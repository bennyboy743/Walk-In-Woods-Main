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
    private string msg;
    private bool showInteractMsg;
    private GUIStyle guiStyle;
    private bool playerEntered;
    public bool itemPickUp;


    void Start()
    {
        holdingItems = GameObject.FindObjectOfType<HoldItems>();
        fpsCam = Camera.main;
        setupGui();

       
    }

    // Update is called once per frame

    private void Update()
    {
        PickedUpItem();
    }


  

    
    public void PickedUpItem()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            int x = Screen.width / 2;
            int y = Screen.height / 2;

            Ray ray = fpsCam.ScreenPointToRay(new Vector3(x, y));
            RaycastHit hit;

            
            if(Physics.Raycast(ray, out hit))
            {
                PickUpAble p = hit.collider.GetComponent<PickUpAble>();
                if(p != null)
                {
                    itemPickUp = true;
                    string itemTag = p.tag;
                    Debug.Log("picking up " + itemTag);
                    Destroy(hit.transform.gameObject);
                }
            }
        }
    }

    public void DropingItem()
    {

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
