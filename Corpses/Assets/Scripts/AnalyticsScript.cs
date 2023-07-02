using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AnalyticsScript : MonoBehaviour
{
    public int bulletsFired = 0;
    public string displayBulletsFired;

    public int enemiesSlain = 0;
    public string displayEnemiesSlain;

    public int highestLevel;
    public int currentXp;
    public int maxXp;
    public string displayHighestLevel;

    public float secondStart = 0;
    public float secondCounter;
    public float secondRounded;
    public float secondValue;
    public float minuteValue;
    public string displayTotalPlaytime;

    public EndscreenDisplayScript endscreenDisplayScript;
    public XpScript xpScript;

    // Start is called before the first frame update
    void Start()
    {
        secondCounter = secondStart;
    }

    // Update is called once per frame
    private void Update()
    {
        highestLevel = xpScript.playerLevel; // get player level
        currentXp = xpScript.currentXp; // get player xp
        maxXp = xpScript.maxXp; // get xp to next level up

        secondCounter += Time.deltaTime; // increase seconds
    }

    public void BulletCounter(int bulletsToAdd)
    {
        bulletsFired += bulletsToAdd;
    }

    public void EnemyCounter(int enemiesToAdd)
    {
        enemiesSlain += enemiesToAdd;
    }

    public void SetPlaytime()
    {
        minuteValue = Mathf.Round(secondCounter / 60);
        secondValue = Mathf.Round(secondCounter % 60);
    }
}