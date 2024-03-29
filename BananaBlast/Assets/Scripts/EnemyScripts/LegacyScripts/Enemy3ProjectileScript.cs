using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Done by KarLonng

public class Enemy3ProjectileScript : MonoBehaviour
{
    public GameObject player;
    Rigidbody2D rb;

    public float spawnDelay;
    public float bulletForce;
    public int bulletDamage;

    public float bulletLifetime;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player"); // set position of player

        StartCoroutine(SpawnDelay());
        StartCoroutine(Despawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnDelay()
    {
        yield return new WaitForSeconds(spawnDelay);
        Fly();
    }

    void Fly()
    {
        if (player != null) // if player exists
        {
            Vector3 dir = player.transform.position - transform.position; // get direction of player
            rb.velocity = new Vector2(dir.x, dir.y).normalized * bulletForce; // shoot bullet towards direction of player
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg; // point bullet in direction of player
            transform.rotation = Quaternion.Euler(0f, 0f, angle); // set bullet rotation to face player
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerHealthScript player = hitInfo.GetComponent<PlayerHealthScript>(); // check if bullet hits player
        if (player != null) // if you hit a player
        {
            player.TakeDamage(bulletDamage); // damage player by damage amount
        }

        Destroy(gameObject); // destroy bullet
    }

    IEnumerator Despawn()
    {
        yield return new WaitForSeconds (bulletLifetime);
        Destroy(gameObject); // destroy bullet
    } 
}
