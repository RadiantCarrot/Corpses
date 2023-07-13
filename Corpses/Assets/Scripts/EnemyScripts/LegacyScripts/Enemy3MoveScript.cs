using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Done by KarLonng

public class Enemy3MoveScript : MonoBehaviour
{
    public GameObject spawnFlash;

    Rigidbody2D rb;

    public float speed;
    public float aggroDistance;
    public float attackDistance;
    public float retreatDistance;

    public float spawnDuration;
    public Transform followTarget;
    public float targetDir;

    public GameObject enemy3Sprite;
    public bool facingRight;

    // Start is called before the first frame update
    void Start()
    {
        // Instantiate(spawnFlash, transform.position, Quaternion.identity); // create spawn flash effect
        rb = GetComponent<Rigidbody2D>(); // assigns rigidbody to character

        followTarget = GameObject.FindGameObjectWithTag("Player").transform; // set followTarget as player's position
    }

    // Update is called once per frame
    void Update()
    {
        spawnDuration -= Time.deltaTime; // decrease spawn timer

        if (spawnDuration <= 0) // if spawn delay is over
        {
            if (followTarget != null) // if player exists
            {
                if (Vector2.Distance(transform.position, followTarget.position) < aggroDistance) // if player is within enemy aggro distance
                {
                    if (Vector2.Distance(transform.position, followTarget.position) > attackDistance) // if enemy distance from player is greater than shoot distance
                    {
                        transform.position = Vector2.MoveTowards(transform.position, followTarget.position, speed * Time.deltaTime); // enemy moves towards player
                    }

                    else if (Vector2.Distance(transform.position, followTarget.position) < retreatDistance) // if enemy distance from player is lesser than retreat distance
                    {
                        transform.position = Vector2.MoveTowards(transform.position, followTarget.position, -speed * Time.deltaTime); // enemy moves away from player
                    }
                }
            }

            if (followTarget != null) // if player exists
            {
                Vector3 heading = followTarget.position - transform.position; // check for player direction from enemy direction
                targetDir = AngleDir(transform.forward, heading, transform.up); // set direction vector 
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, aggroDistance); // draw aggro range
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, retreatDistance); // draw retreat range
    }

    float AngleDir(Vector3 fwd, Vector3 targetDir, Vector3 up)
    {
        Vector3 perp = Vector3.Cross(fwd, targetDir); // check for axis direction
        float dir = Vector3.Dot(perp, up); // check for the other axis direction

        if (dir > 0f && !facingRight) // if player is to the right and face right check is false, flip
        {
            Flip();
            return 1f; // target is on the right
        }
        else if (dir < 0f && facingRight) // if player is to the left and face right check is true, flip
        {
            Flip();
            return -1f; // target is on the left
        }
        else
        {
            return 0f; // target is straight ahead or behind
        }
    }

    void Flip()
    {
        Vector3 currentScale = enemy3Sprite.transform.localScale; // check direction enemy is facing
        currentScale.x *= -1;
        enemy3Sprite.transform.localScale = currentScale; // flip enemy sprite

        facingRight = !facingRight;
    }
}
