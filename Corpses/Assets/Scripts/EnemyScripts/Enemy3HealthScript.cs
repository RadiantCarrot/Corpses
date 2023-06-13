using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3HealthScript : MonoBehaviour
{
    public int health;

    public XpScript xpScript;
    public int baseXp;
    private int xpBuffer;

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
            xpScript.AddXp(baseXp); // give player xp
            xpBuffer = (xpScript.playerLevel / 2) * baseXp; // additional xp for scaling
            xpScript.AddXp(xpBuffer); // give player scaling xp

            Destroy(gameObject); //die
        }
    }
}
