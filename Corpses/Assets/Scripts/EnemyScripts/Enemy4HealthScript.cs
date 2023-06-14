using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4HealthScript : MonoBehaviour
{
    public int health;

    public XpScript xpScript;
    public int baseXp;
    private int xpBuffer;

    public GameObject gold;
    private float goldRadius = 1f;
    private int dropRate;
    public int goldAmount;

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
            GiveXp();
            GiveGold();

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
        for (var i = 0; i < goldAmount; i++) // check amount of gold to spawn
        {
            Instantiate(gold, Random.insideUnitSphere * goldRadius + transform.position, transform.rotation); // spawn gold in a radius around self
        }
    }
}
