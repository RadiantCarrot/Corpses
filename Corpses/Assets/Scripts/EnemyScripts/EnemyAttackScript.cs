using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackScript : MonoBehaviour
{
    // common parameters
    public Transform followTarget;

    public float attackDistance;
    public bool canAttack = true;
    public int enemyDamage;

    public bool isRanged;

    // melee parameters
    public GameObject enemyMeleeProjectile;
    private float meleeProjectileCount = 1;
    private float projectileSpread = 0.8f;
    public float projectileForce = 0.1f;
    public Transform firePoint;

    private float meleeTimer;
    private float meleeTimerReset = 1.2f;


    // ranged parameters
    public Transform enemy;
    private float spawnRadius = 3;
    public GameObject enemyRangedProjectile;
    private float rangedProjectileCount = 4;

    private float nextShotTime;
    private float timeBetweenShots = 2;

    // Start is called before the first frame update
    void Start()
    {
        followTarget = GameObject.FindGameObjectWithTag("Player").transform; // set followTarget as player's position
        firePoint = gameObject.transform;

        meleeTimer = meleeTimerReset;
    }

    // Update is called once per frame
    void Update()
    {
        meleeTimer -= Time.deltaTime;

        if (meleeTimer <= 0) 
        {
            if (canAttack == true)
            {
                canAttack = false;
            }
            else if (canAttack == false)
            {
                canAttack = true;
            }
            meleeTimer = meleeTimerReset;
        }

        if (followTarget != null) // if player exists
        {
            if (isRanged == false)
            {
                if (Vector2.Distance(transform.position, followTarget.position) <= attackDistance) // if player is within attack distance of enemy
                {
                    MeleeAttack(); // enemy can attack
                }
            }
            else
            {
                if (Time.time > nextShotTime && Vector2.Distance(transform.position, followTarget.position) <= attackDistance)  // if projectile is off cooldown and player is within range
                {
                    nextShotTime = Time.time + timeBetweenShots; // chill for a bit before creating more projectiles
                    RangedAttack(); // shoot projectile
                }
            }
        }
    }

    void MeleeAttack()
    {
        if (canAttack == true)
        {
            for (int i = 0; i < meleeProjectileCount; i++) // shoot multiple projectiles
            {
                GameObject newBullet = Instantiate(enemyMeleeProjectile, firePoint.position, firePoint.rotation); // create projectile
                Vector2 dir = followTarget.transform.position - transform.position; // get direction of player
                                                                                    //Vector2 dir = transform.rotation * Vector2.right; // get bullet direction
                Vector2 pdir = Vector2.Perpendicular(dir) * Random.Range(-projectileSpread, projectileSpread); // get projectile spread
                newBullet.GetComponent<Rigidbody2D>().velocity = (dir + pdir) * projectileForce; // projectiles go pew
            }
        }
    }

    void RangedAttack()
    {
        for (int i = 0; i < rangedProjectileCount; i++) // for each projectile
        {
            Instantiate(enemyRangedProjectile, Random.insideUnitSphere * spawnRadius + transform.position, transform.rotation); // instantiate in a radius around self
        }
    }

    void OnCollisionEnter2D(Collision2D hitInfo)
    {
        PlayerHealthScript player = hitInfo.gameObject.GetComponent<PlayerHealthScript>(); // check if bullet hits player

        if (hitInfo.gameObject.CompareTag("Player")) // if there is player
        {
            player.TakeDamage(enemyDamage); // damage player by enemy damage amount
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackDistance); // draw attack range
    }
}
