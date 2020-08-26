using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiHolder : MonoBehaviour
{

    private GUIStyle guiStyle;
    private string uiMsg;
    private string nonPickMsg;
    private bool showInteractMsg;
    private bool nonPickMsgshowInteractMsg;
    private int ChangeIntract;



    private void Start()
    {
        setupGui();
    }

    private void setupGui()
    {
        guiStyle = new GUIStyle();
        guiStyle.fontSize = 16;
        guiStyle.fontStyle = FontStyle.Bold;
        guiStyle.normal.textColor = Color.red;
        uiMsg = "";
    }
    
    // items that player can pick up
    public void AddUiMsg(string msg)
    {
        uiMsg = msg;
        ChangeIntract = 1;
    }
    //for doors gates anything the player cant pick up
    public void AddUiMsg(string msg, bool pickUp)
    {
        nonPickMsg = msg;
        ChangeIntract = 2;

    }

    // items that player can pick up
    public void ShowMessage ( bool showAble)
    {
        showInteractMsg = showAble;
    }

    //for doors gates anything the player cant pick up
   

    public bool PlayerInTrigger(bool playerInSpot)
    {
        return playerInSpot;
    }


    void OnGUI()
    {
        //show on-screen prompts to user for guide.
        //show on-screen prompts to user for guide
        /*
       bool playerIsInTrigger = PlayerInTrigger();


        if () ;
        {
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 10, 200, 50), uiMsg, guiStyle);
        }
        else
        {
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 10, 200, 50), nonPickMsg, guiStyle);
        }
        */
        
        
    }
}

