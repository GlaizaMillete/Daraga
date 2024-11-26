using UnityEngine;

public class DragPiece : MonoBehaviour
{
    private Vector3 offset;
    private bool isDragging = false;
    private RectTransform rectTransform;
    private Canvas canvas;
    private Vector3 targetPosition; // To store the target position for smooth dragging
    private float smoothSpeed = 40f; // Speed at which the object follows the touch position

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>(); // Get the parent canvas
        targetPosition = rectTransform.localPosition; // Initial target position
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = touch.position;

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (IsTouchingObject(touchPosition))
                    {
                        Vector2 localTouchPosition;
                        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, touchPosition, canvas.worldCamera, out localTouchPosition);
                        offset = rectTransform.localPosition - new Vector3(localTouchPosition.x, localTouchPosition.y, 0);
                        isDragging = true;
                    }
                    break;

                case TouchPhase.Moved:
                    if (isDragging)
                    {
                        Vector2 localTouchPosition;
                        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, touchPosition, canvas.worldCamera, out localTouchPosition);
                        targetPosition = new Vector3(localTouchPosition.x, localTouchPosition.y, 0) + offset;
                    }
                    break;

                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    isDragging = false;
                    break;
            }
        }

        // Smoothly move the object towards the target position
        if (isDragging || targetPosition != rectTransform.localPosition)
        {
            rectTransform.localPosition = Vector3.Lerp(rectTransform.localPosition, targetPosition, smoothSpeed * Time.deltaTime);
        }
    }

    private bool IsTouchingObject(Vector2 touchPosition)
    {
        if (rectTransform == null) return false;

        return RectTransformUtility.RectangleContainsScreenPoint(rectTransform, touchPosition, canvas.worldCamera);
    }
}
