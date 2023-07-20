using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Done by KarLonng

public class WeaponRotateScript : MonoBehaviour
{
    public Camera cam;
    public WeaponFreezerScript weaponFreezerScript;

    // Start is called before the first frame update
    void Start()
    {
        cam = FindObjectOfType<Camera>(); // assign camera
        weaponFreezerScript = GameObject.Find("WeaponHolder").GetComponent<WeaponFreezerScript>(); // assign freezer script
    }

    // Update is called once per frame
    void Update()
    {
        if (weaponFreezerScript.weaponFreeze == false) // if weapon is not frozen
        {
            Vector3 lookDir = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position; // get direction of mouse cursor
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg; // point weapon in direction of cursor
            transform.rotation = Quaternion.Euler(0f, 0f, 0f); // reset weaponholder rotation
            transform.rotation = Quaternion.Euler(0f, 0f, angle); // assigns direction to weapon
        }
    }
}
