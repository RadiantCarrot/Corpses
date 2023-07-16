using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Done by KarLonng

public class Enemy2ProjectileScript : MonoBehaviour
{
    public int bulletDamage;
    public float bulletLifetime;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Despawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerHealthScript player = hitInfo.GetComponent<PlayerHealthScript>(); // check if bullet hits player
        if (player != null) // if you hit a player
        {
            player.TakeDamage(bulletDamage); // damage player by creepiedamage amount
        }

        Destroy(gameObject); // destroy bullet
    }

    IEnumerator Despawn()
    {
        yield return new WaitForSeconds(bulletLifetime);
        Destroy(gameObject); // destroy bullet
    }
}
