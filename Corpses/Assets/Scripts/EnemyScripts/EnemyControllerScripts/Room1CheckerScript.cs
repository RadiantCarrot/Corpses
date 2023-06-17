using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room1CheckerScript : MonoBehaviour
{
    public bool room1Spawn;
    public EnemySpawnScript enemySpawnScript;

    // Start is called before the first frame update
    void Start()
    {
        enemySpawnScript = GameObject.Find("EnemyController").GetComponent<EnemySpawnScript>(); // assign spawn script
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) // if there is player
        {
            enemySpawnScript.timerActive = true; // start timer
            enemySpawnScript.RoomToSpawn(1); // pass room number
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) // if there is player
        {
            enemySpawnScript.timerActive = false; // stop timer


            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy"); // find and shove all enemies into array

            foreach (GameObject enemy in enemies)
            {
                Destroy(enemy); // destroy enemies
            }
        }
    }
}
