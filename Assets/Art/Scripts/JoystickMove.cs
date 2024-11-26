using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMovement : MonoBehaviour
{
    public Joystick movementJoystick;
    public float playerSpeed;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float checkRadius = 0.2f;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private bool isGrounded;

    private void Awake()
    {
        if (FindObjectsOfType<CharacterMovement>().Length > 1)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (movementJoystick != null)
        {
            movementJoystick.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Joystick reference is missing!");
        }
    }

    private void FixedUpdate() 
    {
        CheckGround();

        if (rb != null && movementJoystick != null) 
        {
            float moveX = movementJoystick.Direction.x;

            if (isGrounded)
            {
                rb.velocity = new Vector2(moveX * playerSpeed, rb.velocity.y);
            }

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

    private void CheckGround()
    {
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

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        rb.gravityScale = isGrounded ? 1 : 3;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
    }
}