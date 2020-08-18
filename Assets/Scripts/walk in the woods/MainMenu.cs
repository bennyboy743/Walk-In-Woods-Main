using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject OptionMenuUI;
    public void StartGame()
    {
        Debug.Log("Starting Game, Loading first Level");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Exiting Game");
        Application.Quit();
    }

    public void OptionMenu()
    {
       OptionMenuUI.SetActive(true);
    }


}
