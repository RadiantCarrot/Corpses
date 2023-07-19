using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Done by KarLonng

public class WeaponSwapScript : MonoBehaviour
{
    public int selectedWeapon = 0;

    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        int previousSelectedWeapon = selectedWeapon; // temp variable

        if (Input.GetAxis("Mouse ScrollWheel") < 0f) // if player scrolls down
        {
            if (selectedWeapon >= transform.childCount - 1) // if weapon index reaches max
            {
                selectedWeapon = 0; // loop back to first weapon
            }
            else
            {
                selectedWeapon++; // increase selected weapon index
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // if player scrolls up
        {
            if (selectedWeapon <= 0) // if weapon index reaches min
            {
                selectedWeapon = transform.childCount - 1; // loop back to last weapon
            }
            else
            {
                selectedWeapon--; // decrease selected weapon index
            }
        }

        if (previousSelectedWeapon != selectedWeapon) // swap weapon
        {
            SelectWeapon();
        }
    }

    void SelectWeapon()
    {
        int i = 0; // create index
        foreach (Transform weapon in transform) // loop through each weapon's transform in this weapon holder
        {
            if (i == selectedWeapon) // if index matches selected weapon
            {
                weapon.gameObject.SetActive(true); // set weapon as active
            }
            else
            {
                weapon.gameObject.SetActive(false); // set weapon as inactive
            }

            i++; // increase index by 1
        }
    }
}
