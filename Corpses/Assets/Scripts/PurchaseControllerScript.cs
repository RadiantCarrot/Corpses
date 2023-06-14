using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PurchaseControllerScript : MonoBehaviour
{
    public XpScript xpScript;
    private int playerLevel;
    public GoldScript goldScript;
    private int goldAmount;

    private int unlockLevel;
    private int unlockCost;
    public TMP_Text purchaseText;
    public float textDuration;

    public Transform weaponHolder;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void AddWeapon()
    {

    }

    public void BuyWeapon(string weaponName)
    {
        Debug.Log("Buying" + weaponName);
        playerLevel = xpScript.playerLevel; // get player level
        Debug.Log(xpScript.playerLevel);
        goldAmount = goldScript.currentGold; // get player gold amount
        Debug.Log(goldScript.currentGold);

        GameObject[] weapons = GameObject.FindGameObjectsWithTag("Weapon"); // create array of weapons
        for (int i = 0; i < weapons.Length; i++)
        {
            Debug.Log(weapons[i]);
        }

        foreach (GameObject weapon in weapons) // loop through each weapon in the array
        {
            if (weaponName == weapon.name) // if weapon being purchased has same name as one of the weapons in the array
            {
                Debug.Log("kek");

                unlockLevel = weapon.GetComponent<ItemDisplayScript>().unlockLevel; // get weapon unlock level
                unlockCost = weapon.GetComponent<ItemDisplayScript>().goldRequirement; // get weapon unlock cost

                if (playerLevel >= unlockLevel) // if player level is greater than / equal to unlock level
                {
                    if (goldAmount >= unlockCost) // if player gold is greater than / equal to unlock cost
                    {
                        purchaseText.text = "Item Purchased!"; // display purchase text
                        StartCoroutine(BlankText());

                        goldScript.SubtractGold(unlockCost); // subtract gold
                        weapon.GetComponent<ItemDisplayScript>().weaponPurchased = true;

                        weapon.transform.parent = weaponHolder; // assign weapon as child of weaponHolder (player held "inventory")
                        weapon.transform.localPosition = Vector3.zero; // or new Vector3(0, 0, 0)
                    }

                    else // if player does not have enough gold
                    {
                        purchaseText.text = "Not Enough Gold :("; // display purchase text
                    }
                }

                else // if player level is lesser than unlock level
                {
                    purchaseText.text = "Level Requirement Not Met :("; // display purchase text
                }
            }
        }
    }

    IEnumerator BlankText()
    {
        yield return new WaitForSeconds(textDuration);
        purchaseText.text = ""; // blank out text
    }
}
