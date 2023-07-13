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

    // Start is called before the first frame update
    void Start()
    {
        analyticsScript = GameObject.Find("EndscreenCanvas").GetComponent<AnalyticsScript>(); // assign analytics script
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent.name == "WeaponHolder")
        {
            if (Time.time >= nextShot)
            {
                if (attackType == "click")
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
                else
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

    void NormalShot()
    {
        GameObject newBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); // create bullet
        newBullet.GetComponent<Rigidbody2D>().velocity = transform.right * projectileSpeed; // bullet go pew
    }
    void BouncyShot()
    {
        GameObject newBullet = Instantiate(bulletBouncyPrefab, firePoint.position, firePoint.rotation); // create bullet
        newBullet.GetComponent<Rigidbody2D>().velocity = transform.right * projectileSpeed; // bullet go pew
    }
}
