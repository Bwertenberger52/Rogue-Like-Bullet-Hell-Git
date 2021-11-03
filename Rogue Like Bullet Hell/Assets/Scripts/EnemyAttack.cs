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
    public Rigidbody2D playerPos;
    
    private float waitTimeLong = 5f;  //Wait 5 seconds after we do something to do something again
    private float waitTimeShort = 2f;  //Wait 5 seconds after we do something to do something again
    
    private float actionTimeShort;  //The next time we do something
    private float actionTimeLong;  //The next time we do something

    void Start()
    {
        actionTimeShort = Time.time + waitTimeShort;
        actionTimeLong = Time.time + waitTimeLong;
    }
    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        if (actionTimeShort <= Time.time && gameObject.name.Contains("Waver"))
        {
            wave();

            actionTimeShort = Time.time + waitTimeShort;
        }
        else if (actionTimeShort <= Time.time && gameObject.name.Contains("Peashooter"))
        {
            pea();

            actionTimeShort = Time.time + waitTimeShort;
        }        
        else if (actionTimeLong <= Time.time && gameObject.name.Contains("Sniper"))
        {
            snipe();

            actionTimeLong = Time.time + waitTimeLong;
        }

    }

    void pea()
    {
        shoot(firePoint3);
    }

    void snipe()
    {
        
        Vector2 shootDir = playerPos.position - gameObject.GetComponent<Rigidbody2D>().position;
        float angle = Mathf.Atan2(shootDir.y, shootDir.x) * Mathf.Rad2Deg;
        gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(0,0,angle + 90);
        shoot(firePoint3);
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
