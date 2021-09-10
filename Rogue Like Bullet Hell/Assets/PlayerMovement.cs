using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    Vector2 movement;
    Vector2 knifeDir;
    // Update is called once per frame
    void Update()
    {
        //input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        knifeDir.x = Input.GetAxis("Mouse X");
        knifeDir.y = Input.GetAxis("Mouse Y");
        
    }

    void FixedUpdate()
    {
        //physics
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
