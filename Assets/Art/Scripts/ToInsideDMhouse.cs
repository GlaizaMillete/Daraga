using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToInsideDMhouse : MonoBehaviour
{
    public SceneController sceneController; // Reference to your SceneController
    public string targetTag = "YourSpriteTag"; // The tag for the clickable sprite
    public string sceneToLoad = "CassavaFieldSceneName"; // The scene to load when the sprite is tapped

    void Update()
    {
        // Check for touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Detect touch start
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

                if (hit.collider != null && hit.collider.CompareTag(targetTag))
                {
                    Debug.Log("Sprite tapped!");
                    if (sceneController != null)
                    {
                        sceneController.LoadSpecificScene(sceneToLoad); // Trigger scene transition with the specified scene name
                    }
                    else
                    {
                        Debug.LogWarning("SceneController reference is missing!");
                    }
                }
            }
        }
    }
}