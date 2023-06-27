using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1AttackScript : MonoBehaviour
{
    public float attackDistance;
    public int enemy1Damage = 20;

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

    void Attack()
    {

    }

    void OnCollisionEnter2D(Collision2D hitInfo)
    {
        PlayerHealthScript player = hitInfo.gameObject.GetComponent<PlayerHealthScript>(); // check if bullet hits player

        if (hitInfo.gameObject.CompareTag("Player")) // if there is player
        {
            player.TakeDamage(enemy1Damage); // damage player by enemy damage amount
        }
    }
}
