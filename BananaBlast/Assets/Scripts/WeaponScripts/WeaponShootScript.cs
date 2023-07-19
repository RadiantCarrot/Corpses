using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Done by KarLonng

public class WeaponShootScript : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject bulletBouncyPrefab;

    public string weaponId;
    public string weaponName;
    public Sprite weaponSprite;
    public float attackInterval;
    public string attackType;

    public int projectileDamage;
    public float projectileSpeed;
    public string projectileType;

    public float nextShot;
    public float despawnTime;

    public bool startEquipped;

    public AnalyticsScript analyticsScript;
    public WeaponFreezerScript weaponFreezerScript;


    // Start is called before the first frame update
    void Start()
    {
        analyticsScript = GameObject.Find("EndscreenCanvas").GetComponent<AnalyticsScript>(); // assign analytics script
        weaponFreezerScript = GameObject.Find("WeaponHolder").GetComponent<WeaponFreezerScript>(); // assign freezer script
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent.name == "WeaponHolder") // if weapon is equipped
        {
            if (Time.time >= nextShot) // if shot is off cooldown
            {
                if (weaponFreezerScript.weaponFreeze == false) // if weapon is not frozen
                {
                    if (attackType == "click") // if you click to shoot weapon
                    {
                        if (Input.GetButtonDown("Fire1")) // pew pew when mouse left click is pressed
                        {
                            if (projectileType == "bouncy") // if weapon shoots bouncy projectiles
                            {
                                BouncyShot(); // pew pew
                                nextShot = Time.time + 1f / attackInterval; // this is the delay between shots
                            }
                            else
                            {
                                NormalShot(); // pew pew
                                nextShot = Time.time + 1f / attackInterval; // this is the delay between shots
                            }
                            analyticsScript.BulletCounter(1); // add bullet shot to counter
                        }
                    }
                    else // if you hold to shoot weapon
                    {
                        if (Input.GetMouseButton(0)) // pew pew when mouse left click is pressed
                        {
                            if (projectileType == "bouncy") // if weapon shoots bouncy projectiles
                            {
                                BouncyShot(); // pew pew
                                nextShot = Time.time + 1f / attackInterval; // this is the delay between shots
                            }
                            else
                            {
                                NormalShot(); // pew pew
                                nextShot = Time.time + 1f / attackInterval; // this is the delay between shots
                            }
                            analyticsScript.BulletCounter(1); // add bullet shot to counter
                        }
                    }
                }
            }
        }
    }

    void NormalShot()
    {
        GameObject newBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); // create bullet
        newBullet.GetComponent<Rigidbody2D>().velocity = transform.right * projectileSpeed; // bullet go pew

        newBullet.GetComponent<WandProjectileScript>().bulletDamage = projectileDamage; // set projectile damage
        newBullet.GetComponent<WandProjectileScript>().bulletLifetime = despawnTime; // set projectile lifetime
    }
    void BouncyShot()
    {
        GameObject newBullet = Instantiate(bulletBouncyPrefab, firePoint.position, firePoint.rotation); // create bullet
        newBullet.GetComponent<Rigidbody2D>().velocity = transform.right * projectileSpeed; // bullet go pew

        newBullet.GetComponentInChildren<StaffProjectileScript2>().bulletDamage = projectileDamage; // set projectile damage
        newBullet.GetComponent<StaffProjectileScript>().bulletLifetime = despawnTime; // set projectile lifetime
    }
}
