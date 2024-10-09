using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    public float moveSpeed = 1f;         // Speed of the fish, lower value for slower speed
    public float leftBoundary = -10f;    // Leftmost position
    public float rightBoundary = 10f;    // Rightmost position
    private bool movingRight = true;     // Direction flag

    void Update()
    {
        // Move the fish in the direction it is facing
        if (movingRight)
        {
            // Move to the right
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

            // If the fish reaches the right boundary, reverse direction
            if (transform.position.x >= rightBoundary)
            {
                movingRight = false;
                Flip(); // Flip the fish to face left
            }
        }
        else
        {
            // Move to the left
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

            // If the fish reaches the left boundary, reverse direction
            if (transform.position.x <= leftBoundary)
            {
                movingRight = true;
                Flip(); // Flip the fish to face right
            }
        }
    }

    // Flip the fish to face the opposite direction
    void Flip()
    {
        Vector3 localScale = transform.localScale;
        
        // Flip the fish by inverting the x scale
        localScale.x *= -1;
        
        // Apply the flipped scale to the fish
        transform.localScale = localScale;
    }
}