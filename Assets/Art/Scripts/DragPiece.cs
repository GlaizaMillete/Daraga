using UnityEngine;

public class DragPiece : MonoBehaviour
{
    private Vector3 offset;
    private Camera mainCamera;
    private bool isDragging = false;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void OnMouseDown()
    {
        if (Input.touchCount == 1 || Input.GetMouseButtonDown(0))
        {
            Vector3 screenPosition = mainCamera.WorldToScreenPoint(transform.position);
            Vector3 inputPosition = Input.touchCount > 0
                ? (Vector3)Input.GetTouch(0).position
                : Input.mousePosition;

            offset = transform.position - mainCamera.ScreenToWorldPoint(new Vector3(inputPosition.x, inputPosition.y, screenPosition.z));
            isDragging = true;
        }
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 inputPosition = Input.touchCount > 0
                ? (Vector3)Input.GetTouch(0).position
                : Input.mousePosition;

            Vector3 newWorldPosition = mainCamera.ScreenToWorldPoint(new Vector3(inputPosition.x, inputPosition.y, mainCamera.WorldToScreenPoint(transform.position).z));
            transform.position = newWorldPosition + offset;
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }
}
