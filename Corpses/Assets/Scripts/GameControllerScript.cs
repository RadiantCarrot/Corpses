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
        foreach (var weapon in DataAccessScript.weaponList)
        {
            if (weapon.startEquipped == true)
            {
                // instantiate weapon as child of WeaponHolder gameobject
                //Instantiate(weapon, weaponHolder.transform) as GameObject;
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
