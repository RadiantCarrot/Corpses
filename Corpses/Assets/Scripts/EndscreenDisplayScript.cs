using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndscreenDisplayScript : MonoBehaviour
{
    public AnalyticsScript analyticsScript;

    public TMP_Text bulletsFired;
    public TMP_Text enemiesSlain;
    public TMP_Text highestLevel;
    public TMP_Text totalPlaytime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("MainMenu");
        }

        bulletsFired.text = "Bullets Fired: " + analyticsScript.bulletsFired.ToString(); // display bullets fired
        enemiesSlain.text = "Enemies Slain: " + analyticsScript.enemiesSlain.ToString(); // display enemies slain
        highestLevel.text = "Highest Level: " + analyticsScript.highestLevel + " (" + analyticsScript.currentXp + "/" + analyticsScript.maxXp + "xp)"; // display highest level
        totalPlaytime.text = "Total Playtime: " + analyticsScript.minuteValue + "mins " + analyticsScript.secondValue + "secs"; // display total playtime
    }
}
