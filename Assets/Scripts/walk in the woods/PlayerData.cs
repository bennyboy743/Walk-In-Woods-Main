using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData {

    public int health;
    public int food;
   // public int heartRate;
    public int water;
    public float[] position;

    public PlayerData(PlayerStates player )
    {
        health = player.health;
        food = player.food;
        water = player.water;
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }



}
