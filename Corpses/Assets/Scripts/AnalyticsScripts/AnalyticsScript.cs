using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Done by KarLonng

public class AnalyticsScript : MonoBehaviour
{
    public int bulletsFired = 0;
    public string displayBulletsFired;
    public string csvBulletsFired;

    public int enemiesSlain = 0;
    public string displayEnemiesSlain;
    public string csvEnemiesSlain;

    public int highestLevel;
    public int currentXp;
    public int maxXp;
    public string displayHighestLevel;
    public string csvHighestLevel;

    public float secondStart = 0;
    public float secondCounter;
    public float secondRounded;
    public float secondValue;
    public float minuteValue;
    public string displayTotalPlaytime;
    public string csvTotalPlaytime;

    public PlayerHealthScript playerHealthScript;
    public XpScript xpScript;

    public CSVWriterScript csvWriterScript;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        highestLevel = xpScript.playerLevel; // get player level
        currentXp = xpScript.currentXp; // get player xp
        maxXp = xpScript.maxXp; // get xp to next level up

        secondCounter += Time.deltaTime; // increase seconds

        displayBulletsFired = "Bullets Fired: " + bulletsFired.ToString(); // display bullets fired
        displayEnemiesSlain = "Enemies Slain: " + enemiesSlain.ToString(); // display enemies slain
        displayHighestLevel = "Highest Level: " + highestLevel + " (" + currentXp + "/" + maxXp + "xp)"; // display highest level
        displayTotalPlaytime = "Total Playtime: " + minuteValue + "mins " + secondValue + "secs"; // display total playtime

        csvBulletsFired = bulletsFired.ToString(); // display bullets fired
        csvEnemiesSlain = enemiesSlain.ToString(); // display enemies slain
        csvHighestLevel = highestLevel + "(" + currentXp + "/" + maxXp + "xp)"; // display highest level
        csvTotalPlaytime = minuteValue + "mins" + secondValue + "secs"; // display total playtime

        if (playerHealthScript.currentHealth <= 0)
        {
            csvWriterScript.WriteCSV(csvBulletsFired, csvEnemiesSlain, csvHighestLevel, csvTotalPlaytime);
        }
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