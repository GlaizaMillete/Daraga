using UnityEngine;

public class PlayerFallPrevention : MonoBehaviour
{
    public LayerMask groundLayer; // Define what is considered ground
    public Transform groundCheck; // Position to check for ground (e.g., player feet)
    public float groundCheckRadius = 0.1f; // Radius of the ground check

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Check if the player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Prevent falling by restricting Y-axis movement when grounded
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Max(rb.velocity.y, 0)); // Prevent falling down when grounded
        }
    }
}
