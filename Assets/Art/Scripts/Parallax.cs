using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform cameraTransform;  // Reference to the camera's Transform
    public float parallaxEffect;       // Effect intensity (speed multiplier)

    private Vector3 _lastCameraPosition; // Previous camera position

    void Start()
    {
        // Ensure the cameraTransform is assigned before using it
        if (cameraTransform == null)
        {
            Debug.LogError("Camera Transform is not assigned in the Parallax script.");
            return;
        }

        // Initialize the last camera position to the current position
        _lastCameraPosition = cameraTransform.position;
    }

    void Update()
    {
        if (cameraTransform == null) return;

        // Calculate the camera's movement
        Vector3 deltaMovement = cameraTransform.position - _lastCameraPosition;

        // Apply parallax effect
        transform.position += new Vector3(deltaMovement.x * parallaxEffect, deltaMovement.y * parallaxEffect, 0);

        // Update the last camera position
        _lastCameraPosition = cameraTransform.position;
    }
}
