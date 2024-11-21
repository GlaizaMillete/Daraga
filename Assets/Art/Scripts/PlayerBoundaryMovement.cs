using UnityEngine;

public class PlayerBoundaryMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the player
    private Rigidbody2D rb;
    private Vector2 movement;

    private bool canMoveLeft = true; // Can move left
    private bool canMoveRight = true; // Can move right
    private float horizontalInput;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Get input for movement
        float moveX = Input.GetAxisRaw("Horizontal");

        // Check if we’re at a boundary
        if ((moveX < 0 && !canMoveLeft) || (moveX > 0 && !canMoveRight))
        {
            moveX = 0; // Stop movement in the restricted direction
        }

        // Set movement vector
        movement = new Vector2(moveX * moveSpeed, rb.velocity.y);
    }

    private void FixedUpdate()
    {
        // Apply movement
        rb.velocity = new Vector2(movement.x, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("LeftBoundary"))
        {
            canMoveLeft = false;
        }
        else if (collision.gameObject.CompareTag("RightBoundary"))
        {
            canMoveRight = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("LeftBoundary"))
        {
            canMoveLeft = true;
        }
        else if (collision.gameObject.CompareTag("RightBoundary"))
        {
            canMoveRight = true;
        }
    }
}
