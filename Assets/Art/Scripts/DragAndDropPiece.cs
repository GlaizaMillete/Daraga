using UnityEngine;

public class DragAndDropPiece : MonoBehaviour
{
    private Vector3 offset;
    private bool isDragging;
    private JarAssemblyScript jarAssemblyScript;
    public int pieceIndex;  // Index of this piece (0 for jar1, 1 for jar2, etc.)

    void Start()
    {
        jarAssemblyScript = FindObjectOfType<JarAssemblyScript>();
    }

    void OnMouseDown()
    {
        offset = transform.position - GetMouseWorldPosition();
        isDragging = true;

        // Start dragging: move the piece above UI elements
        jarAssemblyScript.OnPieceStartDrag(pieceIndex);
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            transform.position = GetMouseWorldPosition() + offset;
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
        // Stop dragging: reset sorting
        jarAssemblyScript.OnPieceStopDrag(pieceIndex);

        // Call method to check if piece is placed correctly
        jarAssemblyScript.OnPiecePlaced(pieceIndex);
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}

