using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalShootScript : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce;
    public float fireRate;
    public float nextShot;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) // pew pew when mouse left click is held
        {
            NormalShot(); // pew pew
        }
    }

    void NormalShot()
    {
        GameObject newBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); // create bullet
        newBullet.GetComponent<Rigidbody2D>().velocity = transform.right * bulletForce; // bullet go pew
    }
}
