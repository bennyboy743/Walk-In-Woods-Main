using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampFire : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject fire;
    public GameObject firePartical;
    private Light fireFlame;
    private ParticleSystem fireP;
    public bool fireStart;

    public GameObject[] allLogs;
    private bool playerIntrigger;

    public UiHolder msg;

    public Collider disable;
    public GameManager timeOfDay;

    public PickUpAndRemove dropItem;
   // public HoldItems inventory;

 

    public GameObject Log;//Just to test something

    

    
    private int logs;
    //amount to start the fire
    private int maxLogs;

    void Start()
    {

        fireFlame = fire.GetComponent<Light>();
        fireP = firePartical.GetComponent<ParticleSystem>();

        fireStart = false;

        //fireFlame.enabled = true;

        maxLogs = 6;

    }

    // Update is called once per frame
    void Update()
    {
        //fireFlame.intensity = Random.Range(3.8f,9f);
        // fireP.Play();
        if (Input.GetKeyDown(KeyCode.E))
        {
           AddLogsToFire();
        }
        if (playerIntrigger)
        {
            InteractWithFire(playerIntrigger);
        }
        else
        {
            InteractWithFire(false);
        }

        Debug.Log(logsThatHaveBeenAdd());
    }

     public void StartFire()
     {
        Debug.Log("starting fire");
        fireStart = true;
        msg.actionShowMsg = false;
        timeOfDay.nightTime = true;
     }

    public int logsThatHaveBeenAdd()
    {
        return logs;
    }

    public void AddLogsToFire()
    {
        if (!playerIntrigger)
            return;

        if (logsThatHaveBeenAdd() == maxLogs)
        {
            StartFire();
            DisableTrigger();
            return;
        }

        /* 
        if (inventory.itemsInBagPack.Contains(Log))
        {
            if(playerIntrigger && logsThatHaveBeenAdd() < maxLogs)
            {
                logs++;
                dropItem.DropItem(Log);
                allLogs[logs].SetActive(true);
            }
        }
        */


        //count of how many logs we have added to the fire
        /*
        if (playerIntrigger && logsThatHaveBeenAdd() < maxLogs)
        {
            
            for (int i = 0; i < inventory.itemsInBagPack.Count; i++)
            {
                if (inventory.itemsInBagPack[holdingInt].tag == "log")
                    dropItem.DropItem(inventory.itemsInBagPack[i]);
                holdingInt = i;
            }

            if (inventory.itemsInBagPack[holdingInt].tag == "log")
            {
                
            }
            else
            {
                Debug.Log("this is not a log");
            }
        }
        */
    }

    void DisableTrigger()
    {
       disable.enabled = false;
       InteractWithFire(false);
    }

    void InteractWithFire(bool inSpot)
    {
        if (inSpot && logsThatHaveBeenAdd() < maxLogs)
        {
            msg.ShowMessage("To place logs " + logsThatHaveBeenAdd() + "/6", 1);
            msg.nonPickMsgshowInteractMsg = true;
        }
        else
        {
            msg.nonPickMsgshowInteractMsg = false;
        }
        
        
    }

    public bool HasFireStarted()
    {
        return fireStart;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerIntrigger = true;
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIntrigger = false;
            
        }
    }



}
