using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using TMPro;

// Done by KarLonng

public class EnemySpawnScript : MonoBehaviour
{
    public bool timerActive = false;
    public float spawnInterval;
    public float spawnIntervalReset;
    private float spawnIntervalMax;
    private float spawnIntervalMin;
    private float spawnIntervalDecrement;

    private int waveNumber = 0;
    public TMP_Text waveText;
    public float waveTextDuration;

    public int spawnRoom;
    public float spawnRadius;
    public GameObject player;
    public GameObject room1Checker;
    public GameObject room2Checker;
    public GameObject enemySpawnpoint;

    public List<string> waveList;
    public int spawnCount;

    public GameControllerScript gameControllerScript;
    public GameObject enemyObj;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player"); // set player
        room1Checker = GameObject.Find("Room1Checker"); // set room checker
        room2Checker = GameObject.Find("Room2Checker"); // set room checker

        TimeSetter();
    }

    void TimeSetter()
    {
        foreach (TimerStatsScript timer in DataAccessScript.GetTimerList()) // set timer
        {
            if (timer.spawnIntervalMax <= timer.spawnIntervalMin) // in case numbers are funny, default to a reasonable number
            {
                spawnIntervalMax = 10;
                spawnIntervalMin = 5;
            }
            else // set timer values to data values
            {
                spawnIntervalMax = timer.spawnIntervalMax;
                spawnIntervalMin = timer.spawnIntervalMin;
                spawnIntervalDecrement = timer.spawnIntervalDecrement;
            }
        }

        spawnIntervalReset = spawnIntervalMax; // set initial spawn interval
        spawnInterval = spawnIntervalReset; // reset spawn interval
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

            //if (spawnInterval <= 3)  // if 3 seconds to spawn
            //{
            //    waveText.text = "Enemies Spawning in " + spawnInterval.ToString("F2") + "..."; // display countdown text
            //}

            if (spawnInterval <= 0) // if spawn interval is less than or equal to zero
            {
                RoomSelector();

                spawnInterval = spawnIntervalReset; // reset spawn interval

                spawnIntervalReset -= spawnIntervalDecrement; // decrease spawn interval reset value
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

    public void RoomSelector()
    {
        waveNumber++; // increase wave counter
        waveText.text = "Wave " + waveNumber.ToString() + "!"; // display wave text
        StartCoroutine(BlankText());

        switch (spawnRoom)
        {
            case 1:

                enemySpawnpoint = room1Checker;
                foreach (WaveStatsScript wave in DataAccessScript.GetWaveList())
                {
                    if (wave.dungeonId == spawnRoom) // set spawnroom
                    {
                        if (wave.waveNumber == waveNumber) // set wave number
                        {
                            //Debug.Log(wave.dungeonId);
                            SpawnEnemies(wave.enemyName, wave.spawnCount); // spawn enemy
                        }
                    }
                }

            break;

            case 2:

                enemySpawnpoint = room2Checker;
                foreach (WaveStatsScript wave in DataAccessScript.GetWaveList())
                {
                    if (wave.dungeonId == spawnRoom) // set spawnroom
                    {
                        if (wave.waveNumber == waveNumber) // set wave number
                        {
                            //Debug.Log(wave.dungeonId);
                            SpawnEnemies(wave.enemyName, wave.spawnCount); // spawn enemy
                        }
                    }
                }

                break;

            default:

                // no spawn

                break;
        }
    }

    void SpawnEnemies(string enemyName, int spawnCount)
    {
        foreach (EnemyStatsScript enemy in DataAccessScript.GetEnemyList())
        {
            if (enemyName == enemy.enemyName) // if enemy name in wave list matches enemy name in enemy list
            {
                for (int i = 0; i < spawnCount; i++) // loop based on spawn count
                {
                    GameObject enemyObject = Instantiate(enemyObj, Random.insideUnitSphere * spawnRadius + enemySpawnpoint.transform.position, enemySpawnpoint.transform.rotation); // instantiate enemy in a radius around room center
                    enemyObject.name = enemy.enemyName;
                    enemyObject.GetComponent<EnemyHealthScript>().enemyName = enemy.enemyName;
                    AssetManagerScript.LoadSprite(enemy.enemySprite + ".png", (Sprite s) =>
                    {
                        enemyObject.GetComponent<SpriteRenderer>().sprite = s;
                    });
                    enemyObject.GetComponent<EnemyHealthScript>().enemyHealth = enemy.enemyHealth;
                    enemyObject.GetComponent<EnemyMoveScript>().enemySpeed = enemy.enemySpeed;
                    enemyObject.GetComponent<EnemyAttackScript>().enemyDamage = enemy.enemyDamage;
                    enemyObject.GetComponent<EnemyAttackScript>().projectileSpeed = enemy.projectileSpeed;
                    enemyObject.GetComponent<EnemyAttackScript>().projectileDamage = enemy.projectileDamage;
                    enemyObject.GetComponent<EnemyAttackScript>().despawnTime = enemy.despawnTime;
                    enemyObject.GetComponent<EnemyMoveScript>().aggroDistance = enemy.aggroDistance;
                    enemyObject.GetComponent<EnemyMoveScript>().attackDistance = enemy.attackDistance;
                    enemyObject.GetComponent<EnemyAttackScript>().attackDistance = enemy.attackDistance;
                    enemyObject.GetComponent<EnemyMoveScript>().retreatDistance = enemy.retreatDistance;
                    enemyObject.GetComponent<EnemyHealthScript>().enemyGold = enemy.enemyGold;
                    enemyObject.GetComponent<EnemyHealthScript>().enemyXp = enemy.enemyXp;
                    enemyObject.GetComponent<EnemyMoveScript>().isRanged = enemy.isRanged;
                    enemyObject.GetComponent<EnemyAttackScript>().isRanged = enemy.isRanged;
                }
            }
        }
    }

    IEnumerator BlankText()
    {
        yield return new WaitForSeconds(waveTextDuration);
        waveText.text = " "; // display level up
    }
}
