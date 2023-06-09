using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

// Done by KarLonng

public class Enemy3AttackScript : MonoBehaviour
{
    public float attackDistance;
    public int enemy3Damage = 20;


    public Transform enemy3;
    public float spawnRadius;
    public GameObject enemy3Projectile;
    public float amountOfProjectiles;

    private float nextShotTime;
    public float timeBetweenShots;

    public Transform followTarget;

    // Start is called before the first frame update
    void Start()
    {
        followTarget = GameObject.FindGameObjectWithTag("Player").transform; // set followTarget as player's position
    }

    // Update is called once per frame
    void Update()
    {
        if (followTarget != null) // if player exists
        {
            if (Time.time > nextShotTime && Vector2.Distance(transform.position, followTarget.position) <= attackDistance)  // if projectile is off cooldown and player is within range
            {
                nextShotTime = Time.time + timeBetweenShots; // chill for a bit before creating more projectiles
                Attack(); // shoot projectile
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackDistance); // draw attack range
    }

    void Attack()
    {
        for (int i = 0; i < amountOfProjectiles; i++) // for each projectile
        {
            Instantiate(enemy3Projectile, Random.insideUnitSphere * spawnRadius + transform.position, transform.rotation); // instantiate in a radius around self
        }
    }

    void OnCollisionEnter2D(Collision2D hitInfo)
    {
        PlayerHealthScript player = hitInfo.gameObject.GetComponent<PlayerHealthScript>(); // check if bullet hits player

        if (hitInfo.gameObject.CompareTag("Player")) // if there is player
        {
            player.TakeDamage(enemy3Damage); // damage player by enemy damage amount
        }
    }
}
