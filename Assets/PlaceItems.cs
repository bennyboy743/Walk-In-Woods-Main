using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceItems : MonoBehaviour
{
    private GameObject holdIteam;
    public GameObject item;
    public Transform playerLocation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            holdIteam = Instantiate(item, playerLocation.position, playerLocation.rotation);
        }
        
    }
}
