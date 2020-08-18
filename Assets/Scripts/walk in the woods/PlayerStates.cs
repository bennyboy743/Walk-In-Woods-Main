using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStates : MonoBehaviour
{
    public int health;
    public int food;
   //public int heartRate;
    public int water;
   
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
        Debug.Log("Saving data");
    }
    
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        health = data.health;
        food = data.food;
        water = data.water;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;

    }


}
