using UnityEngine;
using UnityEngine.EventSystems;

public class SmoothDrag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private Vector3 offset;
    private Vector2 touchPosition;
    private bool isDragging = false;

    private RectTransform parentRectTransform; // To access the parent RectTransform (for bounds)

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        parentRectTransform = rectTransform.parent.GetComponent<RectTransform>(); // Get the parent RectTransform
    }

    // Called when the drag starts
    public void OnBeginDrag(PointerEventData eventData)
    {
        // Convert touch position to local space of the parent canvas
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, eventData.position, canvas.worldCamera, out touchPosition);
        offset = rectTransform.localPosition - new Vector3(touchPosition.x, touchPosition.y, 0); // Store the offset for smoother dragging
        isDragging = true;
    }

    // Called every frame while dragging
    public void OnDrag(PointerEventData eventData)
    {
        if (!isDragging) return;

        // Get the new touch position in local space
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, eventData.position, canvas.worldCamera, out touchPosition);

        // Calculate the new position based on touch and offset
        Vector3 newPosition = new Vector3(touchPosition.x, touchPosition.y, 0) + offset;

        // Clamp the position to stay within the parent bounds (optional)
        newPosition.x = Mathf.Clamp(newPosition.x, parentRectTransform.rect.xMin, parentRectTransform.rect.xMax);
        newPosition.y = Mathf.Clamp(newPosition.y, parentRectTransform.rect.yMin, parentRectTransform.rect.yMax);

        rectTransform.localPosition = newPosition;
    }

    // Called when the drag ends
    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;
    }
}
