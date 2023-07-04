using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    public List<string> playerList;
    public List<string> weaponList;
    public List<string> enemyList;
    public List<string> waveList;
    public List<string> tierList;
    public List<string> shopItemList;
    public List<string> dialogueList;


    public GameObject playerGFX;


    public GameObject weaponObj;
    public Transform weaponHolder;
    public GameObject initialWeaponPt;
    public Transform initialWeaponPoint;
    public Transform lockedWeapons;


    public GameObject enemyObj;
    public List<GameObject> enemies = new List<GameObject>(); // create new list to store each enemy type


    public GameObject shopObj;
    public GameObject[] shopSpawnpoints;


    // Start is called before the first frame update
    void Start()
    {
        DataManagerScript dataManager = GetComponent <DataManagerScript>(); // assign data manager
        dataManager.LoadRefData(); // load data

        SetPlayer();
        SetWeapon();
        SetTimer();
        SetShop();
        SetDialogue();
    }

    void SetPlayer()
    {
        foreach (PlayerStatsScript player in DataAccessScript.GetPlayerList())
        {
            //AssetManagerScript.LoadSprite(player.playerSprite + ".png", (Sprite s) =>
            //{
            //    playerGFX.GetComponent<SpriteRenderer>().sprite = s;
            //});
        }
    }

    void SetWeapon()
    { 
        foreach (WeaponStatsScript weapon in DataAccessScript.GetWeaponList())
        {
            // Debug.Log($"Testing for {weapon.startEquipped}, and {weapon.weaponName}");

            if (weapon.startEquipped == true) // if weapon starts as equipped
            {
                GameObject weaponObject = Instantiate(weaponObj, initialWeaponPoint.transform); // instantiate weapon at initialWeaponPoint (offset weapon)
                weaponObject.transform.parent = weaponHolder; // assign weapon as child of weaponHolder
                initialWeaponPoint.transform.parent = lockedWeapons; // teleport weapon point away
                Destroy(initialWeaponPt); // destroy weapon point

                weaponObject.GetComponent<WeaponShootScript>().weaponId = weapon.weaponId;
                weaponObject.name = weapon.weaponName;
                //AssetManagerScript.LoadSprite(weapon.weaponSprite + ".png", (Sprite s) =>
                //{
                //    weaponObject.GetComponent<SpriteRenderer>().sprite = s;
                //});
                weaponObject.GetComponent<WeaponShootScript>().attackInterval = weapon.attackInterval;
                weaponObject.GetComponent<WeaponShootScript>().attackType = weapon.attackType;
                weaponObject.GetComponent<WeaponShootScript>().projectileDamage = weapon.projectileDamage;
                weaponObject.GetComponent<WeaponShootScript>().projectileSpeed = weapon.projectileSpeed;
                weaponObject.GetComponent<WeaponShootScript>().projectileType = weapon.projectileType;
                weaponObject.GetComponent<WeaponShootScript>().despawnTime = weapon.despawnTime;
            }

            else
            {
                GameObject weaponObject = Instantiate(weaponObj, lockedWeapons.transform); // instantiate weapon as child of LockedWeapons gameobject

                weaponObject.GetComponent<WeaponShootScript>().weaponId = weapon.weaponId;
                weaponObject.name = weapon.weaponName;
                //AssetManagerScript.LoadSprite(weapon.weaponSprite + ".png", (Sprite s) =>
                //{
                //    weaponObject.GetComponent<SpriteRenderer>().sprite = s;
                //});
                weaponObject.GetComponent<WeaponShootScript>().attackInterval = weapon.attackInterval;
                weaponObject.GetComponent<WeaponShootScript>().attackType = weapon.attackType;
                weaponObject.GetComponent<WeaponShootScript>().projectileDamage = weapon.projectileDamage;
                weaponObject.GetComponent<WeaponShootScript>().projectileSpeed = weapon.projectileSpeed;
                weaponObject.GetComponent<WeaponShootScript>().projectileType = weapon.projectileType;
                weaponObject.GetComponent<WeaponShootScript>().despawnTime = weapon.despawnTime;
            }
        }
    }

    void SetTimer()
    {

    }

    void SetShop()
    {
        shopSpawnpoints = GameObject.FindGameObjectsWithTag("ShopSpawnpoint"); // create array of shop spawnpoints

        List<ShopStatsScript> itemList = DataAccessScript.GetShopItemList(); // create list of shop items based off json data list

        for (int i = 0; i < shopSpawnpoints.Length; i++) // loop through shop item list, up to max spawnpoint count
        {
            //Debug.Log(string.Format("Shop spawn point: {0}, item spawned: {1}", shopSpawnpoints[i].name, itemList[i].weaponName));

            if (i == itemList.Count) // if there are less items than shop spawnpoints
            {
                return; // skip
            }

            GameObject shopObject = Instantiate(shopObj, shopSpawnpoints[i].transform); // instantiate object at spawnpoint corresponding to item order
            shopObject.name = itemList[i].weaponName;
            //AssetManagerScript.LoadSprite(itemList[i].shopItemSprite + ".png", (Sprite s) =>
            //{
            //    shopObject.GetComponent<SpriteRenderer>().sprite = s;
            //});
            shopObject.GetComponent<ItemDisplayScript>().unlockLevel = itemList[i].unlockLevel;
            shopObject.GetComponent<ItemDisplayScript>().goldRequirement = itemList[i].goldRequirement;
        }
    }

    void SetDialogue()
    {

    }
}
