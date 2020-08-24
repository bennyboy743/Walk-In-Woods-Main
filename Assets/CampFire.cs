using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampFire : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject fire;
    public GameObject firePartical;
    private Light fireFlame;
    private ParticleSystem fireP;
    public bool fireStart;

    public GameObject[] allLogs;
    private bool playerIntrigger;
    




    private int logs;
    //amount to start the fire
    private int maxLogs;

    void Start()
    {

        fireFlame = fire.GetComponent<Light>();
        fireP = firePartical.GetComponent<ParticleSystem>();

        //fireFlame.enabled = true;

        maxLogs = 6;

    }

    // Update is called once per frame
    void Update()
    {
        //fireFlame.intensity = Random.Range(3.8f,9f);
        // fireP.Play();

        AddLogsToFire();
        Debug.Log(logsThatHaveBeenAdd());
    }

     public void StartFire()
    {
        if(logsThatHaveBeenAdd() >= maxLogs)
        {
            Debug.Log("starting fire");
            fireStart = false;
        }
    }

    public int logsThatHaveBeenAdd()
    {
        return logs;
    }

    public void AddLogsToFire()
    {
        if (!playerIntrigger)
            return;

        if (logsThatHaveBeenAdd() == maxLogs)
        {
            StartFire();
        }

        //count of how many logs we have added to the fire
        if (Input.GetKeyDown(KeyCode.E) && playerIntrigger && logsThatHaveBeenAdd() < maxLogs)
        {
            logs++;
            allLogs[logs].SetActive(true);
            Debug.Log("Player is ready to put down a log");
        }
    }

    public bool HasFireStarted()
    {
        return fireStart;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerIntrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIntrigger = false;
        }
    }



}
