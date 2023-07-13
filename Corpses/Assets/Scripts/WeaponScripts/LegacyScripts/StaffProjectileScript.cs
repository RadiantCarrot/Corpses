using System.Collections;
using System.Collections.Generic;
//using UnityEditor.PackageManager;
using UnityEngine;

// Done by KarLonng

public class StaffProjectileScript : MonoBehaviour
{
    Rigidbody2D rb;
    public int bulletLifetime;

    private Vector2 lastVelocity;
    private float currentSpeed;
    private Vector2 direction;
    public int currentBounces = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        StartCoroutine(Despawn());
    }

    // Update is called once per frame
    void Update()
    {
        if (currentBounces >= 3)
        {
            Destroy(gameObject); // destroy bullet
        }
    }

    private void LateUpdate()
    {
        lastVelocity = rb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentSpeed = lastVelocity.magnitude;
        direction = Vector2.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

        rb.velocity = direction * Mathf.Max(currentSpeed, 0);
        currentBounces++;
    }

    IEnumerator Despawn()
    {
        yield return new WaitForSeconds(bulletLifetime);
        Destroy(gameObject); // destroy bullet
    }
}
