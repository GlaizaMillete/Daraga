using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Joystick movementJoystick;
    public float playerSpeed;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Ensure the joystick is active at the start
        if (movementJoystick != null)
    {
        movementJoystick.gameObject.SetActive(true);
        Debug.Log("Joystick should be visible");
    }
    else
    {
        Debug.LogWarning("Joystick reference is missing!");
    }
}

    private void FixedUpdate() 
    {
        if (rb != null && movementJoystick != null) 
        {
            float moveX = movementJoystick.Direction.x;

            rb.velocity = new Vector2(moveX * playerSpeed, rb.velocity.y);
            animator.SetFloat("xVelocity", Mathf.Abs(moveX));

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
