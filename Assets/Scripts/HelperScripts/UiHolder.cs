using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiHolder : MonoBehaviour
{

    private GUIStyle guiStyle;
    private string uiMsg;
    private string nonPickMsg;
    private string actionMsg;
    public bool showInteractMsg;
    public bool nonPickMsgshowInteractMsg;
    public bool actionShowMsg;
    



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
   
    public void ShowMessage(string msg, int ChangeIntract)
    {
        
        if (ChangeIntract == 1)
        {
            //for doors and placing down Items
            nonPickMsg = "hit [E] " + msg;
        }else if (ChangeIntract == 2)
        {
            //for picking up items
            uiMsg = "hit [E] to pick up " + msg;
        }else if(ChangeIntract == 3)
        {
            actionMsg =  msg;
        }

    }

    void OnGUI()
    {
        //show on-screen prompts to user for guide.0

        if (nonPickMsgshowInteractMsg)
        {
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 10, 200, 50), nonPickMsg, guiStyle);
        }

        if (showInteractMsg)
        {
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 10, 200, 50), uiMsg, guiStyle);
        }

        if (actionShowMsg)
        {
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 10, 200, 50), actionMsg, guiStyle);
        }
    }
}

