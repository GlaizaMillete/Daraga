using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public   
 Joystick movementJoystick;
    public float playerSpeed;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private   
 void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();   


        // ... (rest of your code)
    }

    private void FixedUpdate() 
    {
        if (rb != null && movementJoystick != null) 
        {
            float moveX = movementJoystick.Direction.x;
    
            // Set the player's velocity based on the joystick input
            rb.velocity = new Vector2(moveX * playerSpeed, rb.velocity.y);

            // Update the Animator with the movement input
            animator.SetFloat("xVelocity", Mathf.Abs(moveX));

            // Flip the sprite based on movement direction
            if (moveX < 0 && !spriteRenderer.flipX)
            {
                spriteRenderer.flipX = true;
            }
            else if (moveX > 0 && spriteRenderer.flipX)
            {
                spriteRenderer.flipX = false;
            }
        }
    }
}