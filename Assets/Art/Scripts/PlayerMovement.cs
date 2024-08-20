using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float horizontalInput;
    float moveSpeed = 5f;
    bool isFacingRight = false;
    bool isGrounded = false;

    Rigidbody2D rb;
    Animator animator;

    void Start()
    {
        // Ensure the character starts idle
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        animator.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));

        
    }

    void FlipSprite()
    {
        if (isFacingRight && horizontalInput < 0f || !isFacingRight && horizontalInput > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Set isGrounded to true when the player collides with the ground
        isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Set isGrounded to false when the player leaves the ground
        isGrounded = false;
    }

     /*void Update()
    {
        // Example of using isGrounded to handle jumping
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
        }

        // Get horizontal input from the user
        horizontalInput = Input.GetAxis("Horizontal");
        FlipSprite();
    }*/
}
