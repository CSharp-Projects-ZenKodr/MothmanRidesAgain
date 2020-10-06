using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public float movementSpeed;
    public int slopeSpeed = 10;
    public Rigidbody2D rb;

    public float jumpForce = 20f;
    public Transform feet;
    public LayerMask groundLayers;

    private float mx; // Movement on the x-axis

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mx = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            jump();
        }
    }

    private void FixedUpdate()
    {
        // Add movement vector
        Vector2 movement = new Vector2(mx * movementSpeed, rb.velocity.y);
        rb.velocity = movement;
    }

    private void jump()
    {
        // Add jump vector
        Vector2 movement = new Vector2(rb.velocity.x, jumpForce);

        rb.velocity = movement;
    }
    
    public bool isGrounded()
    {
        // Check for collision with objects in Ground layer
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.5f, groundLayers);
        
        if (groundCheck != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
