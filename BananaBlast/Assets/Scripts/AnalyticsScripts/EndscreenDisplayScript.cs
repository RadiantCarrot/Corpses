using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

// Done by KarLonng

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

        bulletsFired.text = analyticsScript.displayBulletsFired; // display bullets fired
        enemiesSlain.text = analyticsScript.displayEnemiesSlain; // display enemies slain
        highestLevel.text = analyticsScript.displayHighestLevel; // display highest level
        totalPlaytime.text = analyticsScript.displayTotalPlaytime; // display total playtime
    }
}
