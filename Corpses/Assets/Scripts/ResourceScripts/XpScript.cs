using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using TMPro;

public class XpScript : MonoBehaviour
{
    public int minXp = 0;
    public int maxXp = 100;
    public int currentXp;
    public int xpbuffer;

    public XpBarScript xpBar;

    public int playerLevel = 0;
    public TMP_Text levelText;
    public TMP_Text levelUpText;
    public float levelUpTextDuration;

    // Start is called before the first frame update
    void Start()
    {
        currentXp = minXp; // set xp to min
        xpBar.setMaxXp(maxXp); // set max xpbar value
        xpBar.setMinXp(minXp); // set min xpbar value
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            AddXp(20);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            playerLevel++;
            levelText.text = "Player Level: " + playerLevel.ToString(); // display current level

            levelUpText.text = "Level Up!"; // display level up
            StartCoroutine(BlankText());
        }
    }

    public void AddXp(int xp)
    {
        currentXp += xp; // add xp value to current xp
        xpBar.SetXp(currentXp); // set xpbar to current xp

        if (currentXp >= maxXp) // if xp is filled
        {
            playerLevel++; // player levels up

            levelText.text = "Player Level: " + playerLevel.ToString(); // display current level

            levelUpText.text = "Level Up!"; // display level up
            StartCoroutine(BlankText());

            xpbuffer = maxXp / 3;
            maxXp = maxXp * 2 - xpbuffer; // new max xp required for next level up

            xpBar.setMaxXp(maxXp); // set max xpbar value
            xpBar.setMinXp(minXp); // set min xpbar value
            currentXp = 0; // reset xp level
        }
    }

    IEnumerator BlankText ()
    {
        yield return new WaitForSeconds(levelUpTextDuration);
        levelUpText.text = " "; // display level up
    }
}
