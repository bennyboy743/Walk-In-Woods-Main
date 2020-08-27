using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceSleepingBag : MonoBehaviour
{
    private bool playerEntered = false;
    [HideInInspector]
    public  bool canSleep;
    private GameObject player;
    public GameObject sleepingBag;
    private bool sleepingBagPlaced;
    private bool showInteractMsg;
    private GUIStyle guiStyle;
    private string msg;
    public GameObject fader;
    public Material skyBox;
    public GameObject sun;
    public bool faderHasPlayed;
    public bool fireHasStarted;
    Color lerpedColor = Color.white;

    public CampFire statesOfFire;
    public UiHolder interactMsg;


    private void Start()
    {
        InitSleepingBag();
        fireHasStarted = false;
    }

    void InitSleepingBag()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        faderHasPlayed = false;
        lerpedColor = Color.Lerp(Color.white, Color.black, Mathf.PingPong(Time.time, 1));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) & playerEntered)
        {
            PutDownSleepingBag();
            if (AbleToSleep())
            {
               Sleep();
            }
        }
    }

    IEnumerator ShowFader()
    {
        Debug.Log("this is active");
        yield return new WaitForSeconds(1f);
        fader.SetActive(true);
        RenderSettings.skybox = skyBox;
        sun.GetComponent<Light>().intensity = 1.03f;
        sun.GetComponent<Light>().color = lerpedColor;
        faderHasPlayed = true;
        yield return new WaitForSeconds(10f);
        fader.SetActive(false);
    }

    public bool AbleToSleep()
    {
        if (statesOfFire.HasFireStarted())
        {
            interactMsg.ShowMessage("to sleep", 1);
            return true;
        }
        else
        {
            interactMsg.ShowMessage("Cant sleep need fire", 3);
            return false;
        }
            

        //canSleep = true;
    }

    public void PutDownSleepingBag()
    {
        
        ShowGetFireGoingMsg();
        sleepingBagPlaced = true;
        sleepingBag.SetActive(true);
        
    }

    public void Sleep()
    {
        if (sleepingBagPlaced && AbleToSleep())
        {
           
           //StartCoroutine(ShowFader());
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")     //player has collided with trigger
        {
            if (sleepingBagPlaced)
            {
                ShowGetFireGoingMsg();
            }
            else
            {
                interactMsg.nonPickMsgshowInteractMsg = true;
                interactMsg.ShowMessage("place sleeping Bag ", 1);
            }

            //interactMsg.actionShowMsg = true;
            
            PlayerInTrigger();
        }
    }

    void ShowGetFireGoingMsg()
    {
        interactMsg.nonPickMsgshowInteractMsg = false;
        interactMsg.actionShowMsg = true;
    }
     void PlayerInTrigger()
    {
        playerEntered = true;
        
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)     //player has exited trigger
        {
            interactMsg.actionShowMsg = false;
            interactMsg.nonPickMsgshowInteractMsg = false;
            interactMsg.ShowMessage(" ", 1);
            playerEntered = false;
        }
    }
}
