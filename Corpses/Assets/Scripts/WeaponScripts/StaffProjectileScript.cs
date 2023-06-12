using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffProjectileScript : MonoBehaviour
{
    Rigidbody2D rb;

    public int bulletDamage = 20;

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
        Destroy(gameObject); // destroy bullet
    }
}
