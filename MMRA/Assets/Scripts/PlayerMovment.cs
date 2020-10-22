using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public float movementSpeed;
    public int slopeSpeed = 10;
    public Rigidbody2D rb;

    public Animator anim;

    public float jumpForce = 20f;
    public Transform feet;
    public LayerMask groundLayers;
    

    private float inputX; // Movement on the x-axis

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            jump();
        }

        anim.SetBool("isGrounded", isGrounded());

        if (inputX > 0f)
            transform.localScale = new Vector3(2f, 2f, 2f);
        else if (inputX < 0f)
            transform.localScale = new Vector3(-2f, 2f, 2f);
    }

    private void FixedUpdate()
    {
        // Add movement vector
       /* if (isGrounded())
        {
            rb.gravityScale = 30;
        }
        else
            rb.gravityScale = 10;*/
        Vector2 mx = new Vector2(inputX * movementSpeed, 0);
        rb.AddForce(mx);

    }

    private void jump()
    {
        // Add jump vector
        //rb.gravityScale = 10;
        Vector2 my = new Vector2(0, jumpForce);
        rb.AddForce(my, ForceMode2D.Impulse);
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