using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandProjectileScript : MonoBehaviour
{
    Rigidbody2D rb;

    public int bulletDamage = 40;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy1HealthScript enemy1 = hitInfo.GetComponent<Enemy1HealthScript>(); // check if bullet hits enemy
        if (enemy1 != null) // if you hit an enemy
        {
            enemy1.TakeDamage(bulletDamage); // damage enemy by bulletdamage amount
        }

        Enemy2HealthScript enemy2 = hitInfo.GetComponent<Enemy2HealthScript>(); // check if bullet hits enemy
        if (enemy2 != null) // if you hit an enemy
        {
            enemy2.TakeDamage(bulletDamage); // damage enemy by bulletdamage amount
        }

        Enemy3HealthScript enemy3 = hitInfo.GetComponent<Enemy3HealthScript>(); // check if bullet hits enemy
        if (enemy3 != null) // if you hit an enemy
        {
            enemy3.TakeDamage(bulletDamage); // damage enemy by bulletdamage amount
        }

        Enemy4HealthScript enemy4 = hitInfo.GetComponent<Enemy4HealthScript>(); // check if bullet hits enemy
        if (enemy4 != null) // if you hit an enemy
        {
            enemy4.TakeDamage(bulletDamage); // damage enemy by bulletdamage amount
        }

        EnemyHealthScript enemy = hitInfo.GetComponent<EnemyHealthScript>(); // check if bullet hits enemy
        if (enemy != null) // if you hit an enemy
        {
            enemy.TakeDamage(bulletDamage); // damage enemy by bulletdamage amount
        }

        Destroy(gameObject); // destroy bullet
    }
}
