using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public Rigidbody2D knife;
    public PhysicsMaterial2D bounce;
    public GameObject player;
    bool hasBroke = false;
    public GameObject hitEffect;
    public float change;
    bool hasBounce = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(!hasBounce)
        {
            bounce.bounciness = 1f;
            hasBounce = true;
        }
        if (collision.collider.name.Contains("Player"))
        {
            Destroy(gameObject);
            yeeting.hasYoted = false;
        }
        else if (collision.collider.name.Contains("slime"))
        {
            Debug.Log(bounce.bounciness);
            bounce.bounciness = bounce.bounciness + change;
        }
        else if (collision.collider.name.Contains("Wall"))
        {
            knife.bodyType = RigidbodyType2D.Static;
        }


        
      
    }
}
