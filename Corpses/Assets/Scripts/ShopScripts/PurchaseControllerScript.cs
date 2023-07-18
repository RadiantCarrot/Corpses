using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

// Done by KarLonng

public class PurchaseControllerScript : MonoBehaviour
{
    public XpScript xpScript;
    private int playerLevel;
    public GoldScript goldScript;
    private int goldAmount;

    //private int goldRequirement;
    //private int unlockCost;
    public TMP_Text purchaseText;
    public float textDuration;

    public Transform weaponHolder;
    public GameObject testWeapon;

    public GameObject winPanel;
    public float panelDuration;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) || Input.GetButtonDown("Fire1"))
        {
            winPanel.SetActive(false);
        }
    }

    public void BuyWeapon(string weaponName, int unlockLevel, int goldRequirement)
    {
        //Debug.Log(weaponName);

        playerLevel = xpScript.playerLevel; // get player level
        goldAmount = goldScript.currentGold; // get player gold amount

        GameObject[] weapons = GameObject.FindGameObjectsWithTag("Weapon"); // create array of weapons

        foreach (GameObject weapon in weapons) // loop through each weapon in the array
        {
            if (weapon.name == weaponName) // if weapon being purchased has same name as one of the weapons in the array
            {
                if (playerLevel >= unlockLevel) // if player level is greater than / equal to unlock level
                {
                    if (goldAmount >= goldRequirement) // if player gold is greater than / equal to unlock cost
                    {
                        purchaseText.text = "Item Purchased!"; // display purchase text
                        StartCoroutine(BlankText());

                        goldScript.SubtractGold(goldRequirement); // subtract gold

                        weapon.transform.parent = weaponHolder; // assign weapon as child of weaponHolder (player held "inventory")
                        weaponHolder.transform.rotation = Quaternion.Euler(0f, 0f, 90f); // reset weaponholder rotation
                        weapon.transform.rotation = Quaternion.Euler(0f, 0f, 90f); // reset weapon rotation to align with weapon holder
                        weapon.transform.localPosition = new Vector3(0.75f, 0, 0); // reset weapon position
                        weapon.SetActive(false); // deactivate weapon

                        GameObject[] shopWeapons = GameObject.FindGameObjectsWithTag("ShopWeapon"); // create array of shop weapons

                        foreach (GameObject shopWeapon in shopWeapons) // loop through each weapon in the array
                        {
                            if (shopWeapon.name == weaponName) // if shop weapon matches weapon being purchased
                            {
                                Destroy(shopWeapon); // destroy weapon on display
                            }
                        }

                        if (weapon.name == "Spell Book") // if player has purchased spell book
                        {
                            winPanel.SetActive(true); // display player win panel
                            FindObjectOfType<AudioManager>().Play("GoodGameOver");
                        }
                    }

                    else // if player does not have enough gold
                    {
                        purchaseText.text = "Not Enough Gold :("; // display purchase text
                        StartCoroutine(BlankText());
                    }
                }

                else // if player level is lesser than unlock level
                {
                    purchaseText.text = "Level Requirement Not Met :("; // display purchase text
                    StartCoroutine(BlankText());
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
