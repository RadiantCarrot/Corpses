using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    public List<string> weaponList;
    public List<string> enemyList;
    public List<string> shopItemList;
    public List<string> dialogueList;


    public GameObject weaponObj;
    public Transform weaponHolder;
    public GameObject initialWeaponPt;
    public Transform initialWeaponPoint;
    public Transform lockedWeapons;


    public GameObject shopObj;
    public GameObject[] shopSpawnpoints;


    // Start is called before the first frame update
    void Start()
    {
        DataManagerScript dataManager = GetComponent <DataManagerScript>(); // assign data manager
        dataManager.LoadRefData(); // load data

        SetWeapon();
        SetShop();
    }

    void SetWeapon()
    { 
        foreach (WeaponStatsScript weapon in DataAccessScript.GetWeaponList())
        {
            // Debug.Log($"Testing for {weapon.startEquipped}, and {weapon.weaponName}");

            if (weapon.startEquipped ==  true) // if weapon starts as equipped
            {
                GameObject weaponObject = Instantiate(weaponObj, initialWeaponPoint.transform); // instantiate weapon at initialWeaponPoint (offset weapon)
                weaponObject.transform.parent = weaponHolder; // assign weapon as child of weaponHolder
                initialWeaponPoint.transform.parent = lockedWeapons; // teleport weapon point away
                Destroy(initialWeaponPt); // destroy weapon point

                weaponObject.GetComponent<WeaponShootScript>().weaponId = weapon.weaponId;
                weaponObject.name = weapon.weaponName;
                // weaponObject.GetComponent<WeaponShootScript>().weaponSprite = weapon.weaponSprite;
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
                // weaponObject.GetComponent<WeaponShootScript>().weaponSprite = weapon.weaponSprite;
                weaponObject.GetComponent<WeaponShootScript>().attackInterval = weapon.attackInterval;
                weaponObject.GetComponent<WeaponShootScript>().attackType = weapon.attackType;
                weaponObject.GetComponent<WeaponShootScript>().projectileDamage = weapon.projectileDamage;
                weaponObject.GetComponent<WeaponShootScript>().projectileSpeed = weapon.projectileSpeed;
                weaponObject.GetComponent<WeaponShootScript>().projectileType = weapon.projectileType;
                weaponObject.GetComponent<WeaponShootScript>().despawnTime = weapon.despawnTime;
            }
        }
    }

    void SetEnemy()
    {

    }

    void SetShop()
    {
        shopSpawnpoints = GameObject.FindGameObjectsWithTag("ShopSpawnpoint"); // create array of shop spawnpoints

        List<ShopStatsScript> itemList = DataAccessScript.GetShopItemList(); // for each shop item in shop item list

        for (int i = 0; i < shopSpawnpoints.Length; i++) //loop through spawnpoints
        {
            //Debug.Log(string.Format("Shop spawn point: {0}, item spawned: {1}", shopSpawnpoints[i].name, itemList[i].weaponName));

            if (i == itemList.Count) // if there are less items than shop spawnpoints
            {
                return; // skip
            }

            GameObject shopObject = Instantiate(shopObj, shopSpawnpoints[i].transform); // instantiate object at spawnpoint corresponding to item order
            shopObject.name = itemList[i].weaponName;
            shopObject.GetComponent<ItemDisplayScript>().unlockLevel = itemList[i].unlockLevel;
            shopObject.GetComponent<ItemDisplayScript>().goldRequirement = itemList[i].goldRequirement;
        }
    }

    void SetDialogue()
    {

    }
}
