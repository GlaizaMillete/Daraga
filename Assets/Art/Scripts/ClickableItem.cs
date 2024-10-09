using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableItem : MonoBehaviour
{
    public SickleController sickleController; // Reference to the SickleController
    private bool hasCollected = false;

    void OnMouseDown()
    {
        if (!hasCollected)
        {
            Collect();
        }
    }

    void Collect()
    {
        hasCollected = true;

        Debug.Log("Object Collected!");

        // Call the SickleController to handle the popup
        if (sickleController != null)
        {
            sickleController.OnSickleFound();
        }
        else
        {
            Debug.LogWarning("SickleController not assigned to the ClickableItem!");
        }

        // Optionally disable or destroy the object after collecting
        gameObject.SetActive(false);
    }
}