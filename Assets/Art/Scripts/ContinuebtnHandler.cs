using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuebtnHandler : MonoBehaviour
{
    public GameObject continuePanel;  // Reference to the ContinuePanel GameObject
    void Start()
    {
        // Make sure the panel is initially inactive
        if (continuePanel != null)
        {
            continuePanel.SetActive(false);
        }
    }

    public void OnContinueButtonClick()
    {
        // Toggle the active state of the panel
        if (continuePanel != null)
        {
            continuePanel.SetActive(!continuePanel.activeSelf);
        }
    }

    public void OnBackButtonClick()
    {
        // Deactivate the panel
        if (continuePanel != null)
        {
            continuePanel.SetActive(false);
        }
    }
}
