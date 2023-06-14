using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GoldScript : MonoBehaviour
{
    public int minGold = 0;
    public int currentGold;

    public TMP_Text goldText;

    // Start is called before the first frame update
    void Start()
    {
        currentGold = minGold; // set gold to min
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            AddGold(20);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            AddGold(200);
        }
    }

    public void AddGold(int gold)
    {
        currentGold += gold; // add gold value to current gold
        goldText.text = "Gold: " + currentGold.ToString(); // display current gold
    }

    public void SubtractGold(int gold)
    {
        currentGold -= gold; // subtract gold value from current gold
        goldText.text = "Gold: " + currentGold.ToString(); // display current gold
    }
}
