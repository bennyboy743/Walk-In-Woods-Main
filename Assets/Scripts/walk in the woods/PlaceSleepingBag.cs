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

    CampFire statesOfFire;






    private void Start()
    {
        InitSleepingBag();
        setupGui();

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

        
        msg = " ";
        faderHasPlayed = true;
        yield return new WaitForSeconds(10f);
        fader.SetActive(false);

    }

    public bool AbleToSleep()
    {
        if (statesOfFire.HasFireStarted())
        {
            msg = "E to sleep";
            return true;
        }
        else
        {
            msg = "Cant sleep need fire";
            return false;
        }
            

        //canSleep = true;
        

        
    }

    public void PutDownSleepingBag()
    {
        sleepingBagPlaced = true;
        sleepingBag.SetActive(true);
        msg = " ";
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
            PlayerInTrigger();
        }
    }
     void PlayerInTrigger()
    {
        playerEntered = true;
        showInteractMsg = true;

    }

    private void setupGui()
    {
        guiStyle = new GUIStyle();
        guiStyle.fontSize = 16;
        guiStyle.fontStyle = FontStyle.Bold;
        guiStyle.normal.textColor = Color.red;
        msg = "Press E To Place Sleeping Bag";
    }


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)     //player has exited trigger
        {
            playerEntered = false;
            //hide interact message as player may not have been looking at object when they left
            showInteractMsg = false;
        }
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
