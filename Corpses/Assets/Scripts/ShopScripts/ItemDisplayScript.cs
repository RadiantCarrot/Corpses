using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemDisplayScript : MonoBehaviour
{
    public string itemName;
    public Sprite itemSprite;
    private int unlockLevel;
    private int goldRequirement;

    public GameObject shopCanvas;
    public bool playerInRange = false;
    public TMP_Text nameText;
    public TMP_Text levelText;
    public TMP_Text goldText;

    public PurchaseControllerScript purchaseControllerScript;
    public bool weaponPurchased = false;

    public WeaponStatsScript weaponStatsScript;

    // Start is called before the first frame update
    void Start()
    {
        nameText = GameObject.Find("ItemNameText").GetComponent<TextMeshProUGUI>(); // assign text
        levelText = GameObject.Find("ItemLevelText").GetComponent<TextMeshProUGUI>(); // assign text
        goldText = GameObject.Find("ItemGoldText").GetComponent<TextMeshProUGUI>(); // assign text
         
        purchaseControllerScript = GameObject.Find("ShopController").GetComponent<PurchaseControllerScript>(); // assign purchase script
        weaponStatsScript = GameObject.Find("WeaponHolder").GetComponent<WeaponStatsScript>(); // assign weapons stats script

        unlockLevel = weaponStatsScript.unlockLevel;
        goldRequirement = weaponStatsScript.goldRequirement;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange == true) // if player is in range
        {
            if (Input.GetKeyDown(KeyCode.E)) // when player presses E
            {
                purchaseControllerScript.BuyWeapon(itemName); // signal intention to buy weapon
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) // if there is player
        {
            playerInRange = true;

            nameText.text = itemName; // display object name
            levelText.text = "Level " + unlockLevel.ToString() + " Weapon"; // display level requirement
            goldText.text = goldRequirement.ToString() + " Gold Required"; // display object gold requirement
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) // if there is player
        {
            playerInRange = false;

            nameText.text = ""; // display object name
            levelText.text = ""; // display level requirement
            goldText.text = ""; // display object gold requirement
        }
    }
}
