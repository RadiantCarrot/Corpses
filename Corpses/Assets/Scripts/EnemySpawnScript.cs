using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{
    public float spawnInterval;
    public float spawnIntervalStart;
    public float spawnIntervalEnd;

    public float spawnRadius;
    public GameObject player;

    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnEnemies(int roomNumber)
    {
        switch (roomNumber)
        {
            case 1:

                // initiate room 1 spawning sequence
                // Instantiate(enemy1, Random.insideUnitSphere * spawnRadius + player.transform.position, player.transform.rotation); // instantiate in a radius around self

                break;

            case 2:

                // initiate room 2 spawning sequence

            break;

            default:

                 // no spawn

            break;
        }
    }
}
