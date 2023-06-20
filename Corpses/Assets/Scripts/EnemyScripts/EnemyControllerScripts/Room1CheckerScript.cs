using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Room1CheckerScript : MonoBehaviour
{
    public bool room1Spawn;
    public EnemySpawnScript enemySpawnScript;

    private float startTimer = 10f;
    private float currentTimer;
    public TMP_Text countdownText;
    private bool displayCountdown = false;

    // Start is called before the first frame update
    void Start()
    {
        enemySpawnScript = GameObject.Find("EnemyController").GetComponent<EnemySpawnScript>(); // assign spawn script
    }

    // Update is called once per frame
    void Update()
    {
        if (displayCountdown == true) // if countdown has to be displayed
        {
            currentTimer -= Time.deltaTime; // decrease countdown

            if (currentTimer >= 0)
            {
                countdownText.text = "Get Ready, Enemies Spawning in " + currentTimer.ToString("F2") + "!"; // display countdown text
            }
            else
            {
                countdownText.text = " "; // display countdown text
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) // if there is player
        {
            enemySpawnScript.timerActive = true; // start timer
            enemySpawnScript.RoomToSpawn(1); // pass room number

            currentTimer = startTimer;
            displayCountdown = true; // display countdown text
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) // if there is player
        {
            enemySpawnScript.timerActive = false; // stop timer

            displayCountdown = false; // wipe countdown text
            countdownText.text = " "; // display countdown text

            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy"); // find and shove all enemies into array

            foreach (GameObject enemy in enemies)
            {
                Destroy(enemy); // destroy enemies
            }
        }
    }
}
