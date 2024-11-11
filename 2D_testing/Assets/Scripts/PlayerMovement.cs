using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Public Vars
    public float moveSpeed = 10f;
    public float jumpForce = 16f;
    public float djForce = 2f;

    // Ground detection
    public LayerMask groundLayer;
    public Transform groundCheck;

    // Private Vars
    private int jumpAmount = 0;
    private Rigidbody2D rb;
    private bool isGrounded;
    private bool wasGrounded = false;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Movement
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if (moveInput > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (moveInput < 0)
        {
            spriteRenderer.flipX = true;
        }

        // Reset counters once when grounded
        if (isGrounded && !wasGrounded)
        {
            ResetdjCounter();
            wasGrounded = true; // Mark as grounded to prevent repeated resets
        }
        else if (!isGrounded)
        {
            wasGrounded = false;
        }

        // Jumping
        if (isGrounded && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)))
        {
            PlayerJump();
        }

        // Double jump
        if (jumpAmount == 1 && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && !isGrounded)
        {
            DoubleJump();
        }
    }

    private void PlayerJump()
    {
        Debug.Log("Jump Triggered");
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        jumpAmount++;
    }

    private void DoubleJump()
    {
        Debug.Log("Double Jump Triggered");
        rb.velocity = new Vector2(rb.velocity.x, djForce);
        jumpAmount++;
    }

    private void ResetdjCounter()
    {
        Debug.Log("Counters reset");
        jumpAmount = 0;
    }

    // Trigger Detection for GroundCheck
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            Debug.Log("Ground detected");
            isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            Debug.Log("Left ground");
            isGrounded = false;
        }
    }
}
