using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    public JoystickMove joystick; // Reference to the Joystick component
    private Animator animator;
    private Vector2 moveInput;
    private string currentIdle = "idle"; // Track which right-idle state is active
    public Rigidbody2D rb;
    private float Horizontal;

    private void Start()
    {
        animator = GetComponent<Animator>();
     
    }

    private void Update()
    {
        HandleMovement();
        HandleAnimation();
    }

    private void HandleMovement()
    {
        // Get input from the joystick
        moveInput = new Vector2(joystick.Horizontal, 0f);

        // Determine direction and update the current idle state
        if (moveInput.x < 0)
        {
            currentIdle = "left-idle"; // Moving left, set idle to left
        }
        else if (moveInput.x > 0)
        {
            currentIdle = "idle"; // Moving right, set idle to right
        }

        // Determine direction and update the current idle state (same as before)

        // Calculate movement direction
        float forwardSpeed = 3.0f; // Adjust forward speed as needed
        Vector3 movement = new Vector3(moveInput.x, 0f, forwardSpeed);

        // Apply force to the Rigidbody2D
        rb.AddForce(movement * moveSpeed, ForceMode2D.Force);

        Debug.Log("Move Input: " + moveInput);
       // Move the character based on joystick input
        transform.Translate(moveInput * moveSpeed * Time.deltaTime);
    }

    private void HandleAnimation()
    {
        // Set the 'horizontal' parameter based on joystick input
        animator.SetFloat("horizontal", moveInput.x);

        // Check if the character should be idle
        if (moveInput.x == 0)
        {
            animator.Play(currentIdle); // Play the appropriate idle animation
        }
    }

    private void LateUpdate()
    {
        Debug.Log("Camera Position: " + transform.position);
    }
}
