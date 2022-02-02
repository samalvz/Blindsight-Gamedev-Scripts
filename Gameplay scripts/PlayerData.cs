using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int level;
    public int health;
    public float[] position;
    public int checkpoint_number;
    

    public PlayerData(Player player)
    {
        health = player.GetHealth();
        
        position = new float[3];
        position = player.GetCheckpoint();
        checkpoint_number = player.GetLastRegisteredCheckpoint();
        
        // use this to spawn player at location where "save game' is pressed
        //checkpoint = player.GetCheckpoint();
        //position[0] = player.transform.position.x;
        //position[1] = player.transform.position.y;
        //position[2] = player.transform.position.z;
    }

}
