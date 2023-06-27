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
            if (weapon.startEquipped)
            {
                // instantiate weapon as child of WeaponHolder gameobject
                GameObject weaponObject = Instantiate(weaponObj, weaponHolder.transform);
                weaponObject.name = weapon.weaponName;
                // weaponObject.GetComponent<WeaponReferenceScript>().weaponSprite = weapon.weaponSprite;
                weaponObject.GetComponent<WeaponReferenceScript>().attackInterval = weapon.attackInterval;
                weaponObject.GetComponent<WeaponReferenceScript>().projectileDamage = weapon.projectileDamage;
                weaponObject.GetComponent<WeaponReferenceScript>().projectileSpeed = weapon.projectileSpeed;
                weaponObject.GetComponent<WeaponReferenceScript>().despawnTime = weapon.despawnTime;
            }

            else if(!weapon.startEquipped)
            {
                // instantiate weapon as child of LockedWeapons gameobject
                GameObject weaponObject = Instantiate(weaponObj, lockedWeapons.transform) as GameObject;
                weaponObject.name = weapon.weaponName;
                // weaponObject.GetComponent<WeaponReferenceScript>().weaponSprite = weapon.weaponSprite;
                weaponObject.GetComponent<WeaponReferenceScript>().attackInterval = weapon.attackInterval;
                weaponObject.GetComponent<WeaponReferenceScript>().projectileDamage = weapon.projectileDamage;
                weaponObject.GetComponent<WeaponReferenceScript>().projectileSpeed = weapon.projectileSpeed;
                weaponObject.GetComponent<WeaponReferenceScript>().despawnTime = weapon.despawnTime;
                Debug.Log("test2");
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
