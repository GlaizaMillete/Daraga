using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Joystick joystick; 
    float horizontalInput;
    float moveSpeed = 5f;
    bool isFacingRight = false;

    Rigidbody2D rb;
    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
        horizontalInput = Input.GetAxis("Horizontal");

        
        Debug.Log($"horizontalInput: {horizontalInput}");

       
        FlipSprite();
    }

    private void FixedUpdate()
    {
       
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

      
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
