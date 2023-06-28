using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShootScript : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject bulletBouncyPrefab;

    public string weaponId;
    public string weaponName;
    public Sprite weaponSprite;
    public float attackInterval;

    public int projectileDamage;
    public float projectileSpeed;
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
                if (Input.GetButtonDown("Fire1")) // pew pew when mouse left click is pressed
                {
                    if (weaponName == "Wizard Staff")
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
