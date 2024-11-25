using UnityEngine;

public class WorldSpaceCanvasHelper : MonoBehaviour
{
    private Canvas canvas;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
        if (canvas.renderMode == RenderMode.WorldSpace && canvas.worldCamera == null)
        {
            // Automatically assign the main camera if none is set
            canvas.worldCamera = Camera.main;
        }
    }
}
