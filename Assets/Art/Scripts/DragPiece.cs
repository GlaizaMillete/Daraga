using UnityEngine;

public class DragPiece : MonoBehaviour
{
    private Vector3 offset;
    private bool isDragging = false;
    private RectTransform rectTransform;
    private Canvas canvas;
    private Vector3 targetPosition; // Smooth dragging target position
    private float smoothSpeed = 10f; // Drag smoothness multiplier

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();

        // Initialize targetPosition to the current position
        targetPosition = rectTransform.localPosition;
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
                        RectTransformUtility.ScreenPointToLocalPointInRectangle(
                            rectTransform, touchPosition, canvas.worldCamera, out localTouchPosition);
                        offset = rectTransform.localPosition - new Vector3(localTouchPosition.x, localTouchPosition.y, 0);
                        isDragging = true;
                    }
                    break;

                case TouchPhase.Moved:
                    if (isDragging)
                    {
                        Vector2 localTouchPosition;
                        RectTransformUtility.ScreenPointToLocalPointInRectangle(
                            rectTransform, touchPosition, canvas.worldCamera, out localTouchPosition);
                        targetPosition = new Vector3(localTouchPosition.x, localTouchPosition.y, 0) + offset;
                    }
                    break;

                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    isDragging = false;
                    break;
            }
        }

        // Smoothly move the object to the target position
        if (isDragging)
        {
            rectTransform.localPosition = Vector3.Lerp(rectTransform.localPosition, targetPosition, smoothSpeed * Time.deltaTime);
        }
    }

    private bool IsTouchingObject(Vector2 touchPosition)
    {
        if (rectTransform == null) return false;

        // Check if the touch is over this object
        return RectTransformUtility.RectangleContainsScreenPoint(rectTransform, touchPosition, canvas.worldCamera);
    }
}
