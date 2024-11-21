using UnityEngine;

public class DraggablePiece : MonoBehaviour
{
    private Vector3 startPosition;
    private bool placedCorrectly = false;

    public Transform targetPosition; // Target position for the piece

    void Start()
    {
        startPosition = transform.position;
    }

    void OnMouseDrag()
    {
        if (!placedCorrectly)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x, mousePosition.y, startPosition.z);
        }
    }

    void OnMouseUp()
    {
        if (Vector3.Distance(transform.position, targetPosition.position) < 0.5f)
        {
            // Snap to position and mark as placed
            transform.position = targetPosition.position;
            placedCorrectly = true;
            FindObjectOfType<JarAssembleManager>().PiecePlaced();
        }
        else
        {
            // Reset position if not placed correctly
            transform.position = startPosition;
        }
    }

    // Reset position for reinitialization
    public void ResetPosition()
    {
        transform.position = startPosition;
        placedCorrectly = false;
    }
}
