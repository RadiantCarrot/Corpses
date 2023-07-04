using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsScript
{
    public string playerSprite { get; }
    public int playerHealth { get; }
    public float playerSpeed { get; }

    public PlayerStatsScript(string playerSprite, int playerHealth, float playerSpeed)
    {
        this.playerSprite = playerSprite;
        this.playerHealth = playerHealth;
        this.playerSpeed = playerSpeed;
    }
}
