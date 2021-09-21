using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float health = 5f;
    public float bulletForce = 20f;
    public Transform firePoint1;
    public Transform firePoint2;
    public Transform firePoint3;
    public Transform firePoint4;
    public Transform firePoint5;
    public Transform firePoint6;
    public Transform firePoint7;
    public Transform firePoint8;
    public GameObject bulletPrefab;
    private float waitTime = 5f;  //Wait 5 seconds after we do something to do something again
    private float actionTime;  //The next time we do something

    void Start()
    {
        actionTime = Time.time + waitTime;
    }
    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        if (actionTime <= Time.time)
        {
            wave();

            actionTime = Time.time + waitTime;
        }
    }
    void wave()
    {
        shoot(firePoint1);
        shoot(firePoint2);
        shoot(firePoint3);
        shoot(firePoint4);
        shoot(firePoint5);
        shoot(firePoint6);
        shoot(firePoint7);
        shoot(firePoint8);
    }

    void shoot(Transform firePoint)
    {

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name.Contains("knife"))
        {

            health -= 5;
        }
    }
}
