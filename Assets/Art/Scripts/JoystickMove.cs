using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMove : MonoBehaviour
{
    public Joystick movementJoystick;
    public float playerSpeed;
    private Rigidbody2D rb;
    private   
 Animator animator;
    private SpriteRenderer spriteRenderer;

    private float horizontalInput;
    private   
 bool isFacingRight = true;

    private void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

  private void FixedUpdate()
    {
        if (rb != null && movementJoystick != null)
    {
        horizontalInput = movementJoystick.Direction.x;

        // Set the player's velocity based on the joystick input
        rb.velocity = new Vector2(horizontalInput * playerSpeed, rb.velocity.y);

        // Update the Animator with the movement input
        animator.SetFloat("xVelocity", Mathf.Abs(horizontalInput));

        FlipSprite();
    }
}

    private void FlipSprite()
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
