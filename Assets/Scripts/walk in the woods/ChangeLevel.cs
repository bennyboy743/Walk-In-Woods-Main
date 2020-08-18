using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{

    //public GameObject cutScene;
    void  OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("teleport");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
     
    }
}
