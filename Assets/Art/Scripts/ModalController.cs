using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModalController : MonoBehaviour
{
    public GameObject modalPanel;
    void Start()
    {
        // Ensure the modal is initially hidden
        if (modalPanel != null)
        {
            modalPanel.SetActive(false);
            Debug.Log("ModalPanel initialized to inactive.");
        }
        else
        {
            Debug.LogError("ModalPanel is not assigned in the Inspector.");
        }
    }

    public void OpenModal()
    {
        Debug.Log("OpenModal called"); // Debug log
        if (modalPanel != null)
        {
            modalPanel.SetActive(true);
            Debug.Log("ModalPanel set to active.");
        }
    }

    public void CloseModal()
    {
        Debug.Log("CloseModal called"); // Debug log
        if (modalPanel != null)
        {
            modalPanel.SetActive(false);
            Debug.Log("ModalPanel set to inactive.");
        }
    }
}
