using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public float moveSpeed = 5f;

    private bool isWalking;

    void Start()
    {
        // Ensure the character starts idle
        animator.SetBool("isWalking", false);
    }

    private void FixedUpdate()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");

        // Check for zero input to prevent immediate walking
        if (Mathf.Abs(moveInput) > 0f)
        {
            rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
            isWalking = true;
        }
        else
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
            isWalking = false;
        }

        // Set animator parameters
        animator.SetBool("isWalking", isWalking);

        // Flip sprite based on movement direction
        if (moveInput < 0f && transform.localScale.x > 0f)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        else if (moveInput > 0f && transform.localScale.x < 0f)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }



    // body.velocity = new Vector2(xInput, yInput);

    /*if (Mathf.Abs(xInput) > 0)
    {
        body.velocity = new Vector2(xInput * speed, body.velocity.y);
    }

    if (Mathf.Abs(yInput) > 0)
    {
        body.velocity = new Vector2(body.velocity.x, yInput * speed);
    }*/

    //Vector2 direction = new Vector2(xInput, yInput).normalized;
    //body.velocity = direction * speed;
}
