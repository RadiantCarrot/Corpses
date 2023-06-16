using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room2CheckerScript : MonoBehaviour
{
    public bool room2Spawn;
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
            room2Spawn = true; // can spawn enemies
            enemySpawnScript.SpawnEnemies(2);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) // if there is player
        {
            room2Spawn = false; // cannot spawn enemies
        }
    }
}
