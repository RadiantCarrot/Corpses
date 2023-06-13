using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XpBarScript : MonoBehaviour
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

    public void setMaxXp(int xp)
    {
        slider.maxValue = xp; //set slider max value to max xp value

        fill.color = gradient.Evaluate(0f); // set fill colour to min xp colour
    }

    public void setMinXp(int xp)
    {
        slider.value = xp; // reset slider

        fill.color = gradient.Evaluate(0f); // set fill colour to min xp colour
    }

    public void SetXp(int xp)
    {
        slider.value = xp; // set slider to reflect xp value

        fill.color = gradient.Evaluate(slider.normalizedValue); // set fill colour to gradient colour
    }
}
