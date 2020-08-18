using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;




public class Pausemenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public bool PauseMenuActive = false;
    public GameObject PauseMenuUI;
   // public GameObject OptionMenuUI;
    public GameObject FPSController;
    


    public void Start()
    {
        FPSController.GetComponent<FirstPersonController>();

    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Debug.Log("game is unpaused");
                Resume();
            }
            else
            {
                Debug.Log("game is paused");
                PauseMenu();
            }

        }

    }
    
   public void Resume()
    {
       
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    

    public void PauseMenu()
    {
       
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        PauseMenuActive = true;

    }

 

    public void JumpToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void QuitGame()
    {
        Debug.Log("Exiting Game");
        Application.Quit();
    }
}
