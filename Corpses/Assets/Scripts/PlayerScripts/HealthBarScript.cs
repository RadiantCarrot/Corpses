using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setMaxHealth(int health)
    {
        slider.maxValue = health; //set slider max value to max health value
        slider.value = health;

        fill.color = gradient.Evaluate(1f); // set fill colour to max health colour
    }

    public void SetHealth(int health)
    {
        slider.value = health; // set slider to reflect health value

        fill.color = gradient.Evaluate(slider.normalizedValue); // set fill colour to gradient colour
    }
}
