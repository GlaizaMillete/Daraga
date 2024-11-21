using UnityEngine;

public class PlayerBoundaryScript : MonoBehaviour
{
    public Camera mainCamera;  // Reference to the camera
    public float padding = 0.1f;  // Padding to prevent the player from touching the camera boundary exactly

    private Rigidbody2D rb;
    private Vector2 minBoundaries;
    private Vector2 maxBoundaries;
    private Vector3 lastCameraPosition;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (mainCamera == null)
        {
            mainCamera = Camera.main;  // Fallback to main camera if not assigned
        }

        if (mainCamera != null)
        {
            lastCameraPosition = mainCamera.transform.position;
            UpdateCameraBoundaries();  // Set initial boundaries
        }
    }

    private void Update()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
            if (mainCamera == null) return;
        }

        // Check if camera position has changed, then update boundaries
        if (mainCamera.transform.position != lastCameraPosition)
        {
            lastCameraPosition = mainCamera.transform.position;
            UpdateCameraBoundaries();
        }

        // Clamp the player's position to stay within the camera bounds
        float clampedX = Mathf.Clamp(transform.position.x, minBoundaries.x, maxBoundaries.x);
        float clampedY = Mathf.Clamp(transform.position.y, minBoundaries.y, maxBoundaries.y);

        // Apply the clamped position to the player's position
        rb.position = new Vector2(clampedX, clampedY);
    }

    private void UpdateCameraBoundaries()
    {
        // Convert camera viewport bounds to world space
        Vector3 cameraBottomLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane));
        Vector3 cameraTopRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, mainCamera.nearClipPlane));

        // Set the player's boundaries based on the camera's world space view
        minBoundaries = new Vector2(cameraBottomLeft.x + padding, cameraBottomLeft.y + padding);
        maxBoundaries = new Vector2(cameraTopRight.x - padding, cameraTopRight.y - padding);
    }
}
