using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4HealthScript : MonoBehaviour
{
    public int health = 400;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health < 0)
        {
            Destroy(gameObject);
        }
    }
}