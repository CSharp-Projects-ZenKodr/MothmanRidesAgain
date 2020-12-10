using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 2f;
    public Rigidbody2D rb;
    public LayerMask groundLayers;

    public Transform groundCheck;
    bool isfacingRight = true;

    float previousPosition;
    RaycastHit2D down;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        down = Physics2D.Raycast(groundCheck.position, -transform.up, 2f, groundLayers);

    }

    private void FixedUpdate()
    {
        if (down.collider != false)
        {
            if (isfacingRight)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
        }
        else
        {
            isfacingRight = !isfacingRight;
            transform.localScale = new Vector3(-transform.localScale.x, 1f, 1f);
        }

        if(transform.position.x == previousPosition)
        {
            if (isfacingRight)
            {
                transform.SetPositionAndRotation(new Vector3(transform.position.x-1, transform.position.y, transform.position.z),Quaternion.Euler(new Vector3(0,0,0)));
            }
            else
            {
                transform.SetPositionAndRotation(new Vector3(transform.position.x + 1, transform.position.y, transform.position.z), Quaternion.Euler(new Vector3(0, 0, 0)));

            }
            isfacingRight = !isfacingRight;
            transform.localScale = new Vector3(-transform.localScale.x, 1f, 1f);
            
        }
        previousPosition = transform.position.x;


    }
}
