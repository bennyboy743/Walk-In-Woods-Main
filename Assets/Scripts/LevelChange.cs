using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class LevelChange : MonoBehaviour
{
    private bool playerEntered = false;
    private GameObject player;
    private bool showInteractMsg;
    private GUIStyle guiStyle;
    private string msg;
   // public GameObject playDir;
    
    



    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
       
        setupGui();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) & playerEntered)
        {
           SceneManager.LoadScene("woods");
           
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)     //player has collided with trigger
        {
            playerEntered = true;
            showInteractMsg = true;

        }
    }

    private void setupGui()
    {
        guiStyle = new GUIStyle();
        guiStyle.fontSize = 16;
        guiStyle.fontStyle = FontStyle.Bold;
        guiStyle.normal.textColor = Color.red;
        msg = "Press E To Jump Into Car";
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
        if (showInteractMsg)  //show on-screen prompts to user for guide.
        {
            GUI.Label(new Rect(Screen.width / 2 -100, Screen.height / 2 + 10, 200, 50), msg, guiStyle);
        }
    }
}
