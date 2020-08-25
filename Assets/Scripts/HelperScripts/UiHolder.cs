using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiHolder : MonoBehaviour
{

    private GUIStyle guiStyle;
    private string msg;

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
        msg = "";
    }


    void OnGUI()
    {
        /*
        //show on-screen prompts to user for guide.
        if (showInteractMsg)  //show on-screen prompts to user for guide.
        {
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 10, 200, 50), msg, guiStyle);
        }
        */
    }
}

