using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemySpawnScript : MonoBehaviour
{
    public bool timerActive = false;
    public float spawnInterval;
    public float spawnIntervalReset;
    public float spawnIntervalMax;
    public float spawnIntervalMin;

    public int spawnRoom;

    public float spawnRadius;
    public GameObject player;
    public GameObject room1Checker;
    public GameObject room2Checker;

    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player"); // set player
        room1Checker = GameObject.Find("Room1Checker"); // set room checker
        room2Checker = GameObject.Find("Room2Checker"); // set room checker

        spawnIntervalReset = spawnIntervalMax; // set initial spawn interval
        spawnInterval = spawnIntervalReset;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnIntervalReset <= spawnIntervalMin) // if spawn interval value is equal or below minimum value
        {
            spawnIntervalReset = spawnIntervalMin; // cap spawn interval reset to minimum value
        }

        if (timerActive == true)
        {
            spawnInterval -= Time.deltaTime; // decrease spawn interval

            if (spawnInterval <= 0) // if spawn interval is less than or equal to zero
            {
                SpawnEnemies();

                spawnInterval = spawnIntervalReset; // reset spawn interval

                spawnIntervalReset -= 1f; // decrease spawn interval reset value
            }
        }

        else
        {
            spawnIntervalReset = spawnIntervalMax; // set initial spawn interval
            spawnInterval = spawnIntervalReset;
        }
    }

    public void RoomToSpawn(int roomNumber)
    { 
        spawnRoom = roomNumber; // get room to spawn enemies in
    }

    public void SpawnEnemies()
    {
        switch (spawnRoom)
        {
            case 1:

                for (int i = 0; i <= 3; i++) // spawn enemy 4 times
                {
                    Instantiate(enemy1, Random.insideUnitSphere * spawnRadius + room1Checker.transform.position, room1Checker.transform.rotation); // instantiate in a radius around self
                }

                for (int i = 0; i <= 1; i++) // spawn enemy 2 times
                {
                    Instantiate(enemy2, Random.insideUnitSphere * spawnRadius + room1Checker.transform.position, room1Checker.transform.rotation); // instantiate in a radius around self
                }

                break;

            case 2:

                for (int i = 0; i <= 5; i++) // spawn enemy 6 times
                {
                    Instantiate(enemy1, Random.insideUnitSphere * spawnRadius + room2Checker.transform.position, room2Checker.transform.rotation); // instantiate in a radius around self
                }

                for (int i = 0; i <= 2; i++) // spawn enemy 3 times
                {
                    Instantiate(enemy2, Random.insideUnitSphere * spawnRadius + room2Checker.transform.position, room2Checker.transform.rotation); // instantiate in a radius around self
                }

                for (int i = 0; i <= 0; i++) // spawn enemy 1 times
                {
                    Instantiate(enemy3, Random.insideUnitSphere * spawnRadius + room2Checker.transform.position, room2Checker.transform.rotation); // instantiate in a radius around self
                }

                break;

            default:

                // no spawn

                break;
        }
    }  
}
