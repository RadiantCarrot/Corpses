using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Done by KarLonng

public class Enemy1HealthScript : MonoBehaviour
{
    public int health;

    public XpScript xpScript;
    public int baseXp;
    private int xpBuffer;

    public GameObject gold;
    private float goldRadius = 1f;
    private int dropRate;
    public int goldAmount;

    public AnalyticsScript analyticsScript;

    // Start is called before the first frame update
    void Start()
    {
        xpScript = GameObject.Find("XpController").GetComponent<XpScript>(); // assign xp script
        analyticsScript = GameObject.Find("EndscreenCanvas").GetComponent<AnalyticsScript>(); // assign analytics script
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
            GiveXp();
            GiveGold();
            analyticsScript.EnemyCounter(1); // add enemy death to counter

            Destroy(gameObject); //die
        }
    }

    public void GiveXp()
    {
        xpScript.AddXp(baseXp); // give player xp
        xpBuffer = (xpScript.playerLevel / 2) * baseXp; // additional xp for scaling
        xpScript.AddXp(xpBuffer); // give player scaling xp
    }

    public void GiveGold()
    {
        dropRate = Random.Range(0, 2); // return random number within range

        if (dropRate == 1) // if gold can spawn
        {
            for (var i = 0; i < goldAmount; i++) // check amount of gold to spawn
            {
                Instantiate(gold, Random.insideUnitSphere * goldRadius + transform.position, transform.rotation); // spawn gold in a radius around self
            }
        }
    }
}
