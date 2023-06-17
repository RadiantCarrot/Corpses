using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2AttackScript : MonoBehaviour
{
    public float attackDistance;
    public float attackDelay;
    public bool canAttack = true;
    public int enemy2Damage = 20;

    public Transform followTarget;

    public GameObject enemy2Projectile;
    public float numberOfProjectiles;
    public float projectileSpread;
    public float projectileForce;
    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        followTarget = GameObject.FindGameObjectWithTag("Player").transform; // set followTarget as player's position

        StartCoroutine(AttackDelay());
    }

    // Update is called once per frame
    void Update()
    {
        if (followTarget != null) // if player exists
        {
            if (Vector2.Distance(transform.position, followTarget.position) <= attackDistance) // if player is within attack distance of enemy
            {
                Attack(); // enemy can attack
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackDistance); // draw attack range
    }

    IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(attackDelay);
        canAttack = true;
        StartCoroutine(AttackReset());
    }
    IEnumerator AttackReset()
    {
        yield return new WaitForSeconds(attackDelay);
        canAttack = false;
        StartCoroutine(AttackDelay());
    }

    void Attack()
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

    void OnCollisionEnter2D(Collision2D hitInfo)
    {
        PlayerHealthScript player = hitInfo.gameObject.GetComponent<PlayerHealthScript>(); // check if bullet hits player

        if (hitInfo.gameObject.CompareTag("Player")) // if there is player
        {
            player.TakeDamage(enemy2Damage); // damage player by enemy damage amount
        }
    }
}
