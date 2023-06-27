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

    public GameObject weapon;
    public Transform weaponHolder;
    public Transform lockedWeapons;

    // Start is called before the first frame update
    void Start()
    {
        DataManagerScript dataManager = GetComponent <DataManagerScript>(); // assign data manager
        dataManager.LoadRefData(); // load data

        SetWeapon();
    }

    void SetWeapon()
    {
        foreach (WeaponStatsScript weapon in DataAccessScript.GetWeaponList())
        {
            if (weapon.startEquipped == true)
            {
                // instantiate weapon as child of WeaponHolder gameobject
                GameObject weaponObject = Instantiate(GameObject, weaponHolder.transform) as GameObject;
                weaponObject.name = weapon.weaponName;
                weaponObject.sprite = weapon.weaponSprite;
                weaponObject.attackInterval = weapon.attackInterval;
                weaponObject.projectileDamage = weapon.projectileDamage;
                weaponObject.projectileSpeed = weapon.projectileSpeed;
                weaponObject.despawnTime = weapon.despawnTime;
            }
            else
            {
                // instantiate weapon as child of LockedWeapons gameobject
                //Instantiate (weapon, lockedWeapons.transform) as GameObject;
            }
        }
    }

    void SetEnemy()
    {

    }

    void SetShop()
    {

    }

    void SetDialogue()
    {

    }
}
