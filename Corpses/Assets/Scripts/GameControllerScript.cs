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

    // Start is called before the first frame update
    void Start()
    {
        DataManagerScript dataManager = GetComponent <DataManagerScript>(); // assign data manager
        dataManager.LoadRefData(); // load data

        SetWeapon();
    }

    void SetWeapon()
    {
        //foreach (var weapon in DataAccessScript.GetWeaponList()) {
        //    Debug.Log(weapon.weaponName);
        //}
        
        foreach (WeaponStatsScript weapon in DataAccessScript.GetWeaponList())
        {
            Debug.Log($"Testing for {weapon.startEquipped}, and {weapon.weaponName}");

            if (weapon.startEquipped ==  true) // if weapon starts as equipped
            {
                GameObject weaponObject = Instantiate(weaponObj, initialWeaponPoint.transform); // instantiate weapon at initialWeaponPoint (offset weapon)
                weaponObject.transform.parent = weaponHolder; // assign weapon as child of weaponHolder
                initialWeaponPoint.transform.parent = lockedWeapons; // teleport weapon point away
                Destroy(initialWeaponPt); // destroy weapon point

                weaponObject.name = weapon.weaponName;
                // weaponObject.GetComponent<WeaponShootScript>().weaponSprite = weapon.weaponSprite;
                weaponObject.GetComponent<WeaponShootScript>().attackInterval = weapon.attackInterval;
                weaponObject.GetComponent<WeaponShootScript>().projectileDamage = weapon.projectileDamage;
                weaponObject.GetComponent<WeaponShootScript>().projectileSpeed = weapon.projectileSpeed;
                weaponObject.GetComponent<WeaponShootScript>().despawnTime = weapon.despawnTime;
            }

            else
            {
                GameObject weaponObject = Instantiate(weaponObj, lockedWeapons.transform); // instantiate weapon as child of LockedWeapons gameobject

                weaponObject.name = weapon.weaponName;
                // weaponObject.GetComponent<WeaponShootScript>().weaponSprite = weapon.weaponSprite;
                weaponObject.GetComponent<WeaponShootScript>().attackInterval = weapon.attackInterval;
                weaponObject.GetComponent<WeaponShootScript>().projectileDamage = weapon.projectileDamage;
                weaponObject.GetComponent<WeaponShootScript>().projectileSpeed = weapon.projectileSpeed;
                weaponObject.GetComponent<WeaponShootScript>().despawnTime = weapon.despawnTime;
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
