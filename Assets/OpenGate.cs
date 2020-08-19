using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGate : MonoBehaviour
{
    public bool stateOfGate;
    private bool gateOnOrClose;
    public Animator gateAni;
    private bool playerInSpot;
    private bool showInteractMsg;
    private GUIStyle gui;
    private string msg;
    public BoxCollider disableBoxCollider;
    HoldItems hasItem;


    private void Start()
    {
        gateAni = GetComponent<Animator>();
        hasItem = GameObject.FindObjectOfType<HoldItems>();
        setupGui();
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E) & playerInSpot)
        {
            
            if (hasItem.HasBoltCutter())
            {
                PlayerOpenGate();
            }
            else
            {
                PlayAudio();
            }
            
        }
    }

    void PlayAudio()
    {
        //play saying need bolt cutters
        Debug.Log("Need bolt cutters");
    }
    

    void PlayerOpenGate()
    {
        stateOfGate = true;
        gateOnOrClose = true;
        gateAni.SetBool("open", stateOfGate);
        Debug.Log(stateOfGate);
        

    }
    
    void CloseGate()
    {
        stateOfGate = false;
        gateAni.SetBool("close", stateOfGate);
        Debug.Log(stateOfGate);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            showInteractMsg = true; 
            playerInSpot = true;
            msg = " press [E] open gate";
        }
    }

    
    private void OnTriggerExit(Collider other)
    {
        //work in progress, need to work out why it wont close
        //CloseGate();
        playerInSpot = false;
        showInteractMsg = false; 
    }
    private void setupGui()
    {
        gui = new GUIStyle();
        gui.fontSize = 16;
        gui.fontStyle = FontStyle.Bold;
        gui.normal.textColor = Color.red;
        msg = "test";
    }


    void OnGUI()
    {
        //show on-screen prompts to user for guide.
        if (showInteractMsg)  //show on-screen prompts to user for guide.
        {
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 10, 200, 50), msg, gui);
        }
    }


}
