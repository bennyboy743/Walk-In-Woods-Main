using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ActivePlayer : MonoBehaviour
{

    public GameObject FPSController;
    public GameObject playerInCar;

    
    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        // get the player ready when car scene is finshed
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        FPSController.SetActive(true);
        playerInCar.SetActive(false);
        
    }
    

   
}
