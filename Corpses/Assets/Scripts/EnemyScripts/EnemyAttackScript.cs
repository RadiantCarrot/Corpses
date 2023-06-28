using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackScript : MonoBehaviour
{
    // common parameters
    public Transform followTarget;

    public float attackDistance;
    public float attackDelay;
    public bool canAttack = true;
    public int enemyDamage;

    public bool isRanged;

    // melee parameters
    public GameObject enemy2Projectile;
    public float numberOfProjectiles;
    public float projectileSpread;
    public float projectileForce;
    public Transform firePoint;

    // ranged parameters
    public Transform enemy;
    public float spawnRadius;
    public GameObject enemyProjectile;
    public float amountOfProjectiles;

    private float nextShotTime;
    public float timeBetweenShots;

    // Start is called before the first frame update
    void Start()
    {
        followTarget = GameObject.FindGameObjectWithTag("Player").transform; // set followTarget as player's position

        if (isRanged == false)
        {
            StartCoroutine(MeleeAttackDelay());
        }
    }

    // Update is called once per frame
    void Update()
    {
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
    IEnumerator MeleeAttackDelay()
    {
        yield return new WaitForSeconds(attackDelay);
        canAttack = true;
        StartCoroutine(MeleeAttackReset());
    }
    IEnumerator MeleeAttackReset()
    {
        yield return new WaitForSeconds(attackDelay);
        canAttack = false;
        StartCoroutine(MeleeAttackDelay());
    }

    void MeleeAttack()
    {
        if (canAttack == true)
        {
            for (int i = 0; i < numberOfProjectiles; i++) // shoot multiple projectiles
            {
                GameObject newBullet = Instantiate(enemy2Projectile, firePoint.position, firePoint.rotation); // create projectile
                Vector2 dir = followTarget.transform.position - transform.position; // get direction of player
                                                                                    //Vector2 dir = transform.rotation * Vector2.right; // get bullet direction
                Vector2 pdir = Vector2.Perpendicular(dir) * Random.Range(-projectileSpread, projectileSpread); // get projectile spread
                newBullet.GetComponent<Rigidbody2D>().velocity = (dir + pdir) * projectileForce; // projectiles go pew
            }
        }
    }

    void RangedAttack()
    {
        for (int i = 0; i < amountOfProjectiles; i++) // for each projectile
        {
            Instantiate(enemyProjectile, Random.insideUnitSphere * spawnRadius + transform.position, transform.rotation); // instantiate in a radius around self
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
