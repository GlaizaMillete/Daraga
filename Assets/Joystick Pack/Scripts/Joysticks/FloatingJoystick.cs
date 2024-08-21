using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FloatingJoystick : Joystick
{
    protected override void Start()
    {
        base.Start();
        // Ensure the joystick background is visible at the start and remains visible
        SetBackgroundVisibility(true);
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Pointer Down");
        // Allow the joystick to move but remain visible
        background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
        SetBackgroundVisibility(true);
        base.OnPointerDown(eventData);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Pointer Up");
        // Keep the joystick visible after the pointer is released
        SetBackgroundVisibility(true);
        base.OnPointerUp(eventData);
    }

    private void SetBackgroundVisibility(bool isVisible)
    {
        if (background != null)
        {
            background.gameObject.SetActive(isVisible);
        }
    }
}
