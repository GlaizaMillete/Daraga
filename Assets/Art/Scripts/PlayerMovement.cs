using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Joystick joystick; 
    float horizontalInput;
    float moveSpeed = 5f;
    bool isFacingRight = false;
    bool isGrounded = false;

    Rigidbody2D rb;
    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Capture horizontal input from the user
        horizontalInput = Input.GetAxis("Horizontal");

        // Debug to check the value of horizontalInput
        Debug.Log($"horizontalInput: {horizontalInput}");

        // Flip the sprite if needed
        FlipSprite();
    }

    private void FixedUpdate()
    {
        // Apply horizontal movement to the player
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        // Update animator parameters
        animator.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));

        
    }

    void FlipSprite()
    {
        // If the player is moving left and facing right, or moving right and facing left, flip the sprite
        if (horizontalInput < 0 && isFacingRight || horizontalInput > 0 && !isFacingRight)
        {
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }
}
