using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthScript : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBarScript healthBar;

    public GameObject waveText;
    public GameObject endScreenUI;

    public AnalyticsScript analyticsScript;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth; // set health to max
        healthBar.setMaxHealth(maxHealth); // set healthbar to max
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // deduct damage value from current health
        healthBar.SetHealth(currentHealth); // set healthbar to current health

        if (currentHealth <= 0)
        {
            waveText.SetActive(false);
            analyticsScript.SetPlaytime(); // set playtime
            endScreenUI.SetActive(true); // activate endscreen
            Destroy(gameObject); // die
        }
    }
}
