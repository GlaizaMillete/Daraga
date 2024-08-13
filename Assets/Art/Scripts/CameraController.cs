using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform; // Reference to the player's Transform
    public Vector3 offset;            // Offset between the camera and player
    public float smoothSpeed = 0.125f; // Adjust this value to change the camera follow speed

    private void LateUpdate()
    {
        // Smoothly follow the player with the offset
        Vector3 desiredPosition = playerTransform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = new Vector3(smoothedPosition.x, transform.position.y, transform.position.z);
    }
}
