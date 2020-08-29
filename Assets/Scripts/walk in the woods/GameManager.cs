using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public int day = 1;
    public bool nightTime;
    public bool DayTime;
    public GameObject nextNight;
    public ActiveFog controlDays;
    public PlaceSleepingBag playerSlept;
    public static bool changingLevel; 

    // Start is called before the first frame update
    void Start()
    {
        nextNight.GetComponent<Text>().text = "Day " + day;
        
    }

    private void Update()
    {
        if (playerSlept.canSleep && playerSlept.faderHasPlayed)
        {
            controlDays.fogActive = false;
            
        }
    }

    public bool IsNightTime()
    {
        return nightTime;
    }

    public bool IsDayTime()
    {
        return DayTime;
    }






}
