using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yeeting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public static bool hasYoted = false;
    public float bulletForce = 20f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && hasYoted == false)
        {
            yeet();
            hasYoted = true;
        }
    }

    void yeet()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

    }
}
