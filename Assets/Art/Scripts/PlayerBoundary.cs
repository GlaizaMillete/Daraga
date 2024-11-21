using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoundary : MonoBehaviour
{
    public BoxCollider2D boundaryCollider; // The collider defining the scene's playable area
    private Rigidbody2D rb;
    private Vector2 boundaryMin;
    private Vector2 boundaryMax;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Get the bounds of the collider defining the boundary area
        boundaryMin = boundaryCollider.bounds.min;
        boundaryMax = boundaryCollider.bounds.max;
    }

    void FixedUpdate()
    {
        // Clamp the player's position to be within the boundary
        Vector2 clampedPosition = new Vector2(
            Mathf.Clamp(rb.position.x, boundaryMin.x, boundaryMax.x),
            Mathf.Clamp(rb.position.y, boundaryMin.y, boundaryMax.y)
        );

        // Apply the clamped position
        rb.position = clampedPosition;
    }
}
