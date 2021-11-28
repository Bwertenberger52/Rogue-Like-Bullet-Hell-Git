using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yeeting : MonoBehaviour
{
    public Transform firePoint;
    public Transform stabPoint;
    public GameObject bulletPrefab;
    public GameObject stabPrefab;
    public static bool hasYoted = false;
    public float bulletForce = 20f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            stab();
        }
        if (Input.GetButtonDown("Fire1") && hasYoted == false)
        {
            yeet();
            hasYoted = true;
        }
    }

    void stab()
    {
        GameObject shank = Instantiate(stabPrefab, stabPoint.position, stabPoint.rotation);
    }

    void yeet()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

    }
}
