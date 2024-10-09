using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Joystick movementJoystick;  // Reference to the joystick
    public float playerSpeed;
    public LayerMask groundLayer; // Set this to the "Ground" layer in the Inspector
    public Transform groundCheck; // Empty GameObject at the character's feet
    public float checkRadius = 0.2f; // Radius for ground detection

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private bool isGrounded;

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
        CheckGround(); // Check if the character is grounded

        if (rb != null && movementJoystick != null) 
        {
            float moveX = movementJoystick.Direction.x;

            // Only apply movement if not blocked by a collider and grounded
            if (isGrounded)
            {
                rb.velocity = new Vector2(moveX * playerSpeed, rb.velocity.y); // X-axis movement
            }

            // Update animator parameter for movement
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

    private void CheckGround()
{
    // Ensure groundCheck and rb are not null
    if (groundCheck == null)
    {
        Debug.LogError("groundCheck is not assigned!");
        return;
    }

    if (rb == null)
    {
        Debug.LogError("Rigidbody2D (rb) is not assigned!");
        return;
    }

    // Check if the player is grounded
    isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

    // Apply different gravity based on whether the player is grounded
    if (isGrounded)
    {
        rb.gravityScale = 1; // Regular gravity on the ground
    }
    else
    {
        rb.gravityScale = 3; // Increase gravity when in the air
    }
}


    private void OnDrawGizmosSelected()
    {
        // Draw a circle to visualize the ground check
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
    }
}
