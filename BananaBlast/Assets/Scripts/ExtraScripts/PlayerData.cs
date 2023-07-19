using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Jaina - this is for a Save and Load System incase we wanna implement it (4/7/2023)
[System.Serializable]
public class PlayerData
{
    public int level;
    public int health;
    public float[] position;

    public PlayerData(Player player) //takes data from player script
    {
        level = player.level;
        health = player.health;

        position = new float[3];//access player coordinates
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

    }
}
