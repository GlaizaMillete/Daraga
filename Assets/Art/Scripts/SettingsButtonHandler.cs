using UnityEngine;
using UnityEngine.UI;

public class SettingsButtonHandler : MonoBehaviour
{
    public GameObject settingsPanel;
    private Button button;
    private bool isOnClickListenerAdded = false;

    private void Start()
    {
        // Get the Button component on the GameObject
        button = GetComponent<Button>();

        // Ensure the button is enabled at the start
        if (button != null)
        {
            button.interactable = true;
            if (!isOnClickListenerAdded)
            {
                button.onClick.AddListener(OnButtonClick);
                isOnClickListenerAdded = true;
            }
        }
        else
        {
            Debug.LogError("Button component not found on the GameObject.");
        }

        // Ensure the settings panel is assigned
        if (settingsPanel == null)
        {
            Debug.LogError("Settings panel is not assigned in the inspector.");
        }
    }

    public void OnButtonClick()
    {
        if (settingsPanel != null)
        {
            OpenSettings();
        }
    }

    private void OpenSettings()
    {
        if (settingsPanel != null)
        {
            settingsPanel.SetActive(!settingsPanel.activeSelf);
            Debug.Log("Settings panel " + (settingsPanel.activeSelf ? "opened" : "closed"));
        }
    }
}
