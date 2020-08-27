using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGate : MonoBehaviour
{
    public bool stateOfGate;
    public Animator gateAni;
    private bool playerInSpot;
    public UiHolder uiHolder;
    public BoxCollider disableBoxCollider;
    HoldItems hasItem;
    public GameObject gateLock;


    private void Start()
    {
        gateAni = GetComponent<Animator>();
        hasItem = GameObject.FindObjectOfType<HoldItems>();
        
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E) & playerInSpot)
        {
            //Debug.Log(hasItem.HasItemInventory().ToString());
            if (hasItem.HasItemInventory().ToString() == "BoltCutters")
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
        lockRemove();
        gateAni.SetBool("open", stateOfGate);
        Debug.Log(stateOfGate);
        

    }

    void lockRemove()
    {
        gateLock.SetActive(false);
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
            uiHolder.ShowMessage("Open Gate",1);
            uiHolder.nonPickMsgshowInteractMsg = true;
            playerInSpot = true;
            
        }
    }

    
    private void OnTriggerExit(Collider other)
    {
        //work in progress, need to work out why it wont close
        //CloseGate();
        playerInSpot = false;
        uiHolder.ShowMessage(" ",1);
        uiHolder.nonPickMsgshowInteractMsg = false;
    }
}
