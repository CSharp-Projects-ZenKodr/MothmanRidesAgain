using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovment : MonoBehaviour
{
    public float movementSpeed;
    public int slopeSpeed = 10;
    public float jumpForce = 20f;
    
    private float inputX; // Movement on the x-axis

    public Rigidbody2D rb;
    public Animator anim;
    public Transform feet;

    private ScoreController scoreController;
    private InputQueue inputController;

    public LayerMask groundLayers;


    // Start is called before the first frame update
    void Awake()
    {
        scoreController = GameObject.Find("ScoreDisplay").GetComponent<ScoreController>();
        inputController = GetComponent<InputQueue>();
    }

    // Update is called once per frame
    void Update()
    {
        // check if player can jump/trick
        if (isGrounded())
        {
            // does player intend to jump
            if (Input.GetButtonDown("Jump"))
            {
                bool shortHop = false;
                bool isTricking = false;
                // does player intend to short-jump (left-shift pressed)
                if (inputController.getKey(KeyCode.LeftShift) > 0)
                {
                    shortHop = true;
                }
                // does player intend to kickflip (K pressed twice)
                if (inputController.getKey(KeyCode.K) >= 2)
                {
                    shortHop = true;
                    isTricking = true;
                    anim.SetTrigger("doKickflip");
                    scoreController.trick(120, "Kickflip + 120");
                }
                // does player intend to 360 flip (J, K, L pressed once each)
                if (inputController.getKey(KeyCode.J) == 1 && inputController.getKey(KeyCode.K) == 1 && inputController.getKey(KeyCode.L) == 1)
                {
                    shortHop = true;
                    isTricking = true;
                    anim.SetTrigger("do360Flip");
                    scoreController.trick(360, "360 Flip + 360");
                }

                if (isTricking)
                    isTricking = false;
                else
                    anim.SetTrigger("doJump");

                jump(shortHop);
                inputController.emptyQueue();
            }
        }

        anim.SetBool("isCrashed", isCrashed());
        anim.SetBool("isGrounded", isGrounded());

        inputX = Input.GetAxisRaw("Horizontal");
        if (inputX > 0f)
            transform.localScale = new Vector3(2f, 2f, 2f);
        else if (inputX < 0f)
            transform.localScale = new Vector3(-2f, 2f, 2f);
    }

    private void FixedUpdate()
    {
        // Add movement vector
        Vector2 mx = new Vector2(inputX * movementSpeed, 0);
        rb.AddForce(mx);
    }

    private void jump(bool reducedForce = false)
    {
        // Add jump vector
        Vector2 my;
        if (reducedForce)
            my = new Vector2(0, jumpForce*.75f);
        else
            my = new Vector2(0, jumpForce);

        rb.AddForce(my, ForceMode2D.Impulse);
    }

    public bool isGrounded()
    {
        // Check for collision with objects in Ground layer
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.5f, groundLayers);

        if (groundCheck != null)
            return true;
        else
            return false;
    }

    private bool isCrashed()
    {
        if (PlayerDeath.instance.crash == true)
            return true;
        else
            return false;
    }
}
